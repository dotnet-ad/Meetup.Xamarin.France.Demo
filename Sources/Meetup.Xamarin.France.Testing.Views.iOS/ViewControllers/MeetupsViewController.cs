namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using Lkzhao;
	using Services;
	using ViewModels;

	public partial class MeetupsViewController : ViewControllerBase
	{
		#region Constructors

		protected MeetupsViewController(IntPtr handle) : base(handle)
		{
			this.ViewModel = Ioc.Default.GetInstance<EventsViewModel>();
		}

		public EventsViewModel ViewModel { get; }

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Hero().IsEnabled = true;
			this.tableView.SeparatorStyle = UIKit.UITableViewCellSeparatorStyle.None;
			this.tableView.RowHeight = 132;
			this.tableView.AttachSource<EventCell,Event>(this.ViewModel, nameof(this.ViewModel.Events), OnEventSelected);
			this.View.AddSubview(new LoadingLayerView(this.View.Frame, this.ViewModel));
		}

		private Event selectedEvent;

		private void OnEventSelected(Event e)
		{
			selectedEvent = e;
			this.PerformSegue("showEvent", this);
		}

		public override void PrepareForSegue(UIKit.UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			var detail = segue.DestinationViewController as EventViewController;
			detail.EventId = selectedEvent.Identifier;
			detail.EventName = selectedEvent.Name;
		}

	}
}
