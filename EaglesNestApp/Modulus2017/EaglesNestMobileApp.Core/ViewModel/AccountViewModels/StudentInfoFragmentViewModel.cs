using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.ViewModel.AccountViewModels
{
    public class StudentInfoFragmentViewModel : ViewModelBase
    {
        /* The list of the student assignments */
        private Student _currentUser = new Student();
        public Student CurrentUser
        {
            get { return _currentUser; }
            private set { Set(() => CurrentUser, ref _currentUser, value); }
        }

        public ICustomProgressDialog Dialog = App.Locator.Dialog;

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public string BoxCombinationTitle;
        public string BoxCombinationMessage;
        public string TelephoneTitle;
        public string TelephoneMessage;


        /* Command to be binded to the refresh event in the view */
        private RelayCommand _showChecksheetCommand;

        public RelayCommand ShowChecksheetCommand => _showChecksheetCommand ??
            (_showChecksheetCommand =
                new RelayCommand( async ()=>
                    await Dialog.StartToastAsync("Checksheet download started...",
                        Android.Widget.ToastLength.Short, 150)));

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _showBoxCombinationCommand;

        //public RelayCommand ShowBoxCombinationCommand => _showBoxCombinationCommand ??
        //    (_showBoxCombinationCommand =
        //        new RelayCommand(async () =>
        //           await ShowCombination()));

        /* Command to be binded to the refresh event in the view */
        private RelayCommand _showTelephoneInstructionsCommand;

        //public RelayCommand ShowTelephoneInstructionsCommand => _showTelephoneInstructionsCommand ??
        //    (_showTelephoneInstructionsCommand =
        //        new RelayCommand(async () =>
        //           await ShowTelephoneInstructions()));


        public StudentInfoFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            CurrentUser = await Database.GetStudentAsync();
            BoxCombinationTitle = "Box Combination Instructions";

            BoxCombinationMessage = "In order to open your box, turn the " +
                "dial left at least four turns stopping at " +
                $"{CurrentUser.BoxCombination.Substring(0, 2)}, turn " +
                "right passing the first number one time and stopping at " +
                $"{CurrentUser.BoxCombination.Substring(3, 2)}, then left and" +
                $" stop at {CurrentUser.BoxCombination.Substring(6, 2)}.";

            TelephoneTitle = "    Messaging and Telephone\n" +
                "               Instructions";

            TelephoneMessage = "Each residence hall student is provided with a personal" +
                " seven-digit extension and a voicemail box that uses the " +
                " following format:\n\n   17 + Room Number (4 digits) + " +
                                    "\n   Line Number (1 digit).\n\n" +
                "Your line number is located on your Welcome Notice next to your room number." +
                " It will be a 1, 2, 3, or 4. For example, for room number 2524, line 1, " +
                " the extension would be 1725241.";
        }

        //private async Task ShowCombination()
        //{,
        //        \n", true, 150);
        //}

        //private async Task ShowTelephoneInstructions()
        //{
        //    //" the extension would be 1725241.\nCallers can leave a voice message if the " +
        //    //"call is unanswered after three rings or if the line is busy. Before you can " +
        //    //"check for messages, you must set up your voicemail box as follows: " +
        //    //"Lift the handset on your residence hall telephone and press the button that " +
        //    //"corresponds with your line number (from your Welcome Notice)." +
        //    //"Press the gray Message button located above your Line button. Enter your " +
        //    //"voice mailbox number, which is 17 + Room Number + Line Number, followed by the # sign." +
        //    //"Enter your temporary password, which is 1217 + Room Number + Line Number." +
        //    //" Change your password, as the system prompts. Enter a new password of four or more digits.",
        //}

        public override void Cleanup()
        {
            CurrentUser = new Student();
            base.Cleanup();
        }
    }
}
