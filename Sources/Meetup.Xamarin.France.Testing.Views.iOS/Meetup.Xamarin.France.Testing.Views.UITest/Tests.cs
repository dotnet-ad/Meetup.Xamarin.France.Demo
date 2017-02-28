using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace Meetup.Xamarin.France.Testing.Views.UITest
{
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		#region Fields

		IApp app;

		Platform platform;

		#endregion

		#region Constants

		const string CellClass = "UITableViewCellContentView";

		const string UINavigationBarClass = "UINavigationBar";

		const string UILabelClass = "UILabel";

		#endregion

		#region Constructors

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		#endregion

		#region Initialization

		[SetUp]
		public void BeforeEachTest() => app = ConfigureApp.iOS
														  .AppBundle("../../../bin/iPhoneSimulator/Debug/Meetup.Xamarin.France.Testing.Views.iOS.app")
														  .EnableLocalScreenshots()
														  .StartApp();

		#endregion

		#region Tests

		[Test]
		public void Members_AlexDanvy_LovesIoT()
		{
			const string MemberTab = "Membres";
			const string MemberName = "Alex Danvy";
			const string MemberPageTitle = "Membre";
			const string SearchedContent = "Love IoT";

			/// Tap on the second tab at the bottom of the screen
			app.Tap(x => x.Marked(MemberTab));
			app.Screenshot("Selected members tab");

			/// Waiting the end of data update, when cells have been
			/// loaded into table view
			app.WaitForElement(x => x.Class(CellClass));
			app.Screenshot("Loaded members");

			/// We'are scrolling down the searched member cell.
			app.ScrollTo(MemberName);
			app.Screenshot("Loaded members");

			// Tap on the member cell
			app.Tap(MemberName);

			/// Wait for Member detail page to be loaded by observing navigation bar title.
			app.WaitForElement(x => x.Class(UINavigationBarClass).Marked(MemberPageTitle));
			app.Screenshot("Member's profile");

			// Verify that at leat one UIILabel contains the searched text.
			var result = app.Query(x => x.Class(UILabelClass)).Where(x => x.Text.Contains(SearchedContent));
			Assert.IsTrue(result.Any());
		}

		#endregion

	}
}
