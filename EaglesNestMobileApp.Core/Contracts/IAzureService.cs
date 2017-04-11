using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Campus;
using EaglesNestMobileApp.Core.Model.Home;
using EaglesNestMobileApp.Core.Model.Personal;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface IAzureService
    {
        Task InitLocalStore();

        Task<List<Assignment>> GetAssignmentsAsync();

        Task<List<Course>> GetCoursesAsync();

        Task<ObservableCollection<Events>> GetEventsAsync();

        Task<List<ClassAttendance>> GetAttendanceViolationsAsync();

        Task<List<FourWindsItem>> GetFourWindsItemsAsync();

        Task<List<VarsityItem>> GetVarsityItemsAsync();

        Task<List<GrabAndGoItem>> GetGrabAndGoItemsAsync();

        Task<List<Offense>> GetStudentCourtOffensesAsync();

        Task<LocalToken> GetLocalTokenAsync();

        Task<AzureToken> GetAzureTokenAsync(LocalToken user);

        Task<Student> GetStudentAsync();

        Task<List<OffenseCategory>> GetStudentCourtCategoriesAsync();

        Task InsertLocalTokenAsync(LocalToken user);

        Task PurgeDatabaseAsync();

        Task SyncAsync(bool pullData = false);
        //Task<ObservableCollection<AttendanceViolation>> GetAttendanceViolationsAsync();
    }
}