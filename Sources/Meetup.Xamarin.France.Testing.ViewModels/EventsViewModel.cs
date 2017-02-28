namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Meetup.Xamarin.France.Testing.Services;

	public class EventsViewModel : UpdatableViewModel
	{
		public EventsViewModel(IMeetupService meetup)
		{
			this.meetup = meetup;
		}

		#region Fields

		readonly IMeetupService meetup;

		private IEnumerable<Event> events = new Event[0];

		#endregion

		#region Properties

		public IEnumerable<Event> Events
		{
			get { return this.events; }
			set { if (this.Set(ref events, value)) ; }
		}

		#endregion

		#region Update

		protected override async Task UpdateAsync()
		{
			var allevents = await meetup.GetGroupEvents(Constants.GroupId);
			this.Events = allevents.OrderByDescending(x => x.Date);
		}

		#endregion
	}
}
