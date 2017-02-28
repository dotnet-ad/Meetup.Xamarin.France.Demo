using System;

using Foundation;
using Lkzhao;
using Meetup.Xamarin.France.Testing.Services;
using UIKit;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public partial class AnswerCell : UITableViewCell, ICell<Answer>
	{
		public AnswerCell(IntPtr handle) : base(handle)
		{
			this.Hero().ModifierString = "delay(0.6) fade translate(20, 0)";
		}  
	
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			this.BackgroundColor = UIColor.Clear;
			this.SelectedBackgroundView = new UIView()
			{
				BackgroundColor = UIColor.Clear,
			};
		}

		private Answer item;

		public Answer Item
		{
			get { return item; }
			set
			{
				if (item != value)
				{
					item = value;
					this.titleLabel.Text = item?.Question;
					this.valueLabel.Text = item?.Value;
				}
			}
		}
	}
}
