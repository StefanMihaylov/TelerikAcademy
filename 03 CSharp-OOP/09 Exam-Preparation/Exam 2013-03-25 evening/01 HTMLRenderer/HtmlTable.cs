using System;
using System.Text;
using System.Collections.Generic;

namespace HTMLRenderer
{
    class HtmlTable : HtmlElement, ITable
    {
        private const string TableName = "table";
        private const string TableRowTag = "tr";
        private const string TableColTag = "td";

        private IElement[,] matrix;

        public HtmlTable(int rows, int cols)
            : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new IElement[this.Rows, this.Cols];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }
        
        public IElement this[int row, int col]
        {
            get
            {
                if (row < 0 && row >= this.Rows && col < 0 && col >= this.Cols)
                {
                    throw new IndexOutOfRangeException("Row and Col are out of range");
                }
                return this.matrix[row, col];
            }
            set
            {
                if (row < 0 && row >= this.Rows && col < 0 && col >= this.Cols)
                {
                    throw new IndexOutOfRangeException("Row and Col are out of range");
                }
                this.matrix[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            StringBuilder element = new StringBuilder();
            output.AppendFormat("<{0}>",this.Name);
            for (int row = 0; row < this.Rows; row++)
            {
                output.AppendFormat("<{0}>", TableRowTag);
                for (int col = 0; col < this.Cols; col++)
                {
                    output.AppendFormat("<{1}>{0}</{1}>", this[row, col].ToString(), TableColTag);
                }
                output.AppendFormat("</{0}>", TableRowTag);
            }

            output.AppendFormat("</{0}>", this.Name);
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new InvalidOperationException("HTML Table don't contain child elements");
            }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException("HTML Table don't contain child elements");
        }
    }
}
