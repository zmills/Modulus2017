/*****************************************************************************/
/*                               AzureService                                */
/*                                                                           */
/*                                                                           */
/*****************************************************************************/

using EaglesNestMobileApp.Core.Contracts;
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

        public async Task InitLocalStore()
        {
            if (!_client.SyncContext.IsInitialized)
            {
                _eagleDatabase = new MobileServiceSQLiteStore(App.DatabaseName);

                /* Define all the tables                                     */
                DefineTables();

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
    }
}
