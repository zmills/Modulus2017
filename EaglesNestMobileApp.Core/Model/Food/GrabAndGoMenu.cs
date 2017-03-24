using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace EaglesNestMobileApp.Core.Model.Food
{
    public class GrabAndGoMenu : ObservableObject
    {
        // MUST BE MADE PRIVATE
        private List<GrabAndGoItem> LineOneLunch { get; set; } = new List<GrabAndGoItem>();
        private List<GrabAndGoItem> LineTwoLunch { get; set; } = new List<GrabAndGoItem>();
        private List<GrabAndGoItem> LineThreeLunch { get; set; } = new List<GrabAndGoItem>();
        private List<GrabAndGoItem> LineFourLunch { get; set; } = new List<GrabAndGoItem>();

        //MUST BE MADE PRIVATE
        private List<GrabAndGoItem> LineOneDinner { get; set; } = new List<GrabAndGoItem>();
        private List<GrabAndGoItem> LineTwoDinner { get; set; } = new List<GrabAndGoItem>();
        private List<GrabAndGoItem> LineThreeDinner { get; set; } = new List<GrabAndGoItem>();
        private List<GrabAndGoItem> LineFourDinner { get; set; } = new List<GrabAndGoItem>();

        public void AddItem(GrabAndGoItem item)
        {
            if (item.MealTime == App.MealTimes.Lunch)
                AddLunchItem(item);
            else
                AddDinnerItem(item);
        }

        private void AddLunchItem(GrabAndGoItem item)
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

        private void AddDinnerItem(GrabAndGoItem item)
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

        public List<List<GrabAndGoItem>> GetLunchMenu()
        {
            List<List<GrabAndGoItem>> Menu = new List<List<GrabAndGoItem>>
            {
                LineOneLunch,
                LineTwoLunch,
                LineThreeLunch,
                LineFourLunch
            };
            return Menu;
        }

        public List<List<GrabAndGoItem>> GetDinnerMenu()
        {
            List<List<GrabAndGoItem>> Menu = new List<List<GrabAndGoItem>>
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
