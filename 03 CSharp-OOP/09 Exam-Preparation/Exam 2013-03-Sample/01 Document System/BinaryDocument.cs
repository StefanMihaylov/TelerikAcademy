namespace DocumentSystem
{
    public abstract class BinaryDocument : Document
    {
        public uint Size
        {
            get
            {
                return this.GetProperty("Size").ToUInt();
            }
            private set
            {
                this.LoadProperty("Size", value.ToString());
            }
        }
    }
}
