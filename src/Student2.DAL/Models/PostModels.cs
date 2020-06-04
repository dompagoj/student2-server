using System.ComponentModel.DataAnnotations;
using Student2.BL.Entities;

namespace Student2.DAL.Models
{
    public class PostUpdateModel
    {
        [MaxLength(300)]
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? CourseId { get; set; }
    }

    public class PostCreateModel
    {
        [MaxLength(300)]
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int? CourseId { get; set; }

        public PostCreateModel() { }

        public PostCreateModel(string title, string content, int? courseId)
        {
            Title = title;
            Content = content;
            CourseId = courseId;
        }
    }


    public static class PostExtensions
    {
        public static void Update(this Post post, PostUpdateModel model)
        {
            if (model.Title != null) post.Title = model.Title;
            post.Content = model.Content;
            post.CourseId = model.CourseId;
        }
    }
}
