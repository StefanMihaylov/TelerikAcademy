namespace ForumSystem.Web.InputModels.Feedback
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class InputFeedbackViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [UIHint("ContentTextArea")]
        public string Content { get; set; }
    }
}