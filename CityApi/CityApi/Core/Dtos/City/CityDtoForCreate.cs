using CityApi.Core.Enums;

namespace CityApi.Core.Dtos.City
{
    public class CityDtoForCreate
    {
        public string Name { get; set; } = "Denizli";
        public int Population { get; set; } = 1056332;

        public RegionOfCity Region { get; set; } = RegionOfCity.Ege;
    }
}
