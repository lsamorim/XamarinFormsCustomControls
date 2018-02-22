using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFCustomControls.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand ClickableLabelCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) 
            : base (navigationService)
        {
            Title = "Main Page";

            ClickableLabelCommand = new DelegateCommand(() => { dialogService.DisplayAlertAsync("Alert", "ClickableLabel was clicked", "ok"); });
        }
    }
}
