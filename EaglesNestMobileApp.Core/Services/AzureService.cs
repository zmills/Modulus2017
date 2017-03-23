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
        /* Private member variables                                          */
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

        /*********************************************************************/
        /*   Initialize the database and specify locally persistent tables   */
        /*********************************************************************/
        public async Task InitLocalStore()
        {
            if (!_client.SyncContext.IsInitialized)
            {
                _eagleDatabase = new MobileServiceSQLiteStore(App.DatabaseName);

                /* Define all the tables                                     */
                DefineTables();

                /* Create the sync handler and specify tables to exclude     */
                _syncHandler = new SyncHandler();
                _syncHandler.Exclude<LocalToken>();

                /* Sync or something                                         */
                await _client.SyncContext.InitializeAsync(_eagleDatabase);

                /* Get references to the tables                              */
                GetReferences();
            }
        }

        /*********************************************************************/
        /*                           Sync the data                           */
        /*********************************************************************/
        public async Task SyncAsync(bool pullData = false)
        {
            /* Local token is being used to make calls for "personal" data   */
            /* Try to sync the local store with the remote database          */
            try
            {
                await _client.SyncContext.PushAsync();
                if (pullData)
                {
                    /* Pull down student related tables                      */
                    await _assignmentTable.PullAsync("allAssignments",
                        _assignmentTable.Where(assignment => 
                            assignment.StudentId == App.Locator.User.Id));

                    await _courseTable.PullAsync("allCourses",
                        _courseTable.Where(course => 
                            course.StudentId == App.Locator.User.Id));

                    await _studentTable.PullAsync("currentStudent",
                        _studentTable.Where(student => 
                            student.Id == App.Locator.User.Id));

                    /* Pull down non student related tables                 */
                    await _fourWindsTable.PullAsync("allFourWindsItems",
                        _fourWindsTable.CreateQuery());
                    await _varsityTable.PullAsync("allVarsityItems", 
                        _varsityTable.CreateQuery());
                    await _grabAndGoTable.PullAsync("allGrabAndGoItems",
                        _grabAndGoTable.CreateQuery());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message} in SyncAsync {ex.Source} {ex.HResult}");
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

        /*********************************************************************/
        /*                        Get student assignments                    */
        /*********************************************************************/
        public async Task<List<Assignment>> GetAssignmentsAsync()
        {
            return await _assignmentTable.ToListAsync();
        }

        /*********************************************************************/
        /*                         Get student courses                       */
        /*********************************************************************/
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _courseTable.ToListAsync();
        }

        /*********************************************************************/
        /*                       Get the Four Winds items                    */
        /*********************************************************************/
        public async Task<List<FourWindsItem>> GetFourWindsItemsAsync()
        {
            return await _fourWindsTable.ToListAsync();
        }

        /*********************************************************************/
        /*                         Get the Varsity items                     */
        /*********************************************************************/
        public async Task<List<VarsityItem>> GetVarsityItemsAsync()
        {
            return await _varsityTable.ToListAsync();
        }

        /*********************************************************************/
        /*                      Get the Grab and Go items                    */
        /*********************************************************************/
        public async Task<List<GrabAndGoItem>> GetGrabAndGoItemsAsync()
        {
            return await _grabAndGoTable.ToListAsync();
        }

        /*********************************************************************/
        /*                       Get the logged in user                      */
        /*********************************************************************/
        // DATABASE MUST BE PURGED ON WHEN USER LOGS OUT
        public async Task<LocalToken> GetLocalTokenAsync()
        {
            List<LocalToken> list = await _localTokenTable.ToListAsync();
            return list[0];
        }

        /*********************************************************************/
        /*                    Get the Azure login credentials                */
        /*********************************************************************/
        // DATABASE MUST BE PURGED ON WHEN USER LOGS OUT
        public async Task<AzureToken> GetAzureTokenAsync(LocalToken currentUser)
        {
            await _azureTokenTable.PullAsync("loginUser", _azureTokenTable.Where(user => user.Id == currentUser.Id));

            var list = await _azureTokenTable.Where(user => user.Id == currentUser.Id).ToListAsync();
            return list[0];
        }

        /*********************************************************************/
        /*                     Get the student information                   */
        /*********************************************************************/
        public async Task<Student> GetStudentAsync()
        {
            List<Student> list = await _studentTable.ToListAsync();
            return list[0];
        }

        /*********************************************************************/
        /*                      Insert into local store                      */
        /*********************************************************************/
        public async Task InsertLocalTokenAsync(LocalToken user)
        {
            await _localTokenTable.InsertAsync(user);
        }
    }
}