namespace CityAPI.Models
{
    public class Vehicle
    {
      public Guid Id { get; set; }
      public  int min_population { set; get; } 
      public int max_population { set; get; } 
      public string vehicle { set; get; } = string.Empty;
    }
}
