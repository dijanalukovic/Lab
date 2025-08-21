using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBussinesMenuItem
    {
        List<MenuItem> GetAllMenuItems();
        List<MenuItem> GetMenuItemsInRange(decimal min, decimal max);
        bool InsertMenuitem(MenuItem menuItem); 

    }
}
