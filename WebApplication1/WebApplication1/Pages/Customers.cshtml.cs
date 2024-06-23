using ClassADO.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class CustomersModel : PageModel
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        private readonly IGeneralRepository<Customer> repo;

        public CustomersModel(IGeneralRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void OnGet()
        {
            Customers = repo.GetAll().ToList();
        }
    }
}
