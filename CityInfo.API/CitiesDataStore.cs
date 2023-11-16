using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore() { 
            Cities = new List<CityDto>()
            {
                new CityDto() 
                { 
                    Id = 1,
                    Name="New York City",
                    Description="The one with that big park.",
                    PointOfInterests = new List<PointOfInterestsDto>()
                    {
                        new PointOfInterestsDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States."
                        },
                        new PointOfInterestsDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattam.."
                        }
                    }
                },
                new CityDto() 
                { 
                    Id = 2,
                    Name="Antwerp",
                    Description="The one with the cathedral that was never really finished.",
                     PointOfInterests = new List<PointOfInterestsDto>()
                    {
                        new PointOfInterestsDto()
                        {
                            Id = 3,
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States."
                        },
                        new PointOfInterestsDto()
                        {
                            Id = 4,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattam.."
                        }
                    }
                },
                new CityDto() 
                { 
                    Id = 1,
                    Name="Pais",
                    Description="The one with that big tower.",
                     PointOfInterests = new List<PointOfInterestsDto>()
                    {
                        new PointOfInterestsDto()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after."
                        },
                        new PointOfInterestsDto()
                        {
                            Id = 6,
                            Name = "The louvre",
                            Description = "The world's largest museum."
                        }
                    }
                },
            };
        }
    }
}
