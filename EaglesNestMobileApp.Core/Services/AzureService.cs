/*****************************************************************************/
/*                               AzureService                                */
/*                                                                           */
/*                                                                           */
/*****************************************************************************/
using EaglesNestMobileApp.Core.Contracts;
using EaglesNestMobileApp.Core.Helpers;
using EaglesNestMobileApp.Core.Model;
using EaglesNestMobileApp.Core.Model.Campus;
using EaglesNestMobileApp.Core.Model.Home;
using EaglesNestMobileApp.Core.Model.Personal;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Java.IO;
using System.Threading.Tasks;
using EaglesNestMobileApp.Core.Model.Academics;

namespace EaglesNestMobileApp.Core.Services
{
    public class AzureService : IAzureService
    {
        /* Private member variables                                          */
        private MobileServiceClient _client = App.Client;
        private MobileServiceSQLiteStore _eagleDatabase;
        private IMobileServiceSyncTable<Assignment>      _assignmentTable;
        private IMobileServiceSyncTable<Course>          _courseTable;
        private IMobileServiceSyncTable<Events>          _eventsTable;
        private IMobileServiceSyncTable<EventSlot>       _eventSignupTable;
        private IMobileServiceSyncTable<StudentEvent>    _studentEventTable;
        private IMobileServiceSyncTable<Offense>         _offenseTable;
        private IMobileServiceSyncTable<OffenseCategory> _offenseCategoryTable;
        private IMobileServiceSyncTable<FourWindsItem>   _fourWindsTable;
        private IMobileServiceSyncTable<VarsityItem>     _varsityTable;
        private IMobileServiceSyncTable<GrabAndGoItem>   _grabAndGoTable;
        private IMobileServiceSyncTable<LocalToken>      _localTokenTable;
        private IMobileServiceSyncTable<AzureToken>      _azureTokenTable;
        private IMobileServiceSyncTable<Student>         _studentTable;
        private IMobileServiceSyncTable<ClassAttendance> _attendanceTable;
        private IMobileServiceSyncTable<ProfessorTimes>   _professorTable;
        private SyncHandler _syncHandler;
        public string CurrentUser { get; set; }

        /*********************************************************************/
        /*   Initialize the database and specify locally persistent tables   */
        /*********************************************************************/
        public async Task InitLocalStore()
        {
            _eagleDatabase = new MobileServiceSQLiteStore(App.DatabaseName);

            //_eagleDatabase = MobileServiceClient.EnsureFileExists(App.DatabaseName);

            /* Define all the tables                                     */
            DefineTables();

            /* Create the sync handler and specify tables to exclude     */
            _syncHandler = new SyncHandler();
            _syncHandler.Exclude<LocalToken>();

            /* Sync or something                                         */
            await _client.SyncContext.InitializeAsync(_eagleDatabase,
                _syncHandler);

            /* Get references to the tables                              */
            GetReferences();

            CurrentUser = App.Locator.User;
        }

        public async Task InitExistingLocalStore()
        {
            await InitLocalStore();
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
                            assignment.StudentId == CurrentUser));

                    await _courseTable.PullAsync("allCourses",
                        _courseTable.Where(course =>
                            course.StudentId == CurrentUser));

                    await _studentTable.PullAsync("currentStudent",
                        _studentTable.Where(student =>
                            student.Id == CurrentUser));

                    await _attendanceTable.PullAsync("AllAttendanceViolations",
                        _attendanceTable.Where(attendance =>
                            attendance.StudentId == CurrentUser));

                    await _offenseTable.PullAsync("AllStudentCourtOffenses",
                        _offenseTable.Where(offense =>
                            offense.StudentId == CurrentUser));

                    await _eventSignupTable.PullAsync("SignedUpevents",
                        _eventSignupTable.Where(eventSignup =>
                            eventSignup.StudentId == CurrentUser));

                    await _studentEventTable.PullAsync("allStudentEvents",
                      _studentEventTable.Where(studentEvent =>
                            studentEvent.StudentId == CurrentUser));

                    await _offenseCategoryTable.PullAsync("AllStudentCourtOffenseCategories",
                        _offenseCategoryTable.Where(offense =>
                            offense.StudentId == CurrentUser));

                    PullOptions data = new PullOptions { MaxPageSize = 150 };

                    await _fourWindsTable.PullAsync("allFourWindsItems",
                       _fourWindsTable.CreateQuery(), data);

                    await _varsityTable.PullAsync("allVarsityItems",
                        _varsityTable.CreateQuery());

                    await _grabAndGoTable.PullAsync("allGrabAndGoItems",
                        _grabAndGoTable.CreateQuery());

                    await _eventsTable.PullAsync("allEvents",
                        _eventsTable.CreateQuery());


