using EaglesNestMobileApp.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Contracts
{
    public interface IAzureService
    {
        Task InitLocalStore();
        Task<List<Assignment>> GetAssignmentsAsync();
        Task<List<Course>> GetCoursesAsync();
        Task<List<FourWindsItem>> GetFourWindsItemsAsync();
        Task<List<VarsityItem>> GetVarsityItemsAsync();
        Task<List<GrabAndGoItem>> GetGrabAndGoItemsAsync();
        Task SyncAsync(bool pullData = false);
    }
}
