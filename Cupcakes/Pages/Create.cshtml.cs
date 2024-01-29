using Cupcakes.Data;
using Cupcakes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cupcakes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Cupcake Cupcake { get; set; } = new();
        public CreateModel(ILogger<CreateModel> logger)
        {
            _logger = logger;
            
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DbContext.AddNewCupcake(Cupcake);
            return RedirectToPage("/Index");
        }
    }
}
