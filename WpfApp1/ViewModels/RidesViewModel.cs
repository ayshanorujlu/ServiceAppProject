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

namespace projSchoolService.Presentation.ViewModels
{
    public class RidesViewModel : ViewModelBase
    {
        public static int StudentCount = 0;
        private readonly IRepository<Ride> rideRepo = new Repository<Ride>();
        private readonly IRepository<Driver> driverRepo = new Repository<Driver>();


        public static Ride selectRide = new();

        public Ride SelectRide
        {
            get { return selectRide; }
            set { Set(ref selectRide, value); }
        }

        public static Driver driver_;

        public Driver Driver_
        {
            get { return driver_; }
            set { Set(ref driver_, value); }
        }

        public static ObservableCollection<Ride> Rides { get; set; } = new();
        public static ObservableCollection<Driver> Drivers { get; set; } = new();

        public RidesViewModel(IRepository<Ride> rideRepo)
        {

            this.rideRepo = rideRepo;
            Rides = new ObservableCollection<Ride>(this.rideRepo.GetAll());
            Drivers = new ObservableCollection<Driver>(this.driverRepo.GetAll());


        }


       
    }
}
