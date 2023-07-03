using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using projSchoolService.Presentation.Messages;
using projSchoolService.Presentation.Services.AbstractServices;

namespace projSchoolService.Presentation.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMessenger messenger;


        public NavigationService(IMessenger messenger)
        {
            this.messenger = messenger;
        }
        public void NavigateTo<T>() where T : ViewModelBase
        {
            messenger.Send(new NavigationMessage { ViewModelType = typeof(T) });
        }
    }
}
