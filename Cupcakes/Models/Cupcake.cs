namespace Cupcakes.Models
{
    //
    // This is the Cupcake model, meant to store data in the cupcake table in my database.
    //
    public class Cupcake
    {
        public int CupcakeId { get; set; }
        public string Name { get;set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
