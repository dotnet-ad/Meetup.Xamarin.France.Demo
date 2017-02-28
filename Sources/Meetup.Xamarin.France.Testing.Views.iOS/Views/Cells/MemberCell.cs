namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using FFImageLoading;
	using Foundation;
	using Lkzhao;
	using Services;
	using UIKit;

	public partial class MemberCell : UITableViewCell, ICell<Member>
	{
		protected MemberCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			this.SelectedBackgroundView = new UIView();
			this.card.Layer.BorderColor = UIColor.FromRGBA(0, 0, 0, 32).CGColor;
			this.avatar.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			this.avatar.Layer.CornerRadius = this.avatar.Bounds.Height / 2;
			this.avatar.ClipsToBounds = true;
		}

		private Member item;

		public Member Item
		{
			get { return item; }
			set
			{
				if (item != value)
				{
					item = value;
					this.title.Hero().ModifierString = $"fade";
					this.avatar.Hero().ID = $"member.avatar.{value.Identifier}";
					this.title.Text = item?.Name;
					this.avatar.Image = null;
					ImageService.Instance.LoadUrl(item?.Photo?.Link).Into(this.avatar);
				}
			}
		}
	}
}