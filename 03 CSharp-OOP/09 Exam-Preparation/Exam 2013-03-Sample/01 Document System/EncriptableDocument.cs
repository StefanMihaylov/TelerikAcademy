namespace DocumentSystem
{

    public abstract class EncriptableDocument : BinaryDocument, IEncryptable
    {
        public bool IsEncrypted { get; protected set; }
        
        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }

    }
}