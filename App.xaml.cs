using Microsoft.Extensions.DependencyInjection;
using Podo_TODOList.ViewModel.Main;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Podo_TODOList
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Services = ConfigureService();
			this.InitializeComponent();
		}

		public new static App Current => (App)Application.Current;

		public IServiceProvider Services { get; }

		public static IServiceProvider ConfigureService()
		{
			var services = new ServiceCollection();

			services.AddTransient(typeof(MainViewModel));
			//services.AddSingleton(typeof(TopbarViewModel));
			//services.AddSingleton(typeof());
			return services.BuildServiceProvider();
		}
	}
}
