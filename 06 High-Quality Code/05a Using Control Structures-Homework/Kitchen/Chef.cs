namespace Kitchen
{
    using System.Collections.Generic;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            ICollection<Vegetable> bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);
           
            bowl.Add(potato);
            bowl.Add(carrot);
        }

        private Potato GetPotato()
        {
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            return new Carrot();
        }

        private ICollection<Vegetable> GetBowl()
        {
            return new List<Vegetable>();
        }

        private void Peel(Vegetable vegetable)
        {
        }

        private void Cut(Vegetable vegetable)
        {
        }
    }
}