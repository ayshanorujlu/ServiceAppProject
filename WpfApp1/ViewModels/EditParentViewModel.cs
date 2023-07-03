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

namespace projSchoolService.Presentation.ViewModels
{
    public class EditParentViewModel : ViewModelBase
    {

        readonly IRepository<Parent>? parentRepo = new Repository<Parent>();

        private Parent editParent = new();

        public Parent EditParent
        {
            get { return editParent; }
            set { Set(ref editParent, value); }
        }



        private Window dataContext;

        public Window DataContext
        {
            get { return dataContext; }
            set { Set(ref dataContext, value); }
        }

        public EditParentViewModel(Window window, Parent SelectParent)
        {
            dataContext = window;
            editParent = SelectParent;
        }



        public RelayCommand ParentEditCommand
        {
            get => new RelayCommand(() =>
            {
                foreach (var item in ParentViewModel.Parents)
                {
                    if (item.Id == editParent.Id)
                    {
                        item.FirstName = editParent.FirstName;
                        item.LastName = editParent.LastName;
                        item.PhoneNumber = editParent.PhoneNumber;
                        break;
                    }
                }
                parentRepo.Update(editParent);
                parentRepo.SaveChanges();
                dataContext.Close();
            });
        }

    }
}
