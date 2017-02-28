namespace Meetup.Xamarin.France.Testing.Services
{
	using Newtonsoft.Json;

	public class Answer
	{
		[JsonProperty("question")]
		public string Question { get; set; }

		[JsonProperty("answer")]
		public string Value { get; set; }
	}
}
