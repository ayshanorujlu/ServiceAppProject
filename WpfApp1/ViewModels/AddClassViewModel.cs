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
    public class AddClassViewModel : ViewModelBase
    {
        readonly IRepository<Class>? classRepo = new Repository<Class>();
        private Class addClass = new();

        public Class AddClass
        {
            get { return addClass; }
            set { Set(ref addClass, value); }
        }

        private Window dataContext;

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }
        public ObservableCollection<Class> Classes { get; set; }


        public AddClassViewModel(Window window)
        {
            DataContext = window;

        }

        public RelayCommand ClassCreateCommand
        {
            get => new RelayCommand(() =>
            {
                ClassViewModel.Classes.Add(addClass);
                classRepo.Add(addClass);
                classRepo.SaveChanges();
                dataContext.Close();
            });
        }
    }
}
