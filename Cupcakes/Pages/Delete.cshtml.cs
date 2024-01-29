using Cupcakes.Data;
using Cupcakes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cupcakes.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Cupcake Cupcake { get; set; } = new();

        public void OnGet(int id)
        {
            // Initialize the Cupcake 
            Cupcake = DbContext.GetCupcakeById(id);
        }

        public IActionResult OnPost()
        {
            DbContext.RemoveCupcake(Cupcake.CupcakeId);
            return RedirectToPage("/Index");
        }
    }
}
