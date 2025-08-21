using DataLayer.Models;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BussinesMenuItem : IBussinesMenuItem
    {
        private readonly IMenuItems iMenuItems;
        public BussinesMenuItem(IMenuItems iMenuItems)
        {
            this.iMenuItems = iMenuItems;
        }
        public List<MenuItem> GetAllMenuItems()
        {
            return iMenuItems.GetAllMenuItems();
        }

        public List<MenuItem> GetMenuItemsInRange(decimal min, decimal max)
        {
            return iMenuItems.GetAllMenuItems()
                                .Where(x => x.Price >= min && x.Price <= max)
                                .ToList();
        }

        public bool InsertMenuitem(MenuItem menuItem)
        {
            if (iMenuItems.InsertMenuItem(menuItem))
            {
                return true;


            }
            else {
                return false;
            }

        }
    }
}
