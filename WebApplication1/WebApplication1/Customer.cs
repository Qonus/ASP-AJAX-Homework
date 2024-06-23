namespace WebApplication1
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Customer(string name, string email, int age)
        {
            Name = name;
            Email = email;
            Age = age;
        }
    }
}
