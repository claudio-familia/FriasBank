using FriaBank.Models;
using FriaBank.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FriaBank.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IBeerService _beerService;
        private ObservableCollection<Beer> beerList;
        private Beer beer;
        private DelegateCommand viewDetails;
        private DelegateCommand loadMoreCommand;
        private int page, perPage;
        public ImageSource Logo => ImageSource.FromUri(new Uri("https://img.icons8.com/officel/64/000000/beer.png"));


        public MainPageViewModel(INavigationService navigationService, BeerService beerService)
            : base(navigationService)
        {
            Title = "List of beers";
            _beerService = beerService;
            beerList = new ObservableCollection<Beer>();
            page = 1;
            perPage = 10;
            GetBeersFromAPI(page, perPage);
        }

        public ObservableCollection<Beer> BeerList
        {
            get { return beerList; }
            set { SetProperty(ref beerList, value); }
        }

        public Beer Beer
        {
            get { return beer; }
            set {
                SetProperty(ref beer, value);                
                if (value != null)
                {
                    ViewDetails.Execute();
                }
            }
        }

        public DelegateCommand ViewDetails =>
            viewDetails ?? (viewDetails = new DelegateCommand(ExecuteViewDetailsAsync));

        public DelegateCommand LoadMoreCommand =>
            loadMoreCommand ?? (loadMoreCommand = new DelegateCommand(() => GetBeersFromAPI(++page, perPage)));

        async void ExecuteViewDetailsAsync()
        {
            var parameters = new NavigationParameters();
            parameters.Add("model", Beer);
            await NavigationService.NavigateAsync("ViewDetails", parameters);
        }

        async void GetBeersFromAPI(int page, int perPage)
        {
            IsBusy = true;
            var response = await _beerService.GetAllSeriesAsync(page, perPage);            
            IsBusy = false;
            foreach(var item in response)
            {
                item.Image = item.ImageUrl;
                BeerList.Add(item);
            }
        }
    }
}
