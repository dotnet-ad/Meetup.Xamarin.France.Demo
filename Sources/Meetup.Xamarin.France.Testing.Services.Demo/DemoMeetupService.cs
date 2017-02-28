namespace Meetup.Xamarin.France.Testing.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class DemoMeetupService : IMeetupService
	{
		private Group group;

		private IEnumerable<Event> events;

		private IEnumerable<Member> members;

		private Group CreateGroup() => Faker.Faker.Default.Create<Group>();

		private IEnumerable<Event> CreateEvents() => Faker.Faker.Default.Create<IEnumerable<Event>>();

		private IEnumerable<Member> CreateMembers()
		{
			Faker.Faker.Default.Register<string>("name", () => $"{ Faker.Faker.Default.Create<string>("city") } { Faker.Faker.Default.Create<string>("city") }");

			var photoIndex = 1;
			Faker.Faker.Default.Register<Photo>(() =>
			{
				photoIndex = (photoIndex + 1) % 100;
				return new Photo() { Link = $"https://unsplash.it/200/300?image={photoIndex}", HighresLink = $"https://unsplash.it/200/300?image={photoIndex}" };
			});

			var allmembers = Faker.Faker.Default.Create<List<Member>>();
			allmembers.Insert(allmembers.Count() / 2, new Member()
			{
				Identifier = long.MaxValue,
				Name = "Alex Danvy",
				Biography = "Love IoT",
				City = "Paris",
				Country = "France",
				Photo = new Photo()
				{
					Identifier = 0,
					HighresLink = "https://a248.e.akamai.net/secure.meetupstatic.com/photos/member/5/7/9/6/member_122542422.jpeg",
					Link = "https://a248.e.akamai.net/secure.meetupstatic.com/photos/member/5/7/9/6/member_122542422.jpeg"
				},
				Answers = new Answer[]
				{
					new Answer() 
					{ 
						Question = "Avez-vous déjà développé pour iOS ou Android?",
						Value = "Android",
					},
					new Answer()
					{
						Question = "Avez-vous déjà utilisé XAMARIN?",
						Value = "Oui",
					},
					new Answer()
					{
						Question = "Si oui depuis combien de temps (en mois)?",
						Value = "2",
					},
					new Answer()
					{
						Question = "Etes vous Freelance?",
						Value = "Non",
					},
					new Answer()
					{
						Question = "Votre motivation pour rejoindre le groupe?",
						Value = "Partager la passion du code :-)",
					},
				}
			});
			Faker.Faker.Default.Reset();
			return allmembers;
		}

		public async Task<Group> GetGroupDetail(string groupid)
		{
			if (this.group == null)
			{
				await Task.Delay(1000);
				this.group = CreateGroup();
			}

			return this.group;
		}

		public async Task<IEnumerable<Event>> GetGroupEvents(string groupid)
		{
			if (events == null)
			{
				await Task.Delay(1000);
				events = CreateEvents();
			}

			return events;
		}

		public async Task<IEnumerable<Member>> GetGroupMembers(string groupid)
		{
			if (members == null)
			{
				await Task.Delay(1000);
				members = CreateMembers();
			}

			return members;
		}
	}
}
	