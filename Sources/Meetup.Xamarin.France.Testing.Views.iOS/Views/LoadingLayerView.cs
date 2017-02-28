namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using ViewModels;
	using UIKit;
	using CoreGraphics;

	public class LoadingLayerView : UIView
	{
		public LoadingLayerView(CGRect frame, UpdatableViewModel vm) : base(frame)
		{
			this.UserInteractionEnabled = false;
			this.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			this.AddSubview(this.empty = CreateEmpty(frame));
			this.AddSubview(this.loading = CreateLoading(frame));
			vm.PropertyChanged += OnViewModelPropertyChanged; // TODO weak handler
		}

		private UIView CreateLoading(CGRect frame)
		{
			var result = new UIView(frame) { AutoresizingMask = UIViewAutoresizing.FlexibleDimensions };
			const float size = 32;
			var loader = new UIActivityIndicatorView(new CGRect((frame.Width / 2) - (size / 2), (frame.Height / 2) - (size / 2), size, size))
			{
				AutoresizingMask = UIViewAutoresizing.FlexibleMargins
			};
			result.AddSubview(loader);
			return result;
		}

		private UIView CreateEmpty(CGRect frame)
		{
			return new UIView(frame); // TODO
		}

		private readonly UIView loading, empty;

		void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var vm = sender as UpdatableViewModel;
			if (e.PropertyName == nameof(UpdatableViewModel.IsUpdating) || e.PropertyName == nameof(UpdatableViewModel.IsUpdated))
			{
				this.loading.Hidden = !vm.IsUpdating;
				this.empty.Hidden = vm.IsUpdating || vm.IsUpdated;
			}
		}
	}
}
