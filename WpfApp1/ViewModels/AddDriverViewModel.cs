using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using projSchoolService.Data.Repositories;
using projSchoolService.Data.Repositories.AbstractRepos;
using projSchoolService.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace projSchoolService.Presentation.ViewModels
{
    public class AddDriverViewModel : ViewModelBase
    {
        readonly IRepository<Driver>? driverRepo = new Repository<Driver>();
        readonly IRepository<Car>? carRepo = new Repository<Car>();

        private Driver addDriver = new();

        public Driver AddDriver
        {
            get { return addDriver; }
            set { Set(ref addDriver, value); }
        }

        private Window dataContext;

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }

        private Car _selectCar = new();

        public Car _SelectCar
        {
            get { return _selectCar; }
            set { Set(ref _selectCar, value); }
        }


        public ObservableCollection<Car> Cars_ { get; set; }
        public ObservableCollection<Driver> Drivers_ { get; set; }
        public AddDriverViewModel(Window window)
        {
            dataContext = window;
            addDriver = new();
            Cars_ = CarViewModel.Cars;
            Drivers_ = DriverViewModel.Drivers;
            for (int i = 0; i < Cars_.Count; i++)
            {
                for (int j = 0; j < Drivers_.Count; j++)
                {
                    if (Cars_[i].Id == Drivers_[j].CarId)
                    {
                        Cars_.Remove(Cars_[i]);
                    }
                }
            }

        }


        public RelayCommand DriverCreateCommand
        {
            get => new RelayCommand(() =>
            {
                Cars_ = new ObservableCollection<Car>(this.carRepo.GetAll());
                addDriver.CarId = _selectCar.Id;


                DriverViewModel.Drivers.Add(addDriver);
                driverRepo.Add(addDriver);
                driverRepo.SaveChanges();
                dataContext.Close();
            });
        }
    }
}
