using Android.Support.V7.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class MenuItem
    {
        private string name;

       public string Name
        {
            set
            {
               name = value;
            }
            get
            {
                return name;
            }
        }
    }

    public class MenuItems
    {
        public static MenuItem[] builtInItems = { new MenuItem { Name = "Scrambled Eggs" },
                                   new MenuItem { Name = "Breakfast Potatoes" },
                                   new MenuItem { Name = "Pork Maple Sausage" },
                                   new MenuItem { Name = "Cherry Almond Muffins" },
                                   new MenuItem { Name ="Cheesy Grits" },
                                   new MenuItem { Name ="Pepper Gravy" },
                                   new MenuItem { Name ="Southern Biscuits" },
                                   new MenuItem { Name ="Shredded American Cheese" },
                                   new MenuItem { Name ="Apple Jelly" },
                                   new MenuItem { Name ="Grape Jelly" },
                                   new MenuItem { Name = "Scrambled Eggs" },
                                   new MenuItem { Name = "Breakfast Potatoes" },
                                   new MenuItem { Name = "Pork Maple Sausage" },
                                   new MenuItem { Name = "Cherry Almond Muffins" },
                                   new MenuItem { Name ="Cheesy Grits" },
                                   new MenuItem { Name ="Pepper Gravy" },
                                   new MenuItem { Name ="Southern Biscuits" },
                                   new MenuItem { Name ="Shredded American Cheese" },
                                   new MenuItem { Name ="Apple Jelly" },
                                   new MenuItem { Name ="Grape Jelly" },
                                   new MenuItem { Name = "Breakfast Potatoes" },
                                   new MenuItem { Name = "Pork Maple Sausage" },
                                   new MenuItem { Name = "Cherry Almond Muffins" },
                                   new MenuItem { Name ="Cheesy Grits" },
                                   new MenuItem { Name ="Pepper Gravy" },
                                   new MenuItem { Name ="Southern Biscuits" },
                                   new MenuItem { Name ="Shredded American Cheese" },
                                   new MenuItem { Name ="Apple Jelly" },
                                   new MenuItem { Name ="Grape Jelly" },
                                   new MenuItem { Name = "Scrambled Eggs" },
                                   new MenuItem { Name = "Breakfast Potatoes" },
                                   new MenuItem { Name = "Pork Maple Sausage" },
                                   new MenuItem { Name = "Cherry Almond Muffins" },
                                   new MenuItem { Name ="Cheesy Grits" },
                                   new MenuItem { Name ="Pepper Gravy" },
                                   new MenuItem { Name ="Southern Biscuits" },
                                   new MenuItem { Name ="Shredded American Cheese" },
                                   new MenuItem { Name ="Apple Jelly" },
                                   new MenuItem { Name ="Grape Jelly" }};

        private MenuItem[] mMenuItems;

        public MenuItems()
        {
            mMenuItems = builtInItems;
        }

        public int numItems
        {
            get
            {
                return mMenuItems.Length;
            }
        }

    }

   
}
