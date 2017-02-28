namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System.Threading.Tasks;

	public interface INavigation
	{
		Task Navigate(string key);

		Task NavigateBack();
	}
}
