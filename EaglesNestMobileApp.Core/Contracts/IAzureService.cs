using EaglesNestMobileApp.Core.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EaglesNestMobileApp.Core.Model.Personal;
using System.Collections.Generic;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface IAzureService
    {
        Task InitLocalStore();
        Task<ObservableCollection<Assignment>> GetAssignmentsAsync();
        Task<ObservableCollection<Course>> GetCoursesAsync();
        Task<List<FourWindsItem>> GetFourWindsItemsAsync();
        Task<ObservableCollection<VarsityItem>> GetVarsityItemsAsync();
        Task<ObservableCollection<GrabAndGoItem>> GetGrabAndGoItemsAsync();
        Task<LocalToken> GetLocalTokenAsync();
        Task<AzureToken> GetAzureTokenAsync(LocalToken user);
        Task<Student> GetStudentAsync();
        Task InsertLocalTokenAsync(LocalToken user);
        Task PurgeDatabaseAsync();
        Task SyncAsync(bool pullData = false);
        //Task<ObservableCollection<AttendanceViolation>> GetAttendanceViolationsAsync();
    }
}