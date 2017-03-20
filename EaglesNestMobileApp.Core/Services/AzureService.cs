/*****************************************************************************/
/*                               AzureService                                */
/*                                                                           */
/*                                                                           */
/*****************************************************************************/

using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Helpers;
using EaglesNestMobileApp.Core.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EaglesNestMobileApp.Core.Services
{
    public class AzureService : IAzureService
    {
        private MobileServiceClient _client = App.Client;
        private MobileServiceSQLiteStore _eagleDatabase;
        private IMobileServiceSyncTable<Assignment> _assignmentTable;
        private IMobileServiceSyncTable<Course> _courseTable;
        private IMobileServiceSyncTable<FourWindsItem> _fourWindsTable;
        private IMobileServiceSyncTable<VarsityItem> _varsityTable;
        private IMobileServiceSyncTable<GrabAndGoItem> _grabAndGoTable;
        private IMobileServiceSyncTable<LocalToken> _localTokenTable;
        private IMobileServiceSyncTable<AzureToken> _azureTokenTable;
        private IMobileServiceSyncTable<Student> _studentTable;
        private SyncHandler _syncHandler;

        public async Task InitLocalStore()
        {
            if (!_client.SyncContext.IsInitialized)
            {
                _eagleDatabase = new MobileServiceSQLiteStore(App.DatabaseName);

                /* Define all the tables                                     */
                DefineTables();

                _syncHandler = new SyncHandler();
                _syncHandler.Exclude<LocalToken>();

                /* Sync or something                                         */
                await _client.SyncContext.InitializeAsync(_eagleDatabase);

                /* Get references to the tables                              */
                GetReferences();

                await SyncAsync(pullData: true);
            }
        }

        /* USE LOCAL TOKEN YOU FOOL!!!!!                                     */
        public async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await _client.SyncContext.PushAsync();
                if (pullData)
                {
                    await _assignmentTable.PullAsync("allAssignments", _assignmentTable.Where(assignment => assignment.StudentId == "130000"));
                    // await _courseTable.PullAsync("allCourses", _courseTable.Where(course => course.StudentId == "130000"));
                    await _fourWindsTable.PullAsync("allFourWindsItems", _fourWindsTable.CreateQuery());
                    await _varsityTable.PullAsync("allVarsityItems", _varsityTable.CreateQuery());
                    await _grabAndGoTable.PullAsync("allGrabAndGoItems", _grabAndGoTable.CreateQuery());
                    // add awaits
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message + "\nSyncAsync\n" + e.Source + e.HResult);
            }
        }

        /*********************************************************************/
        /*                          Define the Tables                        */
        /*********************************************************************/
        public void DefineTables()
        {
            _eagleDatabase.DefineTable<Assignment>();
            _eagleDatabase.DefineTable<Course>();
            _eagleDatabase.DefineTable<FourWindsItem>();
            _eagleDatabase.DefineTable<VarsityItem>();
            _eagleDatabase.DefineTable<GrabAndGoItem>();
            _eagleDatabase.DefineTable<Student>();
            _eagleDatabase.DefineTable<AzureToken>();
            _eagleDatabase.DefineTable<LocalToken>();
        }

        /*********************************************************************/
        /*                         Get table references                      */
        /*********************************************************************/
        public void GetReferences()
        {
            _assignmentTable = _client.GetSyncTable<Assignment>();
            _courseTable = _client.GetSyncTable<Course>();
            _fourWindsTable = _client.GetSyncTable<FourWindsItem>();
            _varsityTable = _client.GetSyncTable<VarsityItem>();
            _grabAndGoTable = _client.GetSyncTable<GrabAndGoItem>();
            _studentTable = _client.GetSyncTable<Student>();
            _localTokenTable = _client.GetSyncTable<LocalToken>();
            _azureTokenTable = _client.GetSyncTable<AzureToken>();
        }

        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _assignmentTable.ToListAsync();
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _courseTable.ToListAsync();
        }

        public async Task<List<FourWindsItem>> GetFourWindsItemsAsync()
        {
            return await _fourWindsTable.ToListAsync();
        }

        public async Task<List<VarsityItem>> GetVarsityItemsAsync()
        {
            return await _varsityTable.ToListAsync();
        }

        public async Task<List<GrabAndGoItem>> GetGrabAndGoItemsAsync()
        {
            return await _grabAndGoTable.ToListAsync();
        }

        // DATABASE MUST BE PURGED ON WHEN USER LOGS OUT
        public async Task<LocalToken> GetLocalTokenAsync()
        {
            List<LocalToken> list = await _localTokenTable.ToListAsync();
            return list[0];
        }

        // DATABASE MUST BE PURGED ON WHEN USER LOGS OUT
        public async Task<AzureToken> GetAzureTokenAsync()
        {
            List<AzureToken> list = await _azureTokenTable.ToListAsync();
            return list[0];
        }

        // WE NEED TO CONSIDER WHETHER TO PULL LOCAL TOKEN FROM HERE
        // PASS THE STUDENT ID TO THE METHOD. SAME FOR CLASSES AND ASSIGNMENT
        // THAT WOULD BE LESS COUPLING, SINCE THE DATA LAYER DOESN'T NECESSARILY
        // NEED TO KNOW WHO IS LOGGED IN. IT WOULD MAKE THE CLASS MORE VERSATILE.
        // ALSO, WE COULD CALL THE SPECIFIC SYNCASYNCPART OF THIS TABLE HERE
        // INSTEAD OF CALLING IT FROM THE VIEWMODEL EVERY TIME WE NEED A TINY
        // AMOUNT OF DATA. THAT COULD GET RID OF SOME PERFORMANCE ISSUES
        // PLUS HOW DO WE READ THE LOCAL TOKEN BEFORE WE LOGIN AND INITIALIZE THE
        // LOCAL STORE???
        public async Task<Student> GetStudentAsync()
        {
            List<Student> list = await _studentTable.ToListAsync();
            return list[0];
        }
    }
}
