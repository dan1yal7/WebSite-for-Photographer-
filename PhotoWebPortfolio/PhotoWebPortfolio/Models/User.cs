﻿namespace PhotoWebPortfolio.Models
{
    public class User
    {
         public string Username { get; set; } 
         public string Email { get; set; }
         public string PasswordHash { get; set; }
         public string Role { get; set; }
         public int RoleId { get; set; }
         public  DateTime LastLogin { get; set; }
         public DateTime CreatedAt { get; set; }


    }
}