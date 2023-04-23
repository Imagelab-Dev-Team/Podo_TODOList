using CommunityToolkit.Mvvm.ComponentModel;
using Podo_TODOList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podo_TODOList.ViewModel
{

	internal partial class ViewModelBase:ObservableObject
	{
		[ObservableProperty]
		string _title;
		[ObservableProperty]
		bool _isChecked;
		[ObservableProperty]
		User _currentUser;
		[ObservableProperty]
		bool _isUserLogin;
	}
}
