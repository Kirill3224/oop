using FirstLab.Core.Interfaces;

namespace FirstLab.Core.Entities
{
    public class TaxiDriver : IPerson, IDrive
    {
        public string ObjectType { get; set; }
        public string ObjectName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ExtraSkill { get; set; }

        public void Drive()
        {
            ExtraSkill = "Веде машину";
        }
    }
}