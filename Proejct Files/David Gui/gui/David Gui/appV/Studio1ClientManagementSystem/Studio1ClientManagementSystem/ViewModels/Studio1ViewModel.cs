using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Studio1ClientManagementSystem.Models;
using Studio1ClientManagementSystem.Services;
//using GalaSoft.MvvmLight;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Studio1ClientManagementSystem.ViewModels
{
    public class Studio1ViewModel //ViewModelBase
    {


        public class AdminViewModel
        {
            private ObservableCollection<Admin> _admins;
            public ObservableCollection<Admin> Admins
            {
                get => _admins;
                set
                {
                    if (_admins != value)
                    {
                        _admins = value;
                        OnPropertyChanged(nameof(Admins));
                    }
                }
            }

            public async Task LoadAdmins()
            {
                var result = await Studio1DbService.AdminService.GetAllAdmins();
                Admins = new ObservableCollection<Admin>(result);
            }

            public async Task AddAdmin(string adminUsername, string temporaryPasswordVariableA)
            {
                await Studio1DbService.AdminService.AddAdmin(adminUsername, temporaryPasswordVariableA);
                await LoadAdmins();
            }

            public async Task RemoveAdmin(int adminId)
            {
                await Studio1DbService.AdminService.RemoveAdmin(adminId);
                await LoadAdmins();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }




        public class ClassViewModel
        {
            private ObservableCollection<_Class> _classes;
            public ObservableCollection<_Class> Classes
            {
                get => _classes;
                set
                {
                    if (_classes != value)
                    {
                        _classes = value;
                        OnPropertyChanged(nameof(Classes));
                    }
                }
            }

            public async Task LoadClasses()
            {
                var result = await Studio1DbService.ClassService.GetAllClasses();
                Classes = new ObservableCollection<_Class>(result);
            }

            public async Task AddClass(string title, string description, TimeOnly startTime, TimeOnly endTime)
            {
                await Studio1DbService.ClassService.AddClass(title, description, startTime, endTime);
                await LoadClasses();
            }

            public async Task RemoveClass(int classId)
            {
                await Studio1DbService.ClassService.RemoveClass(classId);
                await LoadClasses();
            }

            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class ClassDateViewModel
        {
            private ObservableCollection<ClassDate> _classDates;
            public ObservableCollection<ClassDate> ClassDates
            {
                get => _classDates;
                set
                {
                    if (_classDates != value)
                    {
                        _classDates = value;
                        OnPropertyChanged(nameof(ClassDates));
                    }
                }
            }

            public async Task LoadClassDates()
            {
                var result = await Studio1DbService.ClassDateService.GetAllClassDates();
                ClassDates = new ObservableCollection<ClassDate>(result);
            }

            public async Task AddClassDate(DateOnly classDate)
            {
                await Studio1DbService.ClassDateService.AddClassDate(classDate);
                await LoadClassDates();
            }

            public async Task RemoveClassDate(int datePairId)
            {
                await Studio1DbService.ClassDateService.Remove_ClassDate(datePairId);
                await LoadClassDates();
            }

            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class ClientViewModel
        {
          
            private ObservableCollection<Client> _clients;
            public ObservableCollection<Client> Clients
            {
                get => _clients;
                set
                {
                    if (_clients != value)
                    {
                        _clients = value;
                        OnPropertyChanged(nameof(Clients));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadClients()
            {
                var result = await Studio1DbService.ClientService.GetAllClients();
                Clients = new ObservableCollection<Client>(result);
            }

            //Define public method to add a client from the database
            public async Task AddClient(string fName, string lName, string address, string city, string postalCode,
            string telephoneNumber, DateTime dateOfBirth, string fitnessGoals,
            DateTime membershipExpirationDate, DateTime membershipCreationDate)
            {
                await Studio1DbService.ClientService.AddClient(fName, lName, address, city, postalCode, telephoneNumber,
                    dateOfBirth, fitnessGoals, membershipExpirationDate, membershipCreationDate);
                await LoadClients();
            }

            //Define public method to remove a client from the database
            public async Task RemoveClient(int Id)
            {
                await Studio1DbService.ClientService.RemoveClient(Id);
                await LoadClients();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class ClientClassPairViewModel
        {
            private ObservableCollection<ClientClassPair> _clientClassPairs;
            public ObservableCollection<ClientClassPair> ClientClassPairs
            {
                get => _clientClassPairs;
                set
                {
                    if (_clientClassPairs != value)
                    {
                        _clientClassPairs = value;
                        OnPropertyChanged(nameof(ClientClassPairs));
                    }
                }
            }

            public async Task LoadClientClassPairs()
            {
                var result = await Studio1DbService.ClientClassPairService.GetAllClientClassPairs();
                ClientClassPairs = new ObservableCollection<ClientClassPair>(result);
            }

            public async Task AddClientClassPair(int Id, int classId)
            {
                await Studio1DbService.ClientClassPairService.AddClientClassPair(Id, classId);
                await LoadClientClassPairs();
            }

            public async Task RemoveClientClassPair(int Id, int classId)
            {
                await Studio1DbService.ClientClassPairService.RemoveClientClassPair(Id, classId);
                await LoadClientClassPairs();
            }

            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        //!This class's features are still under developement
        public class ClientdailyLogViewModel
        {
            private ObservableCollection<ClientDailyLog> _clientDailyLog;
            public ObservableCollection<ClientDailyLog> ClientDailyLogs
            {
                get => _clientDailyLog;
                set
                {
                    if (_clientDailyLog != value)
                    {
                        _clientDailyLog = value;
                        OnPropertyChanged(nameof(ClientDailyLogs));
                    }
                }
            }

            public async Task LoadClientDailyLog()
            {
                var result = await Studio1DbService.ClientDailyLogService.GetAllClientDailyLogs();
                ClientDailyLogs = new ObservableCollection<ClientDailyLog>(result);
            }

            public async Task AddClientDailyLog(int Id)
            {
                await Studio1DbService.ClientDailyLogService.AddClientDailyLog(Id);
                await LoadClientDailyLog();
            }

            public async Task RemoveClientDailyLog()
            {
                Studio1DbService.ClientDailyLogService.StartDailyCleanup();
                await LoadClientDailyLog();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class EmployeeViewModel
        {
            private ObservableCollection<Employee> _employees;
            public ObservableCollection<Employee> Employees
            {
                get => _employees;
                set
                {
                    if (_employees != value)
                    {
                        _employees = value;
                        OnPropertyChanged(nameof(Employees));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadEmployees()
            {
                var result = await Studio1DbService.EmployeeService.GetAllEmployees();
                Employees = new ObservableCollection<Employee>(result);
            }

            //Define public method to add a client from the database
            public async Task AddEmployee(string employeeUsername, string temporaryPasswordVariableE)
            {
                await Studio1DbService.EmployeeService.AddEmployee(employeeUsername, temporaryPasswordVariableE);
                await LoadEmployees();
            }

            //Define public method to remove a client from the database
            public async Task RemoveEmployee(int employeeId)
            {
                await Studio1DbService.ClientService.RemoveClient(employeeId);
                await LoadEmployees();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class HealthRecordViewModel
        {
            private ObservableCollection<HealthRecord> _healthRecords;
            public ObservableCollection<HealthRecord> HealthRecords
            {
                get => _healthRecords;
                set
                {
                    if (_healthRecords != value)
                    {
                        _healthRecords = value;
                        OnPropertyChanged(nameof(HealthRecords));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadHealthRecords()
            {
                var result = await Studio1DbService.HealthRecordService.GetAllHealthRecords();
                HealthRecords = new ObservableCollection<HealthRecord>(result);
            }

            //Define public method to add a client from the database
            public async Task AddHealthRecord(bool hasHeartConditions, bool hasChestPain, bool hasDizzinessOrNausea,
                bool hasJointOrBonePain, string specifications)
            {
                await Studio1DbService.HealthRecordService.AddHealthRecord(hasHeartConditions, hasChestPain, hasDizzinessOrNausea, 
                    hasJointOrBonePain, specifications);
                await LoadHealthRecords();
            }

            //Define public method to remove a client from the database
            public async Task RemoveHealthRecord(int healthId)
            {
                await Studio1DbService.HealthRecordService.RemoveHealthRecord(healthId);
                await LoadHealthRecords();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class InstructorViewModel
        {
            private ObservableCollection<Instructor> _instructors;
            public ObservableCollection<Instructor> Instructors
            {
                get => _instructors;
                set
                {
                    if (_instructors != value)
                    {
                        _instructors = value;
                        OnPropertyChanged(nameof(Instructors));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadInstructors()
            {
                var result = await Studio1DbService.InstructorService.GetAllInstructors();
                Instructors = new ObservableCollection<Instructor>(result);
            }

            //Define public method to add a client from the database
            public async Task AddInstructor(string instructorName)
            {
                await Studio1DbService.InstructorService.AddInstructor(instructorName);
                await LoadInstructors();
            }

            //Define public method to remove a client from the database
            public async Task RemoveInstructor(int instructorPairId)
            {
                await Studio1DbService.InstructorService.RemoveInstructor(instructorPairId);
                await LoadInstructors();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public class NoteViewModel
        {
            private ObservableCollection<Note> _notes;
            public ObservableCollection<Note> Notes
            {
                get => _notes;
                set
                {
                    if (_notes != value)
                    {
                        _notes = value;
                        OnPropertyChanged(nameof(Notes));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadNotes()
            {
                var result = await Studio1DbService.NoteService.GetAllNotes();
                Notes = new ObservableCollection<Note>(result);
            }

            //Define public method to add a client from the database
            public async Task AddNote(DateOnly noteDeadline)
            {
                await Studio1DbService.NoteService.AddNote(noteDeadline);
                await LoadNotes();
            }

            //Define public method to remove a client from the database
            public async Task RemoveNote(int noteId)
            {
                await Studio1DbService.NoteService.RemoveNote(noteId);
                await LoadNotes();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class NotePermissionViewModel
        {
            private ObservableCollection<NotePermission> _notePermissions;
            public ObservableCollection<NotePermission> NotePermissions
            {
                get => _notePermissions;
                set
                {
                    if (_notePermissions != value)
                    {
                        _notePermissions = value;
                        OnPropertyChanged(nameof(NotePermissions));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadNotePermissions()
            {
                var result = await Studio1DbService.NotePermissionService.GetAllNotePermissions();
                NotePermissions = new ObservableCollection<NotePermission>(result);
            }

            //Define public method to add a client from the database
            public async Task AddNotePermission(bool viewPermission)
            {
                await Studio1DbService.NotePermissionService.AddNotePermission(viewPermission);
                await LoadNotePermissions();
            }

            //Define public method to remove a client from the database
            public async Task RemoveNotePermission(int permissionId)
            {
                await Studio1DbService.InstructorService.RemoveInstructor(permissionId);
                await LoadNotePermissions();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public class PaymentRecordViewModel
        {
            private ObservableCollection<PaymentRecord> _paymentRecords;
            public ObservableCollection<PaymentRecord> PaymentRecords
            {
                get => _paymentRecords;
                set
                {
                    if (_paymentRecords != value)
                    {
                        _paymentRecords = value;
                        OnPropertyChanged(nameof(PaymentRecords));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadPaymentRecords()
            {
                var result = await Studio1DbService.PaymentRecordService.GetAllPaymentRecords();
                PaymentRecords = new ObservableCollection<PaymentRecord>(result);
            }

            //Define public method to add a client from the database
            public async Task AddPaymentRecords(string paymentMethod, string cardholderName, string cardNumber,
                DateOnly expirationDate, string cvc, decimal membershipFee, string membershipType, decimal membershipAmount)
            {
                await Studio1DbService.PaymentRecordService.AddPaymentRecord(paymentMethod, cardholderName, cardNumber, expirationDate, 
                    cvc, membershipFee, membershipType, membershipAmount);
                await LoadPaymentRecords();
            }

            //Define public method to remove a client from the database
            public async Task RemovePaymentRecord(int paymentId)
            {
                await Studio1DbService.PaymentRecordService.RemovePaymentRecord(paymentId);
                await LoadPaymentRecords();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public class PrescriptionViewModel
        {
            private ObservableCollection<Prescription> _prescriptions;
            public ObservableCollection<Prescription> Prescriptions
            {
                get => _prescriptions;
                set
                {
                    if (_prescriptions != value)
                    {
                        _prescriptions = value;
                        OnPropertyChanged(nameof(Prescriptions));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadPrescriptions()
            {
                var result = await Studio1DbService.PrescriptionService.GetAllPrescriptions();
                Prescriptions = new ObservableCollection<Prescription>(result);
            }

            //Define public method to add a client from the database
            public async Task AddPrescription(string prescriptionName)
            {
                await Studio1DbService.PrescriptionService.AddPrescription(prescriptionName);
                await LoadPrescriptions();
            }

            //Define public method to remove a client from the database
            public async Task RemovePrescription(int prescriptionId)
            {
                await Studio1DbService.PrescriptionService.RemovePrescription(prescriptionId);
                await LoadPrescriptions();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        //!This class's features are still under developement
        public class UserLogViewModel
        {
            private ObservableCollection<UserLog> _userLogs;
            public ObservableCollection<UserLog> UserLogs
            {
                get => _userLogs;
                set
                {
                    if (_userLogs != value)
                    {
                        _userLogs = value;
                        OnPropertyChanged(nameof(UserLogs));
                    }
                }
            }

            //Define public method to load the clients from the database
            public async Task LoadUserLogs()
            {
                var result = await Studio1DbService.UserLogService.GetAllUserLogs();
                UserLogs = new ObservableCollection<UserLog>(result);
            }

            //Define public method to add a client from the database
            public async Task AddUserLog(DateTime timeOfLogin, string activity)
            {
                await Studio1DbService.UserLogService.AddUserLog(timeOfLogin, activity);
                await LoadUserLogs();
            }

            //Define public method to remove a client from the database
            public async Task RemoveUserLog(int loginId)
            {
                await Studio1DbService.UserLogService.RemoveUserLog(loginId);
                await LoadUserLogs();
            }


            //PropertyChanged method
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }



    }

}


    


     
