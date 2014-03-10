using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLRenderer
{
    class HtmlElement : IElement
    {
        private string name;
        private string textContent;
        private ICollection<IElement> childElements;

        public HtmlElement(string name, string content = null)
        {
            this.Name = name;
            this.TextContent = content;
            this.childElements = new List<IElement>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentNullException("HTML element name cannot be null");
                //}
                this.name = value;
            }
        }

        public virtual string TextContent
        {
            get
            {
                return this.textContent;
            }
            set
            {
                //if (string.IsNullOrEmpty(value))
                //{
                //    throw new ArgumentNullException("HTML element text content cannot be null");
                //}
                this.textContent = value;
            }
        }

        public virtual IEnumerable<IElement> ChildElements
        {
            get
            {
                return new List<IElement>(this.childElements);
            }
        }

        public virtual void AddElement(IElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Added element cannot be null");
            }
            this.childElements.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.AppendFormat("<{0}>", this.Name);
            }
            if (this.TextContent != null)
            {
                StringBuilder content = new StringBuilder();
                content.Append(this.TextContent);
                content.Replace("&", "&amp;");
                content.Replace("<", "&lt;");
                content.Replace(">", "&gt;");
                output.Append(content);
                content.Clear();
            }

            if (this.ChildElements.Count<IElement>() > 0)
            {
                foreach (var element in this.ChildElements)
                {
                    element.Render(output);
                }
            }
            if (this.Name != null)
            {
                output.AppendFormat("</{0}>", this.Name);
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            this.Render(result);
            return result.ToString();
        }
    }
}
