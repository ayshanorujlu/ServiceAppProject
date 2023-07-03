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
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace projSchoolService.Presentation.ViewModels
{
    public class AddCarViewModel : ViewModelBase
    {
        readonly IRepository<Car>? carRepo = new Repository<Car>();
        private Car addCar = new();

        public Car AddCar
        {
            get { return addCar; }
            set { Set(ref addCar, value); }
        }

        private Window dataContext;

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }
        public ObservableCollection<Car> Cars { get; set; }


        public AddCarViewModel(Window window)
        {
            DataContext = window;

        }

        public RelayCommand CarCreateCommand
        {
            get => new RelayCommand(() =>
            {
                CarViewModel.Cars.Add(addCar);
                carRepo.Add(addCar);
                carRepo.SaveChanges();
                dataContext.Close();
            });
        }

    }
}

