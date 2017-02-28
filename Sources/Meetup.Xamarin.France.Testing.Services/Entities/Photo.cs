using System;
using Newtonsoft.Json;

namespace Meetup.Xamarin.France.Testing.Services
{
	public class Photo
	{
		[JsonProperty("id")]
		public long Identifier { get; set; }

		[JsonProperty("photo_link")]
		public string Link { get; set; }

		[JsonProperty("highres_link")]
		public string HighresLink { get; set; }
	}
}
