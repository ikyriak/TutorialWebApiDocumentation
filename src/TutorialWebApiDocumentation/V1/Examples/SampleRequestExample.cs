using Swashbuckle.AspNetCore.Filters;
using TutorialWebApiDocumentation.V1.DTOs;

namespace TutorialWebApiDocumentation.V1.Examples
{
    public class SampleRequestExample : IExamplesProvider<SampleRequest>
    {
        public SampleRequest GetExamples()
        {
            return new SampleRequest()
            {
                Id = 2,
                Name = "Hello DotNetNakama",
            };
        }
    }
}
