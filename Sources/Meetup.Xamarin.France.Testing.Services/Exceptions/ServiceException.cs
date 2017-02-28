using System;
namespace Meetup.Xamarin.France.Testing.Services
{
	public class ServiceException : Exception
	{
		public ServiceException(Exception inner) : base("Api error",inner)
		{
		}
	}
}
