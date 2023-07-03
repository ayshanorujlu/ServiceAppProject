using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using projSchoolService.Presentation.Messages;
using projSchoolService.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1;

namespace projSchoolService.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Services.AbstractServices.INavigationService _NavigationService;
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set => Set(ref currentViewModel, value);
        }

        public MainViewModel(IMessenger messenger, Services.AbstractServices.INavigationService navigation)
        {
            _NavigationService = navigation;
            messenger.Register<NavigationMessage>(this,
                message =>
                {
                    var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
                    CurrentViewModel = viewModel;
                });
        }

        public RelayCommand CarViewCommand
        {
            get => new RelayCommand(() =>
            {
              _NavigationService.NavigateTo<CarViewModel>();
            });
        }

        public RelayCommand DriverViewCommand
        {
            get => new RelayCommand(() =>
            {
                _NavigationService.NavigateTo<DriverViewModel>();
            });
        }

        public RelayCommand ParentViewCommand
        {
            get => new RelayCommand(() =>
            {
                _NavigationService.NavigateTo<ParentViewModel>();
            });
        }

        public RelayCommand StudentViewCommand
        {
            get => new RelayCommand(() =>
            {
                _NavigationService.NavigateTo<StudentViewModel>();
            });
        }

        public RelayCommand ClassViewCommand
        {
            get => new RelayCommand(() =>
            {
                _NavigationService.NavigateTo<ClassViewModel>();
            });
        }

        public RelayCommand RideViewCommand
        {
            get => new RelayCommand(() =>
            {
                _NavigationService.NavigateTo<RideViewModel>();
            });
        }

        public RelayCommand RidesViewCommand
        {
            get => new RelayCommand(() =>
            {
                _NavigationService.NavigateTo<RidesViewModel>();
            });
        }
    }
}
