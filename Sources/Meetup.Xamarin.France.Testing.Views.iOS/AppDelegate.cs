using Foundation;
using HockeyApp.iOS;
using Meetup.Xamarin.France.Testing.ViewModels;
using UIKit;
using Xamarin;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window { get; set; }

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
#if ENABLE_TEST_CLOUD
			Calabash.Start();
#endif

			//this.ConfigureHockeyApp();

			Dependencies.InitializeDemo();
			//Dependencies.Initialize<Authentication>();

			Theme.Default.Apply();

			return true;
		}

		private void ConfigureHockeyApp()
		{
			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure("abf0a11b490047be828cb3f4c2e1e976");
			manager.StartManager();
			manager.Authenticator.AuthenticateInstallation();
		}
	}
}

