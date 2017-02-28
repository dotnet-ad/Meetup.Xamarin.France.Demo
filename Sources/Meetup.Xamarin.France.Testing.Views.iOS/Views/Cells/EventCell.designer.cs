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
	[Register ("EventCell")]
	partial class EventCell
	{
		[Outlet]
		UIKit.UIView card { get; set; }

		[Outlet]
		UIKit.UILabel info { get; set; }

		[Outlet]
		UIKit.UILabel title { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (card != null) {
				card.Dispose ();
				card = null;
			}

			if (info != null) {
				info.Dispose ();
				info = null;
			}

			if (title != null) {
				title.Dispose ();
				title = null;
			}
		}
	}
}
