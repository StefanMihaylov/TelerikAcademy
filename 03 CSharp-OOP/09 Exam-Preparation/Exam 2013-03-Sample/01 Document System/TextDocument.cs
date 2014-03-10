namespace DocumentSystem
{
    public class TextDocument : Document, IEditable
    {
        public string Charset
        {
            get
            {
                return this.GetProperty("Chars").ToString();
            }
            private set
            {
                this.LoadProperty("Chars", value.ToString());
            }
        }


        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
}
