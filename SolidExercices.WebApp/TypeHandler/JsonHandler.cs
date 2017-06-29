using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Newtonsoft.Json;

namespace SolidExercices.WebApp.TypeHandler
{
    public class JsonHandler : ITypeHandler
    {
        public dynamic Decode(dynamic contents)
        {
            return JsonConvert.DeserializeObject(contents);
        }

        public dynamic Encode(dynamic datas)
        {
            string contents = JsonConvert.SerializeObject(datas);
            var response = (Response)contents;
            response.ContentType = "application/json";
            return response;
        }
    }
}
