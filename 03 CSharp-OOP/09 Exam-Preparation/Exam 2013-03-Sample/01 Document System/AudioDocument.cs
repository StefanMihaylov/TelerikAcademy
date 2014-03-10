namespace DocumentSystem
{
    public class AudioDocument : MultimediaDocument
    {
        public uint SampleRate
        {
            get
            {
                return this.GetProperty("SampleRate").ToUInt();
            }
            private set
            {
                this.LoadProperty("SampleRate", value.ToString());
            }
        }
    }

}
