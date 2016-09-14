using System.Web;
using System.Web.Mvc;

namespace ShoppingList_Team2_Master
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
