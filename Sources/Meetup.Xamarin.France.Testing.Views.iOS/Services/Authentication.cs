namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using System.Linq;
	using global::Xamarin.Auth;
	using Services;
	using UIKit;

	public class Authentication : IAuthentication
	{
		public Authentication()
		{
			this.auth = new OAuth2Authenticator(
					clientId: ApiKey,
					scope: "ageless",
					authorizeUrl: new Uri("https://secure.meetup.com/oauth2/authorize"),
					redirectUrl: new Uri("https://www.meetup.com/fr-FR/xamarinfr/events/"));

			this.auth.Completed += (sender, eventArgs) =>
			{
				this.HideUI();

				if (eventArgs.IsAuthenticated)
				{
					AccountStore.Create().Save(eventArgs.Account, AuthName);
				}
				else
				{
					this.Logout();
				}

				this.AuthenticationChanged?.Invoke(this, EventArgs.Empty);
			};
		}

		#region Private

		private OAuth2Authenticator auth;

		private const string ApiKey = "eqcguh6cnk19ugjdts3s80aqrf";

		private const string AuthName = "Meetup";

		private Account Account => AccountStore.Create().FindAccountsForService(AuthName).FirstOrDefault();

		#endregion

		#region Properties

		public string AccessToken => Account?.Properties["access_token"];

		public bool IsAuthenticated => Account != null;

		public event EventHandler AuthenticationChanged;

		#endregion

		#region Methods

		public void Login() => ShowUI();

		public void Logout()
		{
			var store = AccountStore.Create();
			foreach (var account in store.FindAccountsForService(AuthName).ToArray())
			{
				store.Delete(account, AuthName);
			}
		}

		#endregion

		#region iOS

		private void ShowUI() => UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(auth.GetUI(), true, null);

		private void HideUI() => UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);

		#endregion
	}
}
