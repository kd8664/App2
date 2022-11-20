using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App2
{
	class ViewModel : BindableObject
	{
		public ObservableCollection<SomeValute> All { get; }
		public RatesRequest Valutes = new RatesRequest();
		private string _StartValute;
		private string _EndValute;
		private SomeValute _Source;
		private SomeValute _Target;
		private string dateTime;

		public string CurrentDate
		{
			get { return dateTime; }
			set
			{
				dateTime = value;
				OnPropertyChanged(nameof(CurrentDate));
			}
		}

		public SomeValute Source
		{
			get { return _Source; }
			set 
			{
				_Source = value;
				OnPropertyChanged(nameof(Source));
				if (!String.IsNullOrEmpty(StartValute) && !String.IsNullOrEmpty(EndValute))
					StartValute = Conv(Target, Source,Convert.ToDouble(EndValute));
			}
		}

		public SomeValute Target
		{
			get { return _Target; }
			set 
			{ 
				_Target = value;
				OnPropertyChanged(nameof(Target));
				if(!String.IsNullOrEmpty(StartValute) && !String.IsNullOrEmpty(EndValute))
					EndValute = Conv(Source, Target, Convert.ToDouble(StartValute));
			}
		}


		public ViewModel()
		{
			All = new ObservableCollection<SomeValute>(Valutes.GetExchangeRates().Valute.All);
			SomeValute RUB = new SomeValute()
			{
				ID = "qqqq",
				CharCode = "RUB",
				NumCode = "1234",
				Name = "Российский рубль",
				Nominal = 1,
				Value = 1,
				Previous = 1.1
			};
			CurrentDate = DateTime.Now.ToShortDateString();
			All.Add(RUB);
			Source = RUB;
			Target = All[10];
		}

		public string StartValute
		{
			get { return _StartValute; }
			set
			{
				if (value == _StartValute || String.IsNullOrEmpty(value))
					return;
				_StartValute = value;
				OnPropertyChanged(nameof(StartValute));
				if (StartValute!=null&&(CanConvert(Source, Target, Convert.ToDouble(StartValute), Convert.ToDouble(EndValute))))
					EndValute = Conv(Source, Target, Convert.ToDouble(StartValute));
			}
		}

		public string EndValute
		{
			get { return _EndValute; }
			set
			{
				if (value == _EndValute || String.IsNullOrEmpty(value))
					return;
				_EndValute = value;
				OnPropertyChanged(nameof(EndValute));
				if (EndValute != null && (CanConvert(Target,Source,Convert.ToDouble(EndValute),Convert.ToDouble(StartValute))))
					 StartValute = Conv(Target, Source,Convert.ToDouble(EndValute));
			}
		}

		private bool CanConvert(SomeValute first, SomeValute second, double value1,double value2)
		{
			var val = Convert.ToDouble(Conv(first, second, value1));
			if (val - value2 < 0.01 && value2 - val < 0.01)
				return false;
			else return true;
		}

		private string Conv(SomeValute first, SomeValute second, double value)
		{
			return Convert.ToString(Math.Round((first.Value / first.Nominal) / (second.Value / second.Nominal)*value, 6));
		}

	}
}
