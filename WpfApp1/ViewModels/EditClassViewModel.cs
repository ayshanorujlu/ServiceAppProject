using GalaSoft.MvvmLight;
using projSchoolService.Data.Repositories.AbstractRepos;
using projSchoolService.Data.Repositories;
using projSchoolService.Models.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projSchoolService.Presentation.Services.AbstractServices;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace projSchoolService.Presentation.ViewModels
{
    public class EditClassViewModel : ViewModelBase
    {
        private Class _class = new();

        public Class _Class
        {
            get { return _class; }
            set { _class = value; }
        }

        public Class ClassTemp { get; set; } = new Class();



        private readonly IRepository<Class> clasRepo = new Repository<Class>();



        public EditClassViewModel()
        {
            _class = ClassViewModel.selectClass;

        }


        public RelayCommand EditClassCommand
        {
            get => new RelayCommand(() =>
            {
                try
                {
                    if (_class.Name is null)
                    {
                        MessageBox.Show("dsfa", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ClassTemp = ClassViewModel.selectClass;
                        Class editClass = clasRepo!.Get(c => c.Id == ClassViewModel.selectClass.Id!)!.FirstOrDefault()!;
                        editClass.Name = ClassTemp.Name;

                        clasRepo.Update(editClass);
                        clasRepo.SaveChanges();
                        ClassViewModel.Classes.Remove(ClassTemp);
                        ClassViewModel.Classes.Add(editClass);

                        MessageBox.Show("Class Edit olundu", "", MessageBoxButton.OK);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            });
        }
    }
}
