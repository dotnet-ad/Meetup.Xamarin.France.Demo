// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	[Register ("MemberViewController")]
	partial class MemberViewController
	{
		[Outlet]
		UIKit.UIImageView avatar { get; set; }

		[Outlet]
		UIKit.UILabel bioLabel { get; set; }

		[Outlet]
		UIKit.UIView card { get; set; }

		[Outlet]
		UIKit.UILabel locationLabel { get; set; }

		[Outlet]
		UIKit.UILabel nameLabel { get; set; }

		[Outlet]
		UIKit.UITableView tableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}

			if (avatar != null) {
				avatar.Dispose ();
				avatar = null;
			}

			if (bioLabel != null) {
				bioLabel.Dispose ();
				bioLabel = null;
			}

			if (card != null) {
				card.Dispose ();
				card = null;
			}

			if (locationLabel != null) {
				locationLabel.Dispose ();
				locationLabel = null;
			}

			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}
		}
	}
}
