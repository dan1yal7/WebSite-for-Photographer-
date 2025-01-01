namespace PhotoWebPortfolio.Models
{
    public class ClientInteraction
    {
        public int Id { get; set; } 
        public int FolderId { get; set; } 
        public int ClientId { get; set; } 
        public int LikedPortfolioId { get; set; } 
        public int DownloadedPortfolioItemId { get; set; }
        public DateTime ViewedAt { get; set; } 
        public string Action {  get; set; }
        public int PortfolioItemId { get; set; }
    }
}
