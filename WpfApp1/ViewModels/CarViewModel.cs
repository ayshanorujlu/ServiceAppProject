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
    public class CarViewModel : ViewModelBase
    {
        private readonly IRepository<Car> carRepo;


        public static Car selectCar;

        public Car SelectCar
        {
            get { return selectCar; }
            set { Set(ref selectCar, value); }
        }

        public static ObservableCollection<Car> Cars { get; set; } = new();

        public CarViewModel(IRepository<Car> carRepo)
        {

            this.carRepo = carRepo;
            Cars = new ObservableCollection<Car>(this.carRepo.GetAll());
        }


        public RelayCommand AddCarCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new AddCarView();
                window.DataContext = new AddCarViewModel(window);
                window.Show();

            });
        }

        public RelayCommand EditCarCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new EditCarView();
                window.DataContext = new EditCarViewModel(window, SelectCar);
                window.Show();

            });
        }
    }
}
