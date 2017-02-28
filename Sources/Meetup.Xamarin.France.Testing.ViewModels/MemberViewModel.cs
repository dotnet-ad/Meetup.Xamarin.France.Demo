namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Services;

	public class MemberViewModel : UpdatableViewModel
	{
		public MemberViewModel(IMeetupService meetup)
		{
			this.meetup = meetup;
		}

		#region Fields

		readonly IMeetupService meetup;

		private Member member;

		private long memberId;

		#endregion

		#region Properties

		protected Member Member
		{
			get { return this.member; }
			set { this.SetThenRaise(ref member, value, new[] { nameof(Name), nameof(City), nameof(Photo), nameof(Bio), nameof(Answers) });}
		}

		public string Name => this.Member?.Name;

		public string City => this.Member?.City;

		public string Photo => this.Member?.Photo?.HighresLink;

		public string Bio => this.Member?.Biography;

		public IEnumerable<Answer> Answers => this.Member?.Answers ?? new Answer[0];

		public long MemberId
		{
			get { return this.memberId; }
			set
			{
				if (this.Set(ref memberId, value))
				{
					this.UpdateCommand.TryExecute();
				}
			}
		}

		#endregion

		#region Update

		protected override async Task UpdateAsync()
		{
			this.Member = (await meetup.GetGroupMembers(Constants.GroupId))?.FirstOrDefault(x => x.Identifier == this.MemberId);
		}

		#endregion
	}
}
