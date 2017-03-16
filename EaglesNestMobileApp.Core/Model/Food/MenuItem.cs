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

    public class CampusDining
    {
        /*********************************************************************/
        /* FOUR WINDS BREAKFAST                                              */
        /*********************************************************************/
        /* LINE 1                                                            */
        public MenuItem[] line1MealItems =
        {
            new MenuItem { Name = "Scrambled Eggs" },
            new MenuItem { Name = "Breakfast Potatoes" },
            new MenuItem { Name = "Pork Maple Sausage Patties" },
            new MenuItem { Name = "Cherry Almond Muffins" },
            new MenuItem { Name ="Cheesy Grits" },
            new MenuItem { Name ="Pepper Gravy" },
            new MenuItem { Name ="Southern Biscuits" },
            new MenuItem { Name ="Shredded American Cheese" },
            new MenuItem { Name ="Apple Jelly" },
            new MenuItem { Name ="Grape Jelly" }
        };

        /* LINE 2                                                            */
        public static MenuItem[] line2MealItems =
        {
            new MenuItem { Name = "Creamy Oatmeal" },
            new MenuItem { Name = "Cinnamon Apple Cheese Muffins" },
            new MenuItem { Name = "Fresh Bagels" },
            new MenuItem { Name = "Hard Boiled Eggs" },
            new MenuItem { Name ="Vanilla Yogurt" },
            new MenuItem { Name ="Cottage Cheese" },
            new MenuItem { Name ="Pineapple Tidbits" },
            new MenuItem { Name ="Tropical Fruit Salad" },
            new MenuItem { Name ="Brown Sugar" },
            new MenuItem { Name ="Raisins" },
            new MenuItem { Name ="Cream Cheese" },
            new MenuItem { Name ="Apple Jelly" },
            new MenuItem { Name ="Grape Jelly" },
            new MenuItem { Name ="Fresh Fruit" }
        };

        /* LINE 3                                                            */
        public static MenuItem[] line3MealItems =
        {
            new MenuItem { Name = "Classic Cereals" },
            new MenuItem { Name = "Gluten Free Cereals" },
            new MenuItem { Name = "Healthy Cereals" },
            new MenuItem { Name = "Novelty Cereals" }
        };

        /* LINE 4                                                            */
        public static MenuItem[] line4MealItems =
        {
            new MenuItem { Name = "Country Fried Steak" },
            new MenuItem { Name = "Breakfast Potatoes" },
            new MenuItem { Name = "Southern Grits" },
            new MenuItem { Name = "Chicken Biscuits" },
            new MenuItem { Name = "Sausage Gravy" },
            new MenuItem { Name = "Pepper Gravy" },
            new MenuItem { Name = "Pork Maple Sausage Patties" },
            new MenuItem { Name = "Apple Butter" },
            new MenuItem { Name = "Orange Marmalade" },
            new MenuItem { Name = "Grape Jelly" },
            new MenuItem { Name = "Southern Biscuits" }
        };

        /* LINE 5                                                            */
        public static MenuItem[] line5MealItems =
        {
            new MenuItem { Name = "Cinnamon Apple Cheese Muffins" },
            new MenuItem { Name = "Scrambled Eggs" },
            new MenuItem { Name = "Breakfast Potatoes" },
            new MenuItem { Name = "Pork Maple Sausage Patties" },
            new MenuItem { Name ="Cheesy Grits" },
            new MenuItem { Name ="Pepper Gravy" },
            new MenuItem { Name ="Southern Biscuits" },
            new MenuItem { Name ="Shredded American Cheese" },
            new MenuItem { Name ="Apple Jelly" },
            new MenuItem { Name ="Grape Jelly" }
        };

        /* LINE 6                                                            */
        public static MenuItem[] line6MealItems =
        {
            new MenuItem { Name = "Egg White Omelets" },
            new MenuItem { Name = "Chicken Sausage Breakfast Links" },
            new MenuItem { Name = "Fresh Grapefruit" },
            new MenuItem { Name = "Sweet Potato Muffin Tops" },
            new MenuItem { Name = "Breakfast Rice" },
            new MenuItem { Name = "Cinnamon Raisin Bread" },
            new MenuItem { Name = "Vanilla Greek Yogurt" },
            new MenuItem { Name = "Granola" },
            new MenuItem { Name = "Tropical Fruit Salad" },
            new MenuItem { Name = "Fruit Cuties" },
            new MenuItem { Name = "Cream Cheese" },
            new MenuItem { Name = "Smart Balance" }
        };

        /* LINE 7                                                            */
        public static MenuItem[] line7MealItems =
        {
            new MenuItem { Name = "Belgian Waffles" },
            new MenuItem { Name = "Pancakes" },
            new MenuItem { Name = "Pork Sausage Links" },
            new MenuItem { Name = "Maple Syrup" },
            new MenuItem { Name = "Chocolate Syrup" },
            new MenuItem { Name = "Whipped Topping" }
        };

        /*********************************************************************/
        /* VARSITY                                                           */
        /*********************************************************************/

        /*********************************************************************/
        /* GRAB N GO                                                         */
        /*********************************************************************/

        public List<MenuItem[]> fourWindsMealMenus = new List<MenuItem[]>();

        /*********************************************************************/
        /* Return the Meal Menus per line in Four Winds                      */
        /*********************************************************************/
        public List<MenuItem[]> GetFourWindsBreakfastMealMenus()
        {
            fourWindsMealMenus.Add(line1MealItems);
            fourWindsMealMenus.Add(line2MealItems);
            fourWindsMealMenus.Add(line3MealItems);
            fourWindsMealMenus.Add(line4MealItems);
            fourWindsMealMenus.Add(line5MealItems);
            fourWindsMealMenus.Add(line6MealItems);
            fourWindsMealMenus.Add(line7MealItems);
            return fourWindsMealMenus;
        }
    }
   
}
