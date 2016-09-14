using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingList_Team2_Master.Models
{
    public enum Priority
    {
        Now = 1, Soon = 2, Wait = 3
    }
          
    public class ShoppingListItemModel
    {          
        public int ID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ListId { get; set; }

        [Display(Name = "Item Name")]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsChecked { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool Purchased { get; set; }         

        public Priority? Priority { get; set; }

        public string Note { get; set; }

        [HiddenInput(DisplayValue = false)]
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