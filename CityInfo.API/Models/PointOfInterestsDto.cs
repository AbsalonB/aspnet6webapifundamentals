﻿namespace CityInfo.API.Models
{
    public class PointOfInterestsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }

        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointOfInterests.Count;
            }
        }
        public ICollection<PointOfInterestsDto> PointOfInterests { get; set; } = new List<PointOfInterestsDto>();
    }
}
