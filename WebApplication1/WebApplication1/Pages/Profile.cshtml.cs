using ClassADO.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly DatabaseOrm _db;
        private readonly CustomerDbContext cdbc;
        private readonly IGeneralRepository<Customer> repo;

        public string Message { get; set; }
        [BindProperty]
        public ProfileRequestDto Prd { get; set; }

        public ProfileModel(DatabaseOrm db, CustomerDbContext cdbc, IGeneralRepository<Customer> repo)
        {
            this._db = db;
            this.cdbc = cdbc;
            this.repo = repo;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (repo.GetAll().Select(x => x.Email).Contains(Prd.Email))
            {
                Message = "Email already exists";
                return;
            }
            repo.Insert(new Customer(Prd.Name, Prd.Email, Prd.Age));
            Message = $"Name: {Prd.Name}\nEmail: {Prd.Email}\nAge: {Prd.Age}";
        }
    }

    public class ProfileRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public ProfileRequestDto() { }
    }
}
