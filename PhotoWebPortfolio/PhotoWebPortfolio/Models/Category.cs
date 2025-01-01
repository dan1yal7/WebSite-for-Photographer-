namespace PhotoWebPortfolio.Models
{
    public class Category
    {
       public int Id { get; set; }
       public Type Type { get; set; } 
       public int PortfolioItemId { get; set; }
       public int ServiceId { get; set; } 
    }

    public enum Type
    {
        Personal,
        LoveStory,
        Wedding,
        Fashion,
    }
}
