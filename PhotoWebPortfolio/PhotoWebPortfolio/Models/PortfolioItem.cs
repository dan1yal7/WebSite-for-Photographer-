namespace PhotoWebPortfolio.Models
{
    public class PortfolioItem
    {
        public int Id {  get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public string ImagePath { get; set; } 
        public int CategoryId { get; set; }
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }

    }
}
