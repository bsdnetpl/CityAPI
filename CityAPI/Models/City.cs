namespace CityAPI.Models
{
    public class City
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public int population { get; set; }

    }
}
