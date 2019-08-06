using FriaBank.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FriaBank.ViewModels
{
    public class ViewDetailsViewModel : ViewModelBase
    {
        public ViewDetailsViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Beer Details";

        }
        private Beer beer;
        public Beer Beer
        {
            get { return beer; }
            set { SetProperty(ref beer, value); }
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Beer = (Beer)parameters["model"];
        }
    }
}
