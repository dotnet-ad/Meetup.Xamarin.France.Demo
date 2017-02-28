namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System.Net.Http;
	using Services;

	public static class Dependencies
	{
		public static void InitializeDemo()
		{
			Ioc.Default.Register<IAuthentication, DemoAuthentication>();
			Ioc.Default.Register<IMeetupService, DemoMeetupService>();
		}
			
		public static void Initialize<TAuthentication>() 
			where TAuthentication : IAuthentication
		{
			Ioc.Default.Register<IAuthentication, TAuthentication>();

			Ioc.Default.Register<IMeetupService>(() =>
			{
				var handler = new HttpClientHandler();
				var auth = Ioc.Default.GetInstance<IAuthentication>();
				var distant = new RestMeetupService(auth,handler);
				return new CachedMeetupService(distant);
			});

			InitializeViewModels();
		}

		private static void InitializeViewModels()
		{
			Ioc.Default.Register<EventsViewModel>();
			Ioc.Default.Register<MembersViewModel>();
			Ioc.Default.Register<InfoViewModel>();
			Ioc.Default.Register<HomeViewModel>();
			Ioc.Default.Register<EventViewModel>();
		}
	}
}