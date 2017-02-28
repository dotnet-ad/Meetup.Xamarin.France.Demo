using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meetup.Xamarin.France.Testing.Services;

namespace Meetup.Xamarin.France.Testing.ViewModels
{
	public class EventViewModel : UpdatableViewModel
	{
		public EventViewModel(IMeetupService meetup)
		{
			this.meetup = meetup;
		}

		#region Fields

		readonly IMeetupService meetup;

		private Event @event;

		private long eventId;

		#endregion

		#region Properties

		public Event Event
		{
			get { return this.@event; }
			protected set { this.Set(ref @event, value) ; }
		}


		public long EventId
		{
			get { return this.eventId; }
			set
			{
				if (this.Set(ref eventId, value))
				{
					this.UpdateCommand.TryExecute();
				}
			}
		}

		#endregion

		#region Update

		protected override async Task UpdateAsync() => this.Event = (await meetup.GetGroupEvents(Constants.GroupId))?.FirstOrDefault(x => x.Identifier == this.EventId);

		#endregion
	}
}
