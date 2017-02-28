namespace Meetup.Xamarin.France.Testing.Services
{
	using System;
	using System.Threading.Tasks;

	public interface ICachedResponse
	{
		string Identifier { get; }

		DateTime Date { get; }

		Task Task { get; }
	}

	public interface ICachedResponse<T> : ICachedResponse
	{
		Task<T> TypedTask { get; }
	}

	public class CachedResponse<T> : ICachedResponse<T>
	{
		public CachedResponse(string identifier, Task<T> task)
		{
			this.Identifier = identifier;
			this.TypedTask = task;
			this.Date = DateTime.Now;
		}

		public string Identifier { get; }

		public Task<T> TypedTask { get; }

		public DateTime Date { get; }

		public Task Task => TypedTask;
	}

	public class FileCachedResponse<T> : ICachedResponse<T>
	{
		public DateTime Date { get; set; }

		public string Identifier { get; set; }

		public T Result { get; set; }

		public Task<T> TypedTask => Task.FromResult(this.Result);

		public Task Task => TypedTask;
	}
}
