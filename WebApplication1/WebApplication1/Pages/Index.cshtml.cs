using ClassADO.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class DatabaseOrm
    {
        private string Source { get; set; }
        private string LogIn { get; set; }
        private string Pssword { get; set; }
        private string DatabaseName { get; set; }
        private static List<Customer> Customers { get; set; } = new List<Customer>();


        public DatabaseOrm(string databaseName = "", string source = "", string logIn = "", string pssword = "")
        {
            Source = source;
            LogIn = logIn;
            Pssword = pssword;
            DatabaseName = databaseName;
        }

        public List<Customer> GetAll() { return Customers; }

        public void Add(Customer customer)
        {
            Customers.Add(customer);
        }
    }

    public class IndexModel : PageModel
    {
        private readonly IGeneralRepository<Customer> repo;

        public IndexModel(ILogger<IndexModel> logger, DatabaseOrm db, IGeneralRepository<Customer> repo)
        {
            this.repo = repo;

        }   

        public void OnGet()
        {
            Console.WriteLine($"New User entered at {DateTime.Now}!");
        }
    }
}