using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace InnoCVExercise.PresentationLayer.StartupService
{
    public class SwaggerConfiguration : SwaggerGeneratorOptions
    {
        public SwaggerConfiguration()
        {
            SwaggerDocs.Add("v1", new Info { Title = "My API", Version = "v1" });
        }
             
    }
}