                    var list = await _studentEventTable.ToCollectionAsync();
                    Debug.WriteLine($"\n\n\nStudent events: {list.Count}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message} in SyncAsync");
                Debug.WriteLine("Please check your Internet connection!");
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
            _eagleDatabase.DefineTable<Events>();
            _eagleDatabase.DefineTable<StudentEvent>();
            _eagleDatabase.DefineTable<EventSlot>();
            _eagleDatabase.DefineTable<ClassAttendance>();
            _eagleDatabase.DefineTable<Offense>();
            _eagleDatabase.DefineTable<OffenseCategory>();
            _eagleDatabase.DefineTable<ProfessorTimes>();
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
            _eventsTable = _client.GetSyncTable<Events>();
            _studentEventTable = _client.GetSyncTable<StudentEvent>();
            _eventSignupTable = _client.GetSyncTable<EventSlot>();
            _attendanceTable = _client.GetSyncTable<ClassAttendance>();
            _offenseTable = _client.GetSyncTable<Offense>();
            _offenseCategoryTable = _client.GetSyncTable<OffenseCategory>();
            _professorTable       = _client.GetSyncTable<ProfessorTimes>();
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
        /* The database must be purged once the user logs out                */
        public async Task<LocalToken> GetLocalTokenAsync()
        {
            var _localToken = await _localTokenTable.ToListAsync();

            /* Return the current user so that the user does not need to log */
            /* back in if they are still logged in                           */
            if (_localToken.Count != 0)
                return _localToken[0];
            else
                return null;
        }

        /*********************************************************************/
        /*                    Get the Azure login credentials                */
        /*********************************************************************/
        public async Task<AzureToken> GetAzureTokenAsync(LocalToken currentUser)
        {

            //APPARENTLY THIS DOES NOT WORK PROPERLY
            await _azureTokenTable.PullAsync("loginUser",
                _azureTokenTable.Where(user => user.Id == currentUser.Id));

            List<AzureToken> _tokenList = await _azureTokenTable.Where(user =>
                user.Id == currentUser.Id).ToListAsync();

            //DELETE THE LOGIN INFORMATION
            await _azureTokenTable.PurgeAsync();
            return _tokenList[0];
        }

        /*********************************************************************/
        /*                     Get the student information                   */
        /*********************************************************************/
        public async Task<Student> GetStudentAsync()
        {
            List<Student> _students = await _studentTable.ToListAsync();
            return _students[0];
        }

        /*********************************************************************/
        /*                      Insert into local store                      */
        /*********************************************************************/
        public async Task InsertLocalTokenAsync(LocalToken user)
        {
            await _localTokenTable.InsertAsync(user);
            await SyncAsync();
        }

        /*********************************************************************/
        /*                              Get Events                           */
        /*********************************************************************/
        public async Task<List<Events>> GetEventsAsync()
        {
            return await _eventsTable.ToListAsync();
        }

        /*********************************************************************/
        /*                     Get student schedule events                   */
        /*********************************************************************/
        public async Task<List<StudentEvent>> GetScheduleEventsAsync()
        {
            return await _studentEventTable.ToListAsync();
        }

        /*********************************************************************/
        /*                      Get attendance violations                    */
        /*********************************************************************/
        public async Task<List<ClassAttendance>> GetAttendanceViolationsAsync()
        {
            return await _attendanceTable.ToListAsync();
        }

        /*********************************************************************/
        /*                      Get student court offenses                   */
        /*********************************************************************/
        public async Task<List<Offense>> GetStudentCourtOffensesAsync()
        {
            return await _offenseTable.ToListAsync();
        }

        /*********************************************************************/
        /*                 Get student court category totals                 */
        /*********************************************************************/
        public async Task<List<OffenseCategory>> GetStudentCourtCategoriesAsync()
        {
            return await _offenseCategoryTable.ToListAsync();
        }

        /*********************************************************************/
        /*                 Get student the signed up events                  */
        /*********************************************************************/
        public async Task<List<EventSlot>> GetEventSignupAsync()
        {
            return await _eventSignupTable.ToListAsync();
        }

        public async Task InsertEventAsync(EventSlot eventSignup)
        {
            await _eventSignupTable.InsertAsync(eventSignup);
            await SyncAsync(true);
        }

        /*********************************************************************/
        /*                      Insert into local store                      */
        /*********************************************************************/
        public void PurgeDatabaseAsync()
        {
            CurrentUser = null;
            _assignmentTable = null;
            _courseTable = null;
            _eventsTable = null;
            _eventSignupTable = null;
            _studentEventTable = null;
            _offenseTable = null;
            _offenseCategoryTable = null;
            _fourWindsTable = null;
            _varsityTable = null;
            _grabAndGoTable = null;
            _localTokenTable = null;
            _azureTokenTable = null;
            _studentTable = null;
            _attendanceTable = null;
            _eagleDatabase = null;
            _syncHandler = null;
        }
    }
}