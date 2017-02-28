using UIKit;

namespace Meetup.Xamarin.France.Testing.Views
{
	public class Theme
	{
		public int Accent { get; set; }

		public int AccentDark { get; set; }

		public int LightGrey { get; set; }

		public int White { get; set; }

		public static Theme Default = new Theme()
		{
			Accent = 0xED1C40,
			AccentDark = 0xA7172F,
			LightGrey = 0xFAFAFA,
			White = 0xFFFFFF,
		};
	}
}
