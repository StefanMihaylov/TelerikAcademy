using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        IList<IDocument> documents;

        public DocumentSystem()
        {
            this.documents = new List<IDocument>();
        }

        public string AddTextDocument(string[] attributes)
        {
            string name;

            if (attributes.Length == 1)
            {
                name = attributes[0];
                //documents.Add(new TextDocument(name));
                return string.Format("Document added: {0}", name);
            }
            else if (attributes.Length == 3)
            {
                name = attributes[0];
                string charSet = attributes[1];
                string contents = attributes[2];
                //documents.Add(new TextDocument(name, contents ,charSet));
                return string.Format("Document added: {0}", name);
            }
            else
            {
                return string.Format("Document has no name");
            }
        }

        public string AddPdfDocument(string[] attributes)
        {
            throw new NotImplementedException();
        }

        public string AddWordDocument(string[] attributes)
        {
            throw new NotImplementedException();
        }

        public string AddExcelDocument(string[] attributes)
        {
            throw new NotImplementedException();
        }

        public string AddAudioDocument(string[] attributes)
        {
            throw new NotImplementedException();
        }

        public string AddVideoDocument(string[] attributes)
        {
            throw new NotImplementedException();
        }

        public string ListDocuments()
        {
            throw new NotImplementedException();
        }

        public string EncryptDocument(string name)
        {
            throw new NotImplementedException();
        }

        public string DecryptDocument(string name)
        {
            throw new NotImplementedException();
        }

        public string EncryptAllDocuments()
        {
            throw new NotImplementedException();
        }

        public string ChangeContent(string name, string content)
        {
            throw new NotImplementedException();
        }
    }
}
