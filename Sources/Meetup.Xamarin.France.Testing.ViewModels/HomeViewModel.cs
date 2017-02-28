namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System;
	using System.Threading.Tasks;
	using Services;

	public class HomeViewModel : UpdatableViewModel
	{
		public const string GroupId = "xamarinfr";

		public HomeViewModel(IAuthentication auth, InfoViewModel info, EventsViewModel events, MembersViewModel members)
		{
			this.auth = auth;
			this.auth.AuthenticationChanged += OnAuthenticationChanged;

			this.Info = info;
			this.Members = members;
			this.Events = events;
		}

		readonly IAuthentication auth;

		public InfoViewModel Info { get; }

		public EventsViewModel Events { get; }

		public MembersViewModel Members { get; }

		private void OnAuthenticationChanged(object sender, EventArgs e) => this.UpdateCommand.TryExecute();

		protected override Task UpdateAsync()
		{
			if (!this.auth.IsAuthenticated)
			{
				this.auth.Login();
			}
			else
			{
				Info.UpdateCommand.TryExecute();
				Events.UpdateCommand.TryExecute();
				Members.UpdateCommand.TryExecute();
			}

			return Task.FromResult(true);
		}
	}
}
