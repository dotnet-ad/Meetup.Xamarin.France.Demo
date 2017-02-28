namespace Meetup.Xamarin.France.Testing.Services
{
	using System;
	using Newtonsoft.Json;

	public class Event
	{
		[JsonProperty("id")]
		public long Identifier { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("time")]
		public long Timestamp { get; set; }

		[JsonIgnore]
		public DateTime Date => Timestamp.ToDateTime();

		[JsonProperty("venue")]
		public Place Place { get; set; }
	}
}
