namespace Meetup.Xamarin.France.Testing.Services
{
	using System;

	/// <summary>
	/// A service dedicated to user's authentication.
	/// </summary>
	public interface IAuthentication
	{
		bool IsAuthenticated { get; }

		string AccessToken { get; }

		event EventHandler AuthenticationChanged;

		void Login();

		void Logout();
	}
}
