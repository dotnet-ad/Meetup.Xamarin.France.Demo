using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;

namespace Meetup.Xamarin.France.Testing.Services
{
	public class CachedMeetupService : IMeetupService
	{
		private class FileCache<T>
		{
			public DateTime Update { get; set; }

			public List<T> Items { get; set; }
		}

		public CachedMeetupService(IMeetupService distant)
		{
			this.distant = distant;
		}

		public TimeSpan Expiration { get; set; } = TimeSpan.FromHours(1);

		readonly IMeetupService distant;

		private List<ICachedResponse> responses = new List<ICachedResponse>();

		private async Task<ICachedResponse> Load<T>(string id)
		{
			try
			{
				var file = await FileSystem.Current.LocalStorage.GetFileAsync($"{id}.cache");
				var json = await file.ReadAllTextAsync();
				var cached = JsonConvert.DeserializeObject<FileCachedResponse<T>>(json);
				this.responses.Add(cached);
				return cached;
			}
			catch (Exception) {
				return null;
			}
		}

		private async Task Delete(ICachedResponse response)
		{

		}

		private async Task Save<T>(ICachedResponse response)
		{
			try
			{
				var result = await (Task<T>)response.Task;
				var file = await FileSystem.Current.LocalStorage.CreateFileAsync($"{response.Identifier}.cache", CreationCollisionOption.ReplaceExisting);
				var json = JsonConvert.SerializeObject(new FileCachedResponse<T>()
				{
					Identifier = response.Identifier,
					Date = response.Date,
					Result = result,
				});
				await file.WriteAllTextAsync(json);
			}
			catch (Exception)
			{
			}
		}

		private async Task<T> Get<T>(string method, string groupid, Func<Task<T>> execute)
		{
			var identifier = $"{method}_{groupid}";
			var cached = responses.FirstOrDefault(x => x.Identifier == identifier);

			if (cached == null)
			{
				cached = await this.Load<T>(identifier);
			}

			if (cached == null || cached.Date + Expiration < DateTime.Now)
			{
				if (cached != null)
					responses.Remove(cached);
				
				cached = new CachedResponse<T>(identifier, execute());
				responses.Add(cached);
				await this.Save<T>(cached);
			}

			return await (cached as ICachedResponse<T>)?.TypedTask;
		}

		public Task<Group> GetGroupDetail(string groupid) => this.Get(nameof(GetGroupDetail), groupid, () => this.distant.GetGroupDetail(groupid));

		public Task<IEnumerable<Event>> GetGroupEvents(string groupid) => this.Get(nameof(GetGroupEvents), groupid, () => this.distant.GetGroupEvents(groupid));

		public Task<IEnumerable<Member>> GetGroupMembers(string groupid) => this.Get(nameof(GetGroupMembers), groupid, () => this.distant.GetGroupMembers(groupid));
	}
}
