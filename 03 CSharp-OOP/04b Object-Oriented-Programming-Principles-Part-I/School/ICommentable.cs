namespace School
{
    public interface ICommentable
    {
        string Comment { get; set; }

        void AddComment(string comment);
    }
}
