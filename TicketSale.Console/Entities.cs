using Newtonsoft.Json;

namespace TicketSale.Console
{
    public class MovieData
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Length")]
        public int Length { get; set; }
        [JsonProperty("MainActor")]
        public string MainActor { get; set; }
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [JsonProperty("Language")]
        public string Language { get; set; }
        public override string ToString()
        {
            return $"{Name} - {MainActor}";
        }
        public void ShowMovieDetail()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("*******************************");
            System.Console.WriteLine($"Name:       {Name}");
            System.Console.WriteLine($"Main Actor: {MainActor}");
            System.Console.WriteLine($"Duration:   {Duration}");
            System.Console.WriteLine($"Genre:      {Genre}");
            System.Console.WriteLine($"Language:   {Language}");
            System.Console.WriteLine("*******************************");
        }
        public string Duration
        {
            get
            {
                int intHour = Length / 60;
                int intMinutes = Length % 60;
                return $"{intHour}hr {intMinutes}min";
            }
            
        }
    }

    public class Movies
    {
        [JsonProperty("Values")]
        public MovieData[] Values { get; set; }
    }

    public class ScheduleDatum
    {
        [JsonProperty("Time")]
        public string Time { get; set; }
        [JsonProperty("SeatAvailable")]
        public int SeatAvailable { get; set; }
        public override string ToString()
        {
            return $"Time: {Time} Seat Available: {SeatAvailable.ToString().PadLeft(2, ' ')} left.";
        }
    }

    public class ScheduleData
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Schedule")]
        public ScheduleDatum[] Schedule { get; set; }
    }

    public class MovieSchedule
    {
        [JsonProperty("Values")]
        public ScheduleData[] Values { get; set; }
    }
}
