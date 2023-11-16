using AutoMapper;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API.Profiles
{
    public class PointOfInterstProfile: Profile
    {
        public PointOfInterstProfile()
        {
            CreateMap<PointOfInterst, PointOfInterestsDto>();
            CreateMap<PointOfInterestForCreationDto, PointOfInterst>();
            CreateMap<PointOfInterestForUpdateDto, PointOfInterst>();
            CreateMap<PointOfInterst, PointOfInterestForUpdateDto>();
        }
    }
}
