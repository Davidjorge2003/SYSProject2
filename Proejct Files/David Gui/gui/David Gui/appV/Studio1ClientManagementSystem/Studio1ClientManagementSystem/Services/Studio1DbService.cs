using SQLite;
using Studio1ClientManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studio1ClientManagementSystem.Services
{
    public static class Studio1DbService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            //Singleton if statement
            if (db != null)
                return;
            
            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            
            //Open db connection
            db = new SQLiteAsyncConnection(databasePath);

            //Create db tables
            await db.CreateTablesAsync<Admin, _Class, ClassDate, Client, ClientClassPair>();
            await db.CreateTablesAsync<ClientDailyLog, Employee, HealthRecord, Instructor, Note>();
            await db.CreateTablesAsync<NotePermission, PaymentRecord, Prescription, UserLog>();
        }


        public static class AdminService
        {
            public static async Task<Admin> AddAdmin(string adminUsername, string temporaryPasswordVariableA)
            {
                await Init();
                var admin = new Admin()
                {
                    adminUsername = adminUsername,
                    temporaryPasswordVariableA = temporaryPasswordVariableA
                };

                //Insert data into table
                await db.InsertAsync(admin);

                //Return created object
                return admin;
            }
            public static async Task RemoveAdmin(int adminId)
            {
                await Init();

                //Delete data found using "id"
                await db.DeleteAsync<Client>(adminId);
            }
            public static async Task<IEnumerable<Admin>> GetAllAdmins()
            {
                await Init();

                //Return all data in specified table
                var admins = await db.Table<Admin>().ToListAsync();
                return admins;
            }

        }

        public static class ClassService
        {
            public static async Task<_Class> AddClass(string title, string description, TimeOnly startTime, TimeOnly endTime)
            {
                await Init();
                var _class = new _Class()
                {
                    title = title,
                    description = description,
                    startTime = startTime,
                    endTime = endTime   
                };

                //Insert data into table
                await db.InsertAsync(_class);

                //Return created object
                return _class;
            }
            public static async Task RemoveClass(int classId)
            {
                await Init();

                //Delete data found using "id"
                await db.DeleteAsync<_Class>(classId);
            }
            public static async Task<IEnumerable<_Class>> GetAllClasses()
            {
                await Init();

                //Return all data in specified table
                var _classes = await db.Table<_Class>().ToListAsync();
                return _classes;
            }
        }



        public static class ClassDateService
        {
            public static async Task<ClassDate> AddClassDate(DateOnly classDate)
            {
                await Init();
                var ClassDate = new ClassDate()
                {
                    classDate = classDate
                };

                //Insert data into table
                await db.InsertAsync(ClassDate);

                //Return created object
                return ClassDate;
            }
            public static async Task Remove_ClassDate(int datePairId)
            {
                await Init();

                //Delete data found using "id"
                await db.DeleteAsync<ClassDate>(datePairId);
            }
            public static async Task<IEnumerable<ClassDate>> GetAllClassDates()
            {
                await Init();

                //Return all data in specified table
                var classDates = await db.Table<ClassDate>().ToListAsync();
                return classDates;
            }
        }

        public static class ClientService
        {
            public static async Task<Client> AddClient(string fName, string lName, string address, string city, string postalCode,
            string telephoneNumber, DateTime dateOfBirth, string fitnessGoals,
            DateTime membershipExpirationDate, DateTime membershipCreationDate)
            {
                await Init();
                var client = new Client()
                {
                    fName = fName,
                    lName = lName,
                    address = address,
                    city = city,
                    postalCode = postalCode,
                    telephoneNumber = telephoneNumber,
                    dateOfBirth = dateOfBirth,
                    fitnessGoals = fitnessGoals,
                    membershipExpirationDate = membershipExpirationDate,
                    membershipCreationDate = membershipCreationDate
                };

                //Insert data into table
                await db.InsertAsync(client);

                //Return created object
                return client;
            }

            public static async Task RemoveClient(int id)
            {
                await Init();

                //Delete data found using "id"
                await db.DeleteAsync<Client>(id);
            }

            public static async Task<IEnumerable<Client>> GetAllClients()
            {
                await Init();

                //Return all data in specified table
                var clients = await db.Table<Client>().ToListAsync();
                return clients;
            }

            public static async Task<Client> GetClientById(int Id)
            {
                await Init();

                //Retrieve a client based on Id
                var client = await db.Table<Client>().Where(c => c.Id == Id).FirstOrDefaultAsync();

                //Return client if found, otherwise return null
                return client;
            }
        }


        public static class ClientClassPairService
        {
            public static async Task<ClientClassPair> AddClientClassPair(int Id, int classId)
            {
                await Init();

                var pair = new ClientClassPair()
                {
                    Id = Id,
                    classId = classId
                };

                await db.InsertAsync(pair);

                return pair;
            }

            public static async Task RemoveClientClassPair(int Id, int classId)
            {
                await Init();

                //Find the matching record
                var pair = await db.Table<ClientClassPair>()
                                   .Where(x => x.Id == Id && x.classId == classId)
                                   .FirstOrDefaultAsync();

                if (pair != null)
                {
                    //Delete the record
                    await db.DeleteAsync<ClientClassPair>(pair);
                }
            }

            public static async Task<IEnumerable<ClientClassPair>> GetAllClientClassPairs()
            {
                await Init();

                //Return all data in specified table
                var clientClassPairs = await db.Table<ClientClassPair>().ToListAsync();
                return clientClassPairs;
            }
        }



        //!This class's features are currently under developement
        public static class ClientDailyLogService
        {
            public static async Task<ClientDailyLog> AddClientDailyLog(int Id)
            {
                await Init();

                var client = await ClientService.GetClientById(Id);

                if (client == null)
                    throw new Exception("Client not found");

                var dailyLog = new ClientDailyLog()
                {
                    Client = client,
                };

                await db.InsertAsync(dailyLog);

                return dailyLog;
            }
            public static async void StartDailyCleanup()
            {
                await Init();

                var now = DateTime.Now;
                var nextMidnight = now.AddDays(1).Date;
                var timeUntilMidnight = nextMidnight - now;

                //Schedule daily cleanup to run at midnight
                var timer = new System.Timers.Timer(timeUntilMidnight.TotalMilliseconds);
                timer.Elapsed += async (sender, e) =>
                {
                    //Delete all entries
                    await db.DeleteAllAsync<ClientDailyLog>();

                    //Stop the timer
                    ((System.Timers.Timer)sender).Stop();
                };
                timer.Start();
            }
            public static async Task<IEnumerable<ClientDailyLog>> GetAllClientDailyLogs()
            {
                await Init();

                //Return all data in specified table
                var clientDailyLogs = await db.Table<ClientDailyLog>().ToListAsync();
                return clientDailyLogs;
            }

        }



        public static class EmployeeService
        {
            public static async Task<Employee> AddEmployee(string employeeUsername, string temporaryPasswordVariableE)
            {
                await Init();
                var employee = new Employee()
                {
                    employeeUsername = employeeUsername,
                    temporaryPasswordVariableE = temporaryPasswordVariableE
                };

                //Insert data into table
                await db.InsertAsync(employee);

                //Return created object
                return employee;
            }
            public static async Task RemoveEmployee(int employeeId)
            {
                await Init();

                //Delete data found using "id"
                await db.DeleteAsync<Client>(employeeId);
            }
            public static async Task<IEnumerable<Employee>> GetAllEmployees()
            {
                await Init();

                //Return all data in specified table
                var employees = await db.Table<Employee>().ToListAsync();
                return employees;
            }
        }


        public static class HealthRecordService
        {
            public static async Task<HealthRecord> AddHealthRecord(bool hasHeartConditions, bool hasChestPain, bool hasDizzinessOrNausea, 
                bool hasJointOrBonePain, string specifications)
            {
                await Init();
                var healthRecord = new HealthRecord()
                {
                    hasHeartConditions = hasHeartConditions,
                    hasChestPain = hasChestPain,
                    hasDizzinessOrNausea = hasDizzinessOrNausea,
                    specifications = specifications
                };

                //Insert data into table
                await db.InsertAsync(healthRecord);

                //Return created object
                return healthRecord;
            }
            public static async Task RemoveHealthRecord(int healthId)
            {
                await Init();

                //Delete data found using "id"
                await db.DeleteAsync<Client>(healthId);
            }
            public static async Task<IEnumerable<HealthRecord>> GetAllHealthRecords()
            {
                await Init();

                //Return all data in specified table
                var healthRecords = await db.Table<HealthRecord>().ToListAsync();
                return healthRecords;
            }
        }


        public static class InstructorService
        {
            public static async Task<Instructor> AddInstructor(string instructorName)
            {
                await Init();

                var instructor = new Instructor()
                {
                    instructorName = instructorName
                };

                await db.InsertAsync(instructor);

                return instructor;
            }
            public static async Task RemoveInstructor(int instructorPairId)
            {
                await Init();

                await db.DeleteAsync<Instructor>(instructorPairId);
            }

            public static async Task<IEnumerable<Instructor>> GetAllInstructors()
            {
                await Init();

                var instructors = await db.Table<Instructor>().ToListAsync();
                return instructors;
            }
        }


        public static class NoteService
        {
            public static async Task<Note> AddNote(DateOnly noteDeadline)
            {
                await Init();

                var note = new Note()
                {
                    noteDeadline = noteDeadline
                };

                await db.InsertAsync(note);

                return note;
            }

            public static async Task RemoveNote(int noteId)
            {
                await Init(); 
                await db.DeleteAsync<Note>(noteId);
            }

            public static async Task<IEnumerable<Note>> GetAllNotes()
            {
                await Init();

                var notes = await db.Table<Note>().ToListAsync();
                return notes;
            }
        }

        public static class NotePermissionService
        {
            public static async Task<NotePermission> AddNotePermission(bool viewPermission)
            {
                await Init();

                var notePemission = new NotePermission()
                {
                    viewPermission = viewPermission
                };

                await db.InsertAsync(notePemission);
                return notePemission;
            }

            public static async Task RemoveNotePermission(int permissionId)
            {
                await Init();
                await db.DeleteAsync<NotePermission>(permissionId);
            }

            public static async Task<IEnumerable<NotePermission>> GetAllNotePermissions()
            {
                await Init();

                var notePermissions = await db.Table<NotePermission>().ToListAsync();
                return notePermissions;
            }
        }

        public static class PaymentRecordService
        {
            public static async Task<PaymentRecord> AddPaymentRecord(string paymentMethod, string cardholderName, string cardNumber, 
                DateOnly expirationDate, string cvc, decimal membershipFee, string membershipType, decimal membershipAmount)
            {
                await Init();

                var paymentRecord = new PaymentRecord()
                {
                    paymentMethod = paymentMethod,
                    cardholderName = cardholderName,
                    cardNumber = cardNumber,
                    expirationDate = expirationDate,
                    cvc = cvc,
                    membershipFee = membershipFee,
                    membershipType = membershipType,
                    membershipAmount = membershipAmount

                };

                await db.InsertAsync(paymentRecord);
                return paymentRecord;
            }

            public static async Task RemovePaymentRecord(int paymentId)
            {
                await Init();
                await db.DeleteAsync<PaymentRecord>(paymentId);
            }

            public static async Task<IEnumerable<PaymentRecord>> GetAllPaymentRecords()
            {
                await Init();

                var paymentRecords = await db.Table<PaymentRecord>().ToListAsync();
                return paymentRecords;
            }
        }



        public static class PrescriptionService
        {
            public static async Task<Prescription> AddPrescription(string prescriptionName)
            {
                await Init();
                var prescription = new Prescription()
                {
                    prescriptionName = prescriptionName
                };

                await db.InsertAsync(prescription);
                return prescription;
            }

            public static async Task RemovePrescription(int prescriptionId)
            {
                await Init();
                await db.DeleteAsync(prescriptionId);
            }

            public static async Task<IEnumerable<Prescription>> GetAllPrescriptions()
            {
                await Init();

                var prescriptions = await db.Table<Prescription>().ToListAsync();
                return prescriptions;
            }
        }


        //!This classe's features are still under developement
        public static class UserLogService
        {
            public static async Task<UserLog> AddUserLog(DateTime timeOfLogin, string activity)
            {
                await Init();
                var userLog = new UserLog()
                {
                    timeOfLogin = timeOfLogin,
                    activity = activity
                };

                await db.InsertAsync(userLog);
                return userLog;
            }

            public static async Task RemoveUserLog(int loginId)
            {
                await Init();
                await db.DeleteAsync(loginId);
            }

            public static async Task<IEnumerable<UserLog>> GetAllUserLogs()
            {
                await Init();

                var userLogs = await db.Table<UserLog>().ToListAsync();
                return userLogs;
            }
        }

    }
   
}
