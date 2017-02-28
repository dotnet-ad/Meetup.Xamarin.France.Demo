using System;
using UIKit;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public static class ThemePlatform
	{
		public static void Apply(this Theme theme)
		{
			var bg = UIColor.FromRGB(250,250,250);

			var tint = theme.Accent.ToUIColor();

			UIWindow.Appearance.TintColor = tint;

			UITableView.Appearance.TintColor = tint;

			UITableView.Appearance.SectionIndexBackgroundColor = bg;

			UIButton.Appearance.TintColor = tint;

			UINavigationBar.Appearance.BarTintColor = tint;
			UINavigationBar.Appearance.BackgroundColor = tint;
			UINavigationBar.Appearance.TintColor = theme.White.ToUIColor();
			UINavigationBar.Appearance.Translucent = false;
			UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes()
			{
				ForegroundColor = theme.White.ToUIColor(),
			};
			UITabBar.Appearance.BackgroundColor = theme.White.ToUIColor();
			UITabBar.Appearance.TintColor = tint;
		}

		public static UIColor ToUIColor(this int value)
		{
			var r = ((nfloat)((value & 0xFF00000) >> 16)) / 255.0f;
			var g = ((nfloat)((value & 0x00FF00) >> 8)) / 255.0f;
			var b = ((nfloat)(value & 0x0000FF)) / 255.0f;
			return UIColor.FromRGB(r, g, b);
		}
	}
}
