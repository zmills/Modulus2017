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

        public string BoxCombinationInstructions;

        /* Singleton instance of the database                    */
        private readonly IAzureService Database;

        public StudentInfoFragmentViewModel(IAzureService database)
        {
            Database = database;
        }

        public async Task InitializeAsync()
        {
            CurrentUser = await Database.GetStudentAsync();

            /* Breaking up the combination for the string                      */
            /* NEED TO USE REGULAR EXPRESSION!!        */
            BoxCombinationInstructions = "In order to open your box, turn the " +
                "dial left at least four turns stopping at " +
                $"{CurrentUser.BoxCombination.Substring(0, 2)}, turn " +
                "right passing first number one time and stopping at " +
                $"{CurrentUser.BoxCombination.Substring(3, 2)}, then left and" +
                $" stop at {CurrentUser.BoxCombination.Substring(5, 2)}.";
        }
    }
}
