namespace Northwind.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public partial class Employee
    {
        public ICollection<Region> Regions
        {
            get
            {
                var result = this.Territories.Select(t => t.Region).ToList();
                return result;
            }
        }
    }
}
