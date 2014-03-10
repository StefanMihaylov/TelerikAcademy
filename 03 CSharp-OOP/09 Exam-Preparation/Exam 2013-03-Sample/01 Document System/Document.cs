using System;
using System.Collections.Generic;
using System.Linq;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        protected IDictionary<string, object> properties;

        public string Name
        {
            get
            {
                return this.GetProperty("Name") as string;
            }
            protected set
            {
                this.LoadProperty("Name", value.ToString());
            }
        }

        public string Content
        {
            get
            {
                return this.GetProperty("Content").ToString();
            }
            protected set
            {
                this.LoadProperty("Content", value.ToString());
            }
        }

        public void LoadProperty(string key, string value)
        {
            string keyLower = key.ToLower();
            if (this.properties.ContainsKey(keyLower))
            {
                this.properties[keyLower] = value;
            }
            else
            {
                this.properties.Add(keyLower, value);
            }
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output = this.properties.ToList();
        }

        public override string ToString()
        {
            // TODO: Implement this method
            return base.ToString();
        }

        protected object GetProperty(string key)
        {
            string keyLower = key.ToLower();
            if (this.properties.ContainsKey(keyLower))
            {
                return this.properties[keyLower];
            }
            else
            {
                return null;
            }

        }
    }
}
