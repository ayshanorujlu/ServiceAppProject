using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using projSchoolService.Data.Repositories;
using projSchoolService.Data.Repositories.AbstractRepos;
using projSchoolService.Models.Concretes;
using projSchoolService.Presentation.Services;
using projSchoolService.Presentation.ViewModels;
using projSchoolService.Presentation.Views;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
        public static Container Container{ get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            Window window = new MainWindow();
            var viewModel = Container.GetInstance<MainViewModel>();
            window.DataContext = viewModel; 
            window.ShowDialog();
            window.Close();
            base.OnStartup(e);    
        }

        private void Register() 
        {
            Container = new Container();

            Container.RegisterSingleton<projSchoolService.Presentation.Services.
                AbstractServices.INavigationService, projSchoolService.Presentation.Services.NavigationService>();
            Container.RegisterSingleton<IMessenger,Messenger>();
            Container.RegisterSingleton < IRepository < Car >, Repository < Car >> ();
            Container.RegisterSingleton < IRepository < Driver >, Repository < Driver >> ();
            Container.RegisterSingleton < IRepository < Class >, Repository <Class>> ();
            Container.RegisterSingleton < IRepository < Parent >, Repository <Parent>> ();
            Container.RegisterSingleton < IRepository <Student>, Repository < Student >> ();
            Container.RegisterSingleton < IRepository <Ride>, Repository < Ride >> ();
                 
            Container.Register<CarsView>();
            Container.Register<ClassesView>();
            Container.Register<ParentsView>();
            Container.Register<DriversView>();
            Container.Register<RidesView>();
            Container.Register<RidesView2>();
            Container.Register<StudentsView>();
            Container.Register<MainWindow>();




            Container.Register<MainViewModel>();
            Container.Register<CarViewModel>();
            Container.Register<ClassViewModel>();
            Container.Register<DriverViewModel>();
            Container.Register<ParentViewModel>();
            Container.Register<StudentViewModel>();
            Container.Register<RidesViewModel>();
            Container.Register<RideViewModel>();




        }
    }
}
