namespace DocumentSystem
{
    public class WordDocument : OfficeDocument, IEditable
    {
        public uint NumberOfCharacters
        {
            get
            {
                return this.GetProperty("Chars").ToUInt();
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
