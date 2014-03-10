namespace DocumentSystem
{
    public abstract class OfficeDocument : EncriptableDocument
    {
        public string Version
        {
            get
            {
                return this.GetProperty("Version").ToString();
            }
            private set
            {
                this.LoadProperty("Version", value.ToString());
            }
        }
    }
}
