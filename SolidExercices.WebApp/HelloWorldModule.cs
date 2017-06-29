
namespace SolidExercices.WebApp
{
    public class HelloWorldModule : Nancy.NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = _ => "Hello World!";
        }
    }
}