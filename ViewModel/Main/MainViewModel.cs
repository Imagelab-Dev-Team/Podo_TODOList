using CommunityToolkit.Mvvm.ComponentModel;
using Podo_TODOList.Core;
using Podo_TODOList.View.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podo_TODOList.ViewModel.Main
{
	internal partial class MainViewModel:ViewModelBase
	{

        [ObservableProperty]
        private object _currentTopbarView;

        [ObservableProperty]
        private object _currentSidebarView;
        [ObservableProperty]
        private object _currentTaskListView;
        [ObservableProperty]
        private object _currentUnderbarView;

        public MainViewModel()
        {
            CurrentTopbarView = new TopbarView();
            CurrentSidebarView = new SidebarView();
            CurrentTaskListView = new TaskListView();
            CurrentUnderbarView = new UnderbarView();
        }
    }
}
