using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Podo_TODOList.Core.Converters
{
	class LoginButtonStyleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is Styles style)
			{
				if(style is Styles.StyleA)
				{
					return Application.Current.Resources["MaterialDesignFlatLightBgButton"];
				}
				else
				{
					return Application.Current.Resources["MaterialDesignOutlinedLightButton"];
				}
			}
			return Application.Current.Resources["MaterialDesignFlatLightBgButton"];
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DependencyProperty.UnsetValue;
		}
	}
	
}
