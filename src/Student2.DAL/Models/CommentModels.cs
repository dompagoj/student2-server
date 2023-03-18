using System.ComponentModel.DataAnnotations;

namespace LoginModel.Models
{
    public class CreateCommentModel
    {
        [Required]
        public required string Content { get; init; }
    }
}
