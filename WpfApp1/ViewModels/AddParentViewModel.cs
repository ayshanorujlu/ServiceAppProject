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
    public class AddParentViewModel : ViewModelBase
    {
        readonly IRepository<Parent>? parentRepo = new Repository<Parent>();
        private Parent addParent = new();

        public Parent AddParent
        {
            get { return addParent; }
            set { Set(ref addParent, value); }
        }

        private Window dataContext;

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }
        public ObservableCollection<Parent> Parents { get; set; }


        public AddParentViewModel(Window window)
        {
            DataContext = window;

        }

        public RelayCommand ParentCreateCommand
        {
            get => new RelayCommand(() =>
            {
                ParentViewModel.Parents.Add(addParent);
                parentRepo.Add(addParent);
                parentRepo.SaveChanges();
                dataContext.Close();
            });
        }
    }
}
