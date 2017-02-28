namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;

	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public ViewModelBase()
		{
			this.GoBackCommand = new RelayCommand(() => Navigation.NavigateBack());
		}

		#region Navigation

		public INavigation Navigation { get; }

		public RelayCommand GoBackCommand { get; }

		#endregion

		#region Property changes

		protected bool Set<T>(ref T field, T value, [CallerMemberName]string name = null)
		{
			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
				RaiseProperty(name);
				return true;
			}

			return false;
		}

		protected bool SetThenRaise<T>(ref T field, T value, string[] linked, [CallerMemberName]string name = null)
		{
			var changed = this.Set(ref field, value, name);

			if (changed)
			{
				foreach (var item in linked)
				{
					this.RaiseProperty(item);
				}
			}

			return changed;
		}

		public void RaiseProperty(string property) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}
