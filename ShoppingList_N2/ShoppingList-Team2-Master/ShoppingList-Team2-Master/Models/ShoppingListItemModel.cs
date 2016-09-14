using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

           
          public int ListId { get; set; }        

          public string Name { get; set; }

           
          public bool IsChecked { get; set; }

          
          public bool Purchased { get; set; }         

          public Priority? Priority { get; set; }

          public string Note { get; set; }
          
          public DateTimeOffset CreatedUtc { get; set; }

          //get list id and name
          public override string ToString()
          {
               return $"[{ListId} {Name}";
          }

          public ListModel List { get; set; }
     }
}