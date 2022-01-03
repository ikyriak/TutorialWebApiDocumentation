using Swashbuckle.AspNetCore.Filters;
using TutorialWebApiDocumentation.V1.DTOs;

namespace TutorialWebApiDocumentation.V1.Examples
{
    public class SampleResponseExamples : IExamplesProvider<IEnumerable<SampleResponse>>
    {
        public IEnumerable<SampleResponse> GetExamples()
        {
            return new List<SampleResponse>() {
                new SampleResponse()
                {
                    Id = 3,
                    Name = "Sample Name Value 3",
                },
                new SampleResponse()
                {
                    Id = 4,
                    Name = "Sample Name Value 4",
                }
                ,
                new SampleResponse()
                {
                    Id = 456,
                    Name = "Sample Name Value 456",
                }
            };
        }
    }
}
