namespace PhotoWebPortfolio.Models
{  
    // Principal Entity 
    public class Folder
    {
        public int Id { get; set; }  
        public string Name { get; set; } 
        public int ParentFolderId { get; set; }
        public ICollection<FolderItem> Items { get; set; } = new List<FolderItem>(); // Collection navigation on the principal entity referencing the dependent entities
        public string Sharedlink { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public bool IsVisible { get; set; } 

    }
}
