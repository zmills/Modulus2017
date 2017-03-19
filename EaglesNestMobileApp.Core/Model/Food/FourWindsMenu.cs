using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Diagnostics;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class FourWindsMenu : ObservableObject
    {
        // MADE PRIVATE
        private List<FourWindsItem> LineOneBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineTwoBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineThreeBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineFourBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineFiveBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineSixBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineSevenBreakfast { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineOneLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineTwoLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineThreeLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineFourLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineFiveLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineSixLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineSevenLunch { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineOneDinner { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineTwoDinner { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineThreeDinner { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineFourDinner { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineFiveDinner { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineSixDinner { get; set; } = new List<FourWindsItem>();
        private List<FourWindsItem> LineSevenDinner { get; set; } = new List<FourWindsItem>();


        // Move to app class
        public void AddItem(FourWindsItem item)
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

        private void AddBreakFastItem(FourWindsItem item)
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
                case App.LineKeys.LineFive:
                    LineFiveBreakfast.Add(item);
                    break;
                case App.LineKeys.LineSix:
                    LineSixBreakfast.Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    LineSevenBreakfast.Add(item);
                    break;
            }
        }

        private void AddLunchItem(FourWindsItem item)
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
                case App.LineKeys.LineFive:
                    LineFiveLunch.Add(item);
                    break;
                case App.LineKeys.LineSix:
                    LineSixLunch.Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    LineSevenLunch.Add(item);
                    break;
            }
        }

        private void AddDinnerItem(FourWindsItem item)
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
                case App.LineKeys.LineFive:
                    LineFiveDinner.Add(item);
                    break;
                case App.LineKeys.LineSix:
                    LineSixDinner.Add(item);
                    break;
                case App.LineKeys.LineSeven:
                    LineSevenDinner.Add(item);
                    break;
            }
        }

        public List<List<FourWindsItem>> GetBreakfastMenu()
        {
            List<List<FourWindsItem>> Menu = new List<List<FourWindsItem>>
            {
                LineOneBreakfast,
                LineTwoBreakfast,
                LineThreeBreakfast,
                LineFourBreakfast,
                LineFiveBreakfast,
                LineSixBreakfast,
                LineSevenBreakfast
            };
            return Menu;
        }

        public List<List<FourWindsItem>> GetLunchMenu()
        {
            List<List<FourWindsItem>> Menu = new List<List<FourWindsItem>>
            {
                LineOneLunch,
                LineTwoLunch,
                LineThreeLunch,
                LineFourLunch,
                LineFiveLunch,
                LineSixLunch,
                LineSevenLunch
            };
            return Menu;
        }

        public List<List<FourWindsItem>> GetDinnerMenu()
        {
            List<List<FourWindsItem>> Menu = new List<List<FourWindsItem>>
            {
                LineOneDinner,
                LineTwoDinner,
                LineThreeDinner,
                LineFourDinner,
                LineFiveDinner,
                LineSixDinner,
                LineSevenDinner
            };
            return Menu;
        }
    }
}
