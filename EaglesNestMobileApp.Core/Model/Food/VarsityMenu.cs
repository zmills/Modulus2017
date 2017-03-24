using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class VarsityMenu : ObservableObject
    {
        private List<VarsityItem> LineOneBreakfast { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineTwoBreakfast { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineThreeBreakfast { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineFourBreakfast { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineOneLunch { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineTwoLunch { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineThreeLunch { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineFourLunch { get; set; } = new List<VarsityItem>();


        private List<VarsityItem> LineOneDinner { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineTwoDinner { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineThreeDinner { get; set; } = new List<VarsityItem>();
        private List<VarsityItem> LineFourDinner { get; set; } = new List<VarsityItem>();

        public void AddItem(VarsityItem item)
        {
            switch (item.MealTime)
            {
                case App.MealTimes.Breakfast:
                    AddBreakFastItem(item);
                    break;
                case App.MealTimes.Lunch:
                    AddLunchItem(item);
                    break;
                case App.MealTimes.Dinner:
                    AddDinnerItem(item);
                    break;
                default:
                    Debug.WriteLine(" Must be a stupid event like bible conference picnics or Christmas lights...go to taco bell.");
                    break;
            }
        }

        private void AddBreakFastItem(VarsityItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    LineOneBreakfast.Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LineTwoBreakfast.Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LineThreeBreakfast.Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LineFourBreakfast.Add(item);
                    break;
            }
        }

        private void AddLunchItem(VarsityItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    LineOneLunch.Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LineTwoLunch.Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LineThreeLunch.Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LineFourLunch.Add(item);
                    break;
            }
        }

        private void AddDinnerItem(VarsityItem item)
        {
            switch (item.LineNumber.ToString())
            {
                case App.LineKeys.LineOne:
                    LineOneDinner.Add(item);
                    break;
                case App.LineKeys.LineTwo:
                    LineTwoDinner.Add(item);
                    break;
                case App.LineKeys.LineThree:
                    LineThreeDinner.Add(item);
                    break;
                case App.LineKeys.LineFour:
                    LineFourDinner.Add(item);
                    break;
            }
        }

        public List<List<VarsityItem>> GetBreakfastMenu()
        {
            List<List<VarsityItem>> Menu = new List<List<VarsityItem>>
            {
                LineOneBreakfast,
                LineTwoBreakfast,
                LineThreeBreakfast,
                LineFourBreakfast
            };
            return Menu;
        }

        public List<List<VarsityItem>> GetLunchMenu()
        {
            List<List<VarsityItem>> Menu = new List<List<VarsityItem>>
            {
                LineOneLunch,
                LineTwoLunch,
                LineThreeLunch,
                LineFourLunch
            };
            return Menu;
        }

        public List<List<VarsityItem>> GetDinnerMenu()
        {
            List<List<VarsityItem>> Menu = new List<List<VarsityItem>>
            {
                LineOneDinner,
                LineTwoDinner,
                LineThreeDinner,
                LineFourDinner
            };
            return Menu;
        }
    }
}
