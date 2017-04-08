using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Home;
using EaglesNestMobileApp.Core.Model.Personal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface IAzureService
    {
        Task InitLocalStore();

        Task<List<Assignment>> GetAssignmentsAsync();

        Task<List<Course>> GetCoursesAsync();

        Task<List<EventsSignUp>> GetEventsAsync();

        Task<List<ClassAttendance>> GetAttendanceViolationsAsync();

        Task<List<FourWindsItem>> GetFourWindsItemsAsync();

        Task<List<VarsityItem>> GetVarsityItemsAsync();

        Task<List<GrabAndGoItem>> GetGrabAndGoItemsAsync();

        Task<LocalToken> GetLocalTokenAsync();

        Task<AzureToken> GetAzureTokenAsync(LocalToken user);

        Task<Student> GetStudentAsync();

        Task InsertLocalTokenAsync(LocalToken user);

        Task PurgeDatabaseAsync();

        Task SyncAsync(bool pullData = false);
        //Task<ObservableCollection<AttendanceViolation>> GetAttendanceViolationsAsync();
    }
}