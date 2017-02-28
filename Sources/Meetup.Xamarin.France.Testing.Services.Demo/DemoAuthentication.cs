namespace Meetup.Xamarin.France.Testing.Services
{
	using System;

	public class DemoAuthentication : IAuthentication
	{
		public string AccessToken => "DEMO";

		public bool IsAuthenticated { get; private set; }

		public event EventHandler AuthenticationChanged;

		public void Login()
		{
			if (!this.IsAuthenticated)
			{
				this.IsAuthenticated = true;
				this.AuthenticationChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void Logout()
		{
			if (this.IsAuthenticated)
			{
				this.IsAuthenticated = false;
				this.AuthenticationChanged?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
