namespace DocumentSystem
{
    public class PdfDocument : EncriptableDocument
    {
        public uint NumberOfPages
        {
            get
            {
                return this.GetProperty("Pages").ToUInt();
            }
            private set
            {
                this.LoadProperty("Pages", value.ToString());
            }
        }
    }
}
