using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using projSchoolService.Data.Repositories;
using projSchoolService.Data.Repositories.AbstractRepos;
using projSchoolService.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace projSchoolService.Presentation.ViewModels
{
    public class EditCarViewModel : ViewModelBase
    {
        readonly IRepository<Car>? carRepo = new Repository<Car>();

        private Car editCar = new();

        public Car EditCar
        {
            get { return editCar; }
            set { Set(ref editCar, value); }
        }



        private Window dataContext;

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }

        public EditCarViewModel(Window window, Car SelectCar)
        {
            dataContext = window;
            editCar = SelectCar;
        }



        public RelayCommand CarEditCommand
        {
            get => new RelayCommand(() =>
            {
                foreach (var item in CarViewModel.Cars)
                {
                    if (item.Id == editCar.Id)
                    {
                        item.Name = editCar.Name;
                        item.CarNumber = editCar.CarNumber;
                        item.SeatCount = editCar.SeatCount;
                        break;
                    }
                }
                carRepo.Update(editCar);
                carRepo.SaveChanges();
                dataContext.Close();
            });
        }

     
    }
}
