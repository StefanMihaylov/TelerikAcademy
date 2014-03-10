namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocument
    {
        public uint NumberOfRows
        {
            get
            {
                return this.GetProperty("rows").ToUInt();
            }
            private set
            {
                this.LoadProperty("rows", value.ToString());
            }
        }

        public uint NumberOfCols
        {
            get
            {
                return this.GetProperty("Cols").ToUInt();
            }
            private set
            {
                this.LoadProperty("Cols", value.ToString());
            }
        }
    }
}
