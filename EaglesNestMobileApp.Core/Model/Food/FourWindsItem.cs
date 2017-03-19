using GalaSoft.MvvmLight;

namespace EaglesNestMobileApp.Core.Model
{
    public class FourWindsItem : ObservableObject
    {
        public string Id { get; set; }
        public string MealTheme { get; set; }
        public string MealTime { get; set; }
        public string LineNumber { get; set; }
        public string ItemName { get; set; }
        public string BuildingName { get; set; }
    }
}