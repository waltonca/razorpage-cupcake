using Cupcakes.Data;
using Cupcakes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cupcakes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IHostEnvironment _environment;

        [BindProperty]
        public Cupcake Cupcake { get; set; } = new();

        [BindProperty]
        public IFormFile FileUpload { get; set; }
        public CreateModel(ILogger<CreateModel> logger, IHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (FileUpload != null) 
            {
                string filename = FileUpload.FileName;
                // Update the Cupcake object with the filename
                Cupcake.ImageFileName = filename;

                // Save the uploaded file to wwwroot/uploads
                string projectRootPath = _environment.ContentRootPath;
                string fileSavePath = Path.Combine(projectRootPath, "wwwroot/uploads", filename);

                using (FileStream fileStream = new FileStream(fileSavePath, FileMode.Create))
                {
                    FileUpload.CopyTo(fileStream);
                }
            }
            DbContext.AddNewCupcake(Cupcake);
            return RedirectToPage("/Index");
        }
    }
}
