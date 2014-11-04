namespace MobileBg
{
    using System.Collections.Generic;

    public class Produser
    {
        public Produser()
        {
            this.Models = new HashSet<Model>();
        }

        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}