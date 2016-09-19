using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingList_Team2_Master.Models
{
    public enum Priority
     {
          Now = 1, Soon = 2, Wait = 3
     }
          
     public class ShoppingListItemModel
     {          
            [Key]
          public int ID { get; set; }

           [Display(Name = "Name of List")]
          public int ListId { get; set; }        
           [Display(Name = "Name of Item")]
          public string Name { get; set; }

           
          public bool IsChecked { get; set; }

          [Display(Name = "Purchased?")]
          public bool Purchased { get; set; }         


          public Priority? Priority { get; set; }

          public string Note { get; set; }
          
          [Display(Name = "Time of Creation")]
          public DateTimeOffset CreatedUtc { get; set; }

          //get list id and name
          public override string ToString()
          {
               return $"[{ListId} {Name}";
          }

          public ListModel List { get; set; }
     }
}