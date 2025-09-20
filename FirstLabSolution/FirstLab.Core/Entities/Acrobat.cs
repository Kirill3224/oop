using FirstLab.Core.Interfaces;

namespace FirstLab.Core.Entities
{
    public class Acrobat : IPerson, IDance
    {
        public string ObjectType { get; set; }
        public string ObjectName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ExtraSkill { get; set; }

        public void Dance()
        {
            ExtraSkill = "Танцює";
        }
    }
}