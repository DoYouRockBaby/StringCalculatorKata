using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Nancy;
using Nancy.ModelBinding;
using SolidExercices.Operator;
using SolidExercices.WebApp.TypeHandler;

namespace SolidExercices.WebApp
{
    public class CalculateModule : NancyModule
    {
        private Calculator _calculator = new Calculator();
        private ITypeHandler _typeHandler = new JsonHandler();

        public CalculateModule()
        {
            //instantiate add and minus
            List<IOperator> simpleOperators = new List<IOperator>();
            simpleOperators.Add(new AddOperator());
            simpleOperators.Add(new MinusOperator());

            //instantiate product and division (they have proprity)
            List<IOperator> prioritaryOperators = new List<IOperator>();
            prioritaryOperators.Add(new ProductOperator());
            prioritaryOperators.Add(new DivisionOperator());

            //add the operations to the calculator
            _calculator.Operators.Add(prioritaryOperators);
            _calculator.Operators.Add(simpleOperators);

            Post["/calculate"] = Calculate;
            Post["/train"] = Train;
        }

        private dynamic Calculate(dynamic arg)
        {
            var operations = this.Bind<List<OperationRecord>>();
            foreach (OperationRecord operation in operations)
            {
                operation.Result = _calculator.Calculate(operation.Operation);
            }

            return _typeHandler.Encode(operations);
        }

        private dynamic Train(dynamic arg)
        {
            String url = this.Request.Body.ToString();
            var webRequest = WebRequest.Create(url);

            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var fullContent = reader.ReadToEnd();
                var records = _typeHandler.Decode(fullContent);
                return records;
            }
        }

        /*private dynamic StartGame(dynamic o)
        {
            var startGame = this.Bind<StartGame>();
            _eventDispatcher = new JsonEventDispatcher();
            var players = new Players(_eventDispatcher);
            foreach (var player in startGame.Players)
            {
                players.Add(ayer);
            }

            _game = new Game(players, new Questions(startGame.Categories, new GeneratedQuestions(), _eventDispatcher), _eventDispatcher);
            return JsonConvert.SerializeObject(_eventDispatcher.Events);
        }*/
    }

    internal class OperationRecord
    {
        public string Operation;
        public decimal Result;
    }
}