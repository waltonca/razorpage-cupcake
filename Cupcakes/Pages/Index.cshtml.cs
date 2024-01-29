using Cupcakes.Data;
using Cupcakes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cupcakes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Cupcake> cupcakes = new List<Cupcake>();
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            cupcakes = DbContext.GetAllCupcakes();
        }

        public void OnGet()
        {
            

            foreach (Cupcake cupcake in cupcakes)
            {
                _logger.Log(LogLevel.Information, cupcake.Name);
            }
        }
    }
}
