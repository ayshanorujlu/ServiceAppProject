using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using projSchoolService.Data.Repositories.AbstractRepos;
using projSchoolService.Models.Concretes;
using projSchoolService.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projSchoolService.Presentation.ViewModels
{
    public class DriverViewModel : ViewModelBase
    {
        private readonly IRepository<Driver> driverRepo;


        public static Driver selectDriver;

        public Driver SelectDriver
        {
            get { return selectDriver; }
            set { Set(ref selectDriver, value); }
        }

        public static ObservableCollection<Driver> Drivers { get; set; } = new();

        public DriverViewModel(IRepository<Driver> driverRepo)
        {

            this.driverRepo = driverRepo;
            Drivers = new ObservableCollection<Driver>(this.driverRepo.GetAll());
        }

        public RelayCommand DriverAddCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new AddDriverView();
                window.DataContext = new AddDriverViewModel(window);
                window.Show();

            });
        }
    }
}
