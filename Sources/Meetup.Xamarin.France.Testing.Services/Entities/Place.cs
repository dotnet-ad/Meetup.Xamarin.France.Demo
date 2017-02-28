using System;
using Newtonsoft.Json;

namespace Meetup.Xamarin.France.Testing.Services
{
	public class Place
	{
		[JsonProperty("id")]
		public long id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("address_1")]
		public string Address1 { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("localized_country_name")]
		public string Country { get; set; }

		[JsonProperty("lat")]
		public double Latitude { get; set; }

		[JsonProperty("lon")]
		public double Longitude { get; set; }
	}
}
