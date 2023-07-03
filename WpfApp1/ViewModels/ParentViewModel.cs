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
    public class ParentViewModel : ViewModelBase
    {
        private readonly IRepository<Parent> parentRepo;


        public static Parent selectParent;

        public Parent SelectParent
        {
            get { return selectParent; }
            set { Set(ref selectParent, value); }
        }

        public static ObservableCollection<Parent> Parents { get; set; } = new();

        public ParentViewModel(IRepository<Parent> parentRepo)
        {

            this.parentRepo = parentRepo;
            Parents = new ObservableCollection<Parent>(this.parentRepo.GetAll());
        }


        public RelayCommand ParentAddCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new AddParentView();
                window.DataContext = new AddParentViewModel(window);
                window.Show();

            });
        }

        public RelayCommand ParentEditCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new EditParentView();
                window.DataContext = new EditParentViewModel(window, SelectParent);
                window.Show();

            });
        }
    }
}
