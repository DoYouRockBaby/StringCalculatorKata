
using Nancy;
using SolidExercices.WebApp.TypeHandler;

namespace SolidExercices.WebApp
{
    public class SampleFileModule : Nancy.NancyModule
    {
        public ITypeHandler TypeHandler = new JsonHandler();
        public SampleFileModule()
        {
            Get["/sampleOperation"] = SampleOperation;
        }

        private dynamic SampleOperation(dynamic arg)
        {
            string contents = "[{\"operation\": \"1+2,3\"}, {\"operation\": \"2 x 3,6\"}, {\"operation\": \"6-1-3,8\"}]";
            var response = (Response)contents;
            response.ContentType = "application/json";
            return response;
        }
    }
}