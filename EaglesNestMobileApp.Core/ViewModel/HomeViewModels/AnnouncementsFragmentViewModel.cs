using Android;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class AnnouncementsFragmentViewModel : ViewModelBase
    {
        public ObservableCollection<AnnouncementCard> Announcements { get; set; }

        public static void Initialize()
        {

        }
    }
}
