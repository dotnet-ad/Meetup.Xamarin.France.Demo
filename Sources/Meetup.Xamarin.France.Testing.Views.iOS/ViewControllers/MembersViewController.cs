using System;
using CoreGraphics;
using Meetup.Xamarin.France.Testing.Services;
using Meetup.Xamarin.France.Testing.ViewModels;
using UIKit;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public partial class MembersViewController : ViewControllerBase
	{
		#region Constructors

		protected MembersViewController(IntPtr handle) : base(handle)
		{
			this.ViewModel = Ioc.Default.GetInstance<MembersViewModel>();
		}

		public MembersViewModel ViewModel { get; }

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.tableView.SeparatorStyle = UIKit.UITableViewCellSeparatorStyle.None;
			this.tableView.RowHeight = 80;
			this.tableView.TableFooterView = new UIView(new CGRect(0, 0, 100, 16)) { BackgroundColor = UIColor.Clear };
			this.tableView.AttachGroupedSource<MemberCell, Member>(this.ViewModel, nameof(this.ViewModel.Members), x => $"{x.Name?.ToUpper()[0]}", OnEventSelected);
			this.View.AddSubview(new LoadingLayerView(this.View.Frame, this.ViewModel));
		}

		private Member selectedItem;

		private void OnEventSelected(Member e)
		{
			selectedItem = e;
			this.PerformSegue("showMember", this);
		}

		public override void PrepareForSegue(UIKit.UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			var detail = segue.DestinationViewController as MemberViewController;
			detail.MemberId = selectedItem.Identifier;
			detail.MemberName = selectedItem.Name;
			detail.MemberPicture = selectedItem.Photo?.Link;
		}
	}
}
