using System.ComponentModel.DataAnnotations;

namespace TutorialWebApiDocumentation.V2.DTOs
{
    public class SampleRequest
    {
        [Required]
        public Guid Id { get; set; }

        public List<string>? Names { get; set; }
    }
}
