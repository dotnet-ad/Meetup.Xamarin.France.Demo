namespace Meetup.Xamarin.France.Testing.Services
{
	using Newtonsoft.Json;

	public class Member
	{
		[JsonProperty("id")]
		public long Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("localized_country_name")]
		public string Country { get; set; }

		[JsonProperty("bio")]
		public string Biography { get; set; }

		[JsonProperty("photo")]
		public Photo Photo { get; set; }

		[JsonProperty("answers")]
		public Answer[] Answers { get; set; }
	}
}
