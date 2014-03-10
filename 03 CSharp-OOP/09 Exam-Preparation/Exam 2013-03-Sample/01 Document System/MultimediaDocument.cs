namespace DocumentSystem
{
    public abstract class MultimediaDocument : BinaryDocument
    {
        public uint Length
        {
            get
            {
                return this.GetProperty("Length").ToUInt();
            }
            private set
            {
                this.LoadProperty("Length", value.ToString());
            }
        }
    }
}
