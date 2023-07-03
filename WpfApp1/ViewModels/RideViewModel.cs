using GalaSoft.MvvmLight;
using projSchoolService.Data.Repositories.AbstractRepos;
using projSchoolService.Data.Repositories;
using projSchoolService.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace projSchoolService.Presentation.ViewModels
{
    public class RideViewModel : ViewModelBase
    {
        public int StudentCount_ = 0;
        readonly IRepository<Student>? studentRepo = new Repository<Student>();
        readonly IRepository<Ride>? rideRepo = new Repository<Ride>();
        readonly IRepository<Driver>? driverRepo = new Repository<Driver>();
        private Ride addRide = new();

        public Ride AddRide
        {
            get { return addRide; }
            set { Set(ref addRide, value); }
        }

        private Driver selectDriver = new();

        public Driver SelectDriver
        {
            get { return selectDriver; }
            set { Set(ref selectDriver, value); }
        }

        private Student selectStudent = new();

        public Student SelectStudent
        {
            get { return selectStudent; }
            set { Set(ref selectStudent, value); }
        }


        private Student selectRideStudent = new();

        public Student SelectRideStudent
        {
            get { return selectRideStudent; }
            set { Set(ref selectRideStudent, value); }
        }
        public ObservableCollection<Ride> Rides { get; set; } = new();
        public ObservableCollection<Student> Students { get; set; } = new();
        public ObservableCollection<Driver> Drivers { get; set; } = new();
        public ObservableCollection<Student> RideStudents { get; set; } = new();


        public RideViewModel()
        {
            Rides = new ObservableCollection<Ride>(this.rideRepo.GetAll());
            Students = new ObservableCollection<Student>(this.studentRepo.GetAll());
            Drivers = new ObservableCollection<Driver>(this.driverRepo.GetAll());

        }

        public RelayCommand AddCommand
        {
            get => new RelayCommand(() =>
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].FirstName == selectStudent.FirstName && Students[i].LastName == selectStudent.LastName)
                    {
                        RideStudents.Add(Students[i]);


                        Students.Remove(Students[i]);
                    }
                }


            });
        }
        public RelayCommand RideCreateCommand
        {
            get => new RelayCommand(() =>
            {
                if (addRide.NameRide is null)
                {
                    MessageBox.Show("Wrong", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    StudentCount_ = RideStudents.Count;
                    for (int i = 0; i < RideStudents.Count; i++)
                    {
                        addRide.StudentId = RideStudents[i].Id;
                    }

                    RideStudents.Clear();
                    RidesViewModel.Rides.Add(addRide);
                    rideRepo.Add(addRide);
                    rideRepo.SaveChanges();

                    MessageBox.Show("Ride elave olundu", "", MessageBoxButton.OK);
                }


            });
        }

        public RelayCommand DeleteCommand
        {
            get => new RelayCommand(() =>
            {
                for (int i = 0; i < RideStudents.Count; i++)
                {
                    if (RideStudents[i].FirstName == selectRideStudent.FirstName && RideStudents[i].LastName == selectRideStudent.LastName)
                    {
                        Students.Add(RideStudents[i]);
                        RideStudents.Remove(RideStudents[i]);
                    }
                }
            });
        }
    }
}
