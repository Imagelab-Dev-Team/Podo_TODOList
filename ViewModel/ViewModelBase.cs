using CommunityToolkit.Mvvm.ComponentModel;
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
	}
}
