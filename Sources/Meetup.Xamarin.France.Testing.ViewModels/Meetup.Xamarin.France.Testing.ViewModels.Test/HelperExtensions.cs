using System;
using System.ComponentModel;
using System.Threading;

namespace Meetup.Xamarin.France.Testing.ViewModels.Test
{
	public static class HelperExtensions
	{
		/// <summary>
		/// Observes a property with the given name change by returning an AutoResetEvent.
		/// </summary>
		/// <returns>The property changed.</returns>
		/// <param name="observable">Observable.</param>
		/// <param name="name">Name.</param>
		public static AutoResetEvent ObservePropertyChanged(this INotifyPropertyChanged observable,  string name)
		{
			// Subscribe "PropertyChanged" event to know if
			// command triggers a "name" property change after an update.
			var raised = new AutoResetEvent(false);

			observable.PropertyChanged += (sender, e) =>
			{
				if (e.PropertyName == name)
				{
					raised.Set();
				}
			};

			return raised;

		}
	}
}
