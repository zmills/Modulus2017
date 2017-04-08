using Android;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace EaglesNestMobileApp.Core.ViewModel
{
    public class AnnouncementsFragmentViewModel : ViewModelBase
    {
        public ObservableCollection<Card> Announcements { get; set; }

        private void InitializeAnnouncements()
        {
           
        }
    }
}
