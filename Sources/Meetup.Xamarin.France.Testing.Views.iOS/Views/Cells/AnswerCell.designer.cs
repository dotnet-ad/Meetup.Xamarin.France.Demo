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
	[Register ("AnswerCell")]
	partial class AnswerCell
	{
		[Outlet]
		UIKit.UILabel titleLabel { get; set; }

		[Outlet]
		UIKit.UILabel valueLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}

			if (valueLabel != null) {
				valueLabel.Dispose ();
				valueLabel = null;
			}
		}
	}
}
