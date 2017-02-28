namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Meetup.Xamarin.France.Testing.Services;

	public class MembersViewModel : UpdatableViewModel
	{
		public MembersViewModel(IMeetupService meetup)
		{
			this.meetup = meetup;
		}

		#region Fields

		readonly IMeetupService meetup;

		private IEnumerable<Member> members = new Member[0];

		#endregion

		#region Properties

		public IEnumerable<Member> Members
		{
			get { return this.members; }
			set { this.Set(ref members, value); }
		}

		#endregion

		#region Update

		protected override async Task UpdateAsync()
		{
			var newMembers = await meetup.GetGroupMembers(Constants.GroupId) ?? new Member[0];
			this.Members = newMembers.OrderBy(x => x.Name).ToArray();
		}

		#endregion
	}
}
