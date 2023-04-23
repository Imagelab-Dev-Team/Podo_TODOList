using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using Podo_TODOList.Core;
using Podo_TODOList.View.Common;
using Podo_TODOList.View.Login;
using Podo_TODOList.View.Main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		/// <summary>
		/// 로그인/로그아웃 상태에 따라 TopbarView의 LoginButton에 표시될 텍스트
		/// </summary>
        [ObservableProperty]
        private string _loginButtonText;

		/// <summary>
		/// 로그인/로그아웃 상태에 따라 TopbarView의 LoginButton에 적용될 스타일
		/// </summary>
		[ObservableProperty]
		private Styles _loginButtonStyle;

		public MainViewModel()
        {
            CurrentTopbarView = new TopbarView();
            CurrentSidebarView = new SidebarView();
            CurrentTaskListView = new TaskListView();
            CurrentUnderbarView = new UnderbarView();
            IsUserLogin = false;
            LoginButtonText = "LOG IN";
			LoginButtonStyle = Styles.StyleA;
		}

		// TopbarView의 Loginbutton을 눌렀을 때 모달을 열고 이벤트를 주입하기 위한 메서드
        [RelayCommand]
        private async void LoginButton()
        {

			if (IsUserLogin)
			{
				IsUserLogin = false;
				LoginButtonStyle = Styles.StyleA;
				LoginButtonText = "LOG IN";
			}
			else
			{
				var view = new LoginView();

				var res = await DialogHost.Show(view, "RootDialog", OpenedEventHandler, ClosingEventHandler, ClosedEventHandler);
			}
        }

		// LoginView가 닫힌 직후 이벤트
		private void ClosedEventHandler(object sender, DialogClosedEventArgs eventArgs)
		{
			Trace.WriteLine("login view closed");
		}

		// LoginView가 열릴 때 이벤트
		private void OpenedEventHandler(object sender, DialogOpenedEventArgs eventArgs)
		{
            Trace.WriteLine("login view opened");
		}

		// LoginView가 닫히기 시작했을 때 이벤트
		private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
		{
            if (eventArgs.Parameter is bool canceled && !canceled)
            {
                return;
            }

			eventArgs.Cancel();

			eventArgs.Session.UpdateContent(new SmallCircleProgressBar());

			Task.Delay(3000).ContinueWith(
				(t, _) =>
				{
					// TODO : Login 처리 로직
					eventArgs.Session.Close(false);
					IsUserLogin = true;
					LoginButtonText = "LOG OUT";
					if (IsUserLogin)
					{
						LoginButtonStyle = Styles.StyleB;
					}

				}, null, TaskScheduler.FromCurrentSynchronizationContext());
		}

		// TopbarView의 로그인 버튼 스타일 변경을 위한 메서드
		[RelayCommand]
		private void SelectLoginButtonStyle(object obj)
		{
			if (obj is Styles style)
			{
				LoginButtonStyle = style;
			}
		}
	}
}
