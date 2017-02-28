using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Meetup.Xamarin.France.Testing.Services
{
	public class RestMeetupService : IMeetupService
	{
		public RestMeetupService(IAuthentication auth, HttpClientHandler handler)
		{
			this.auth = auth;
			this.client = new HttpClient(handler);
		}

		#region Fields

		readonly IAuthentication auth;

		readonly HttpClient client;

		#endregion

		#region Methods

		public Task<Group> GetGroupDetail(string groupid) => Get<Group>(groupid);

		public Task<IEnumerable<Event>> GetGroupEvents(string groupid) => Get<IEnumerable<Event>>($"{groupid}/events");

		public Task<IEnumerable<Member>> GetGroupMembers(string groupid) => Get<IEnumerable<Member>>($"{groupid}/members");

		#endregion

		#region Sending requests

		protected async Task<T> Get<T>(string path)
		{
			if (!this.auth.IsAuthenticated)
				throw new UnauthorizedException();

			try
			{
				var request = new HttpRequestMessage()
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://api.meetup.com/{path}")
				};

				request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.auth.AccessToken);

				var response = await this.client.SendAsync(request);
				response.EnsureSuccessStatusCode();
				var json = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(json);
			}
			catch (Exception ex)
			{
				throw new ServiceException(ex);
			}

		}

		#endregion
	}
}
