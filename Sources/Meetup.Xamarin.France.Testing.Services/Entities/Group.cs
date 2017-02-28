namespace Meetup.Xamarin.France.Testing.Services
{
	using Newtonsoft.Json;

	public class Group
	{
		[JsonProperty("id")]
		public long id { get; set; }
		
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("next_event")]
		public Event NextEvent { get; set; }
	}
}
