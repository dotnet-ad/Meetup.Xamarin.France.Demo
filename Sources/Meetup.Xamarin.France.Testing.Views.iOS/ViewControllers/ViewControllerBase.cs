using System;
using UIKit;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public class ViewControllerBase : UIViewController
	{
		#region Constructors

		protected ViewControllerBase(IntPtr handle) : base(handle)
		{

		}

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var logo = new UIImageView(UIImage.FromBundle("Logo"));
			this.NavigationItem.TitleView = logo;
		}
	}
}
