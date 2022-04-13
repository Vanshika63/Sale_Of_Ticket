namespace TicketSale.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("***********************************************");
            System.Console.WriteLine("Welcome to online movie ticket booking system!");
            System.Console.WriteLine("Now let's start choose your favorite movie!");
            System.Console.WriteLine("***********************************************");
            System.Console.WriteLine();
            Movies movies = RuntimeData.GetAllMovies();
            int intMovieIndex = ConsoleController.ChooseFromList<MovieData>(movies.Values, "Movies");
            ScheduleData movieSchedule = RuntimeData.GetMovieSchedule(movies.Values[intMovieIndex].Id);
            System.Console.WriteLine();
            if (movieSchedule == null)
            {
                System.Console.WriteLine($"No schedule for movie <{movies.Values[intMovieIndex].Name}> yet, please be patient.");
            }
            else
            {
                movies.Values[intMovieIndex].ShowMovieDetail();
                System.Console.WriteLine();
                int scheduleIndex = ConsoleController.ChooseFromList<ScheduleDatum>(movieSchedule.Schedule, $"Schedule for movie <{movies.Values[intMovieIndex].Name}>");
                System.Console.WriteLine();
                if (movieSchedule.Schedule[scheduleIndex].SeatAvailable == 0)
                {
                    System.Console.WriteLine($"No seat available!");
                }
                else
                {
                    bool book = ConsoleController.ConfirmationYN("Do you want to book this movie?");
                    System.Console.WriteLine();
                    if (book)
                    {
                        System.Console.WriteLine($"You have successfully booked movie <{movies.Values[intMovieIndex].Name}> at {movieSchedule.Schedule[scheduleIndex].Time}");
                    }
                    else
                    {
                        System.Console.WriteLine("Ticket has not been booked.");
                    }
                }
            }
            System.Console.ReadLine();
            ConsoleController.QuitApplication();
        }
    }
}
