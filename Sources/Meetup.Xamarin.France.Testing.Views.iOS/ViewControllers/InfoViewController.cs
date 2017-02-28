namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using ViewModels;

	public partial class InfoViewController : ViewControllerBase
	{
		#region Constructors

		protected InfoViewController(IntPtr handle) : base(handle)
		{
			this.ViewModel = Ioc.Default.GetInstance<InfoViewModel>();
		}

		public InfoViewModel ViewModel { get; }

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			this.View.AddSubview(new LoadingLayerView(this.View.Frame, this.ViewModel));
		}
	}
}
