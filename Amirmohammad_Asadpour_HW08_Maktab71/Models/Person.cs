namespace Amirmohammad_Asadpour_HW08_Maktab71.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
