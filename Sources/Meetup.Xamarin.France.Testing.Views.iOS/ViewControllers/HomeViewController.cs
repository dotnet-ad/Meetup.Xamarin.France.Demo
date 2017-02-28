using System;
using UIKit;
using Meetup.Xamarin.France.Testing.ViewModels;
using Lkzhao;
using HockeyApp.iOS;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public partial class HomeViewController : UITabBarController
	{
		#region Constructors

		protected HomeViewController(IntPtr handle) : base(handle)
		{
			this.ViewModel = Ioc.Default.GetInstance<HomeViewModel>();
		}

		public HomeViewModel ViewModel { get; }

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			foreach (var child in this.ChildViewControllers)
			{
				child.Hero().IsEnabled = true;
			}
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			this.ViewModel.UpdateCommand.TryExecute();

		}

		#region HockeyApp gesture feedbacks

		public override bool CanBecomeFirstResponder => true;

		public override void MotionEnded(UIEventSubtype motion, UIEvent evt)
		{
			if (motion == UIEventSubtype.MotionShake)
			{
				BITHockeyManager.SharedHockeyManager.FeedbackManager.ShowFeedbackComposeView();
			}
		}

		#endregion
	}
}
