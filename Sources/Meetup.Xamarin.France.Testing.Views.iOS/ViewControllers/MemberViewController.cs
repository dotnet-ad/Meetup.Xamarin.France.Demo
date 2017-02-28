using System;
using FFImageLoading;
using Lkzhao;
using Meetup.Xamarin.France.Testing.Services;
using Meetup.Xamarin.France.Testing.ViewModels;
using UIKit;

namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	public partial class MemberViewController : UIViewController
	{
		public MemberViewController(IntPtr handle) : base(handle)
		{
			this.ViewModel = Ioc.Default.CreateInstance<MemberViewModel>();
			this.ViewModel.PropertyChanged += OnViewModelPropertyChanged;
		}

		public MemberViewModel ViewModel { get; }

		public long MemberId { get; set; }

		public string MemberName { get; set; }

		public string MemberPicture { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			this.tableView.RowHeight = UITableView.AutomaticDimension;
			this.tableView.EstimatedRowHeight = 44;

			this.Hero().IsEnabled = true;
			this.avatar.Hero().ID = $"member.avatar.{MemberId}";
			this.card.Hero().ModifierString = "delay(0.2) fade";
			this.nameLabel.Hero().ModifierString = "delay(0.3) fade translate(20, 0)";
			this.locationLabel.Hero().ModifierString = "delay(0.4) fade translate(20, 0)";
			this.bioLabel.Hero().ModifierString = "delay(0.5) fade translate(20, 0)";
			this.locationLabel.Text = null;
			this.bioLabel.Text = null;

			this.Title = "Membre";

			this.nameLabel.Text = MemberName;
			ImageService.Instance.LoadUrl(MemberPicture).Into(this.avatar);

			this.ViewModel.MemberId = MemberId;

			this.avatar.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			this.avatar.Layer.CornerRadius = this.avatar.Bounds.Height / 2;
			this.avatar.ClipsToBounds = true;
			this.card.Layer.BorderColor = UIColor.FromRGBA(0, 0, 0, 32).CGColor;

			this.tableView.AttachSource<AnswerCell, Answer>(this.ViewModel, nameof(this.ViewModel.Answers), null);
		}

		private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName == nameof(this.ViewModel.Name))
				this.nameLabel.Text = this.ViewModel.Name;

			if(e.PropertyName == nameof(this.ViewModel.City))
				this.locationLabel.Text = this.ViewModel.City;

			if(e.PropertyName == nameof(this.ViewModel.Photo))
				ImageService.Instance.LoadUrl(this.ViewModel.Photo).Into(this.avatar);
			
			if (e.PropertyName == nameof(this.ViewModel.Bio))
			{
				this.bioLabel.Text = this.ViewModel.Bio;
				this.UpdateHeader();
			}
		}

		private void UpdateHeader()
		{
			var header = this.tableView.TableHeaderView;
			header.SetNeedsLayout();
			header.LayoutIfNeeded();

			var f = header.Frame;
			var s = header.SystemLayoutSizeFittingSize(UIView.UILayoutFittingCompressedSize);
			header.Frame = new CoreGraphics.CGRect(f.X, f.Y, s.Width, s.Height);

			this.tableView.TableHeaderView = header;
		}

		public override void UpdateViewConstraints()
		{
			base.UpdateViewConstraints();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

