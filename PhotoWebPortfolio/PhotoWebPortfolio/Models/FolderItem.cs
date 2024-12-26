namespace PhotoWebPortfolio.Models
{
    public class FolderItem
    { 
        // Dependent entity of the Folder 
      public int Id { get; set; } 
      public int FolderId { get; set; } // Required foreign key property
      public Folder Folder { get; set; } // Required reference navigation on the dependent entity referencing the principal entity 
    }
}
