using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class CoursesModel : PageModel
    {
        public double Tenge;
        public void OnGet()
        {
        }

        public void OnPost(double tenge)
        {
            Tenge = tenge;
        }
    }
}
