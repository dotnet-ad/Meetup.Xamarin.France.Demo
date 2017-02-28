namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using Foundation;
	using Lkzhao;
	using Services;
	using UIKit;

	public partial class EventCell : UITableViewCell, ICell<Event>
	{
		protected EventCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			this.SelectedBackgroundView = new UIView();
			this.card.Layer.BorderColor = UIColor.FromRGBA(0, 0, 0, 32).CGColor;
		}

		private Event item;

		public Event Item
		{
			get { return item;}
			set
			{
				if (item != value)
				{
					item = value;
					this.title.Hero().ID = $"event.title.{value.Identifier}";
					this.title.Text = item?.Name;
					this.info.Text = $"{item?.Date.ToString("g")}, {item?.Place.City}";
				}
			}
		}
	}
}
