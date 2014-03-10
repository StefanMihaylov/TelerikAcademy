namespace DocumentSystem
{
    public class VideoDocument : MultimediaDocument
    {
        public uint FrameRate
        {
            get
            {
                return this.GetProperty("FrameRate").ToUInt();
            }
            private set
            {
                this.LoadProperty("FrameRate", value.ToString());
            }
        }
    }

}
