using CityApi.Core.Enums;

namespace CityApi.Core.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Denizli";
        public int Population { get; set; } = 1056332;

        public RegionOfCity Region { get; set; } = RegionOfCity.Ege;

        public User? User { get; set; }
    }
}
