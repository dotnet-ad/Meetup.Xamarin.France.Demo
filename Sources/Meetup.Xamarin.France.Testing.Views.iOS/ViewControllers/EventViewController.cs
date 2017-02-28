using System;
using Lkzhao;
using Meetup.Xamarin.France.Testing.ViewModels;
using UIKit;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public partial class EventViewController : UIViewController
	{
		public EventViewController(IntPtr handle) : base(handle)
		{
			this.ViewModel = Ioc.Default.CreateInstance<EventViewModel>();
		}

		public EventViewModel ViewModel { get; }

		public long EventId { get; set; }

		public string EventName { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.Title = "Meetup";

			this.titleLabel.Text = EventName;
			this.ViewModel.EventId = EventId;

			this.Hero().IsEnabled = true;
			this.titleLabel.Hero().ID = $"event.title.{EventId}";
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

