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
    public class ClassViewModel : ViewModelBase
    {
        private readonly IRepository<Class> classRepo;


        public static Class selectClass;

        public Class SelectClass
        {
            get { return selectClass; }
            set { Set(ref selectClass, value); }
        }

        public static ObservableCollection<Class> Classes { get; set; } = new();

        public ClassViewModel(IRepository<Class> carRepo)
        {

            this.classRepo = carRepo;
            Classes = new ObservableCollection<Class>(this.classRepo.GetAll());
        }


        public RelayCommand ClassAddCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new AddClassView();
                window.DataContext = new AddClassViewModel(window);
                window.Show();

            });
        }

    }
}
