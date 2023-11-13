using System.Text.Json.Serialization;

namespace CityApi.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RegionOfCity
    {
        Marmara = 1,
        Ege = 2,
        Akdeniz = 3,
        IcAnadolu = 4,
        Karadeniz = 5,
        DoguAnadolu = 6,
        GuneyDoguAnadolu = 7
    }
}
