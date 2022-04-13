using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TicketSale.Console
{
    internal class RuntimeData
    {
        private const string MOVIE_DB_PATH = @"movie.json";
        private const string SCHEDULE_DB_PATH = @"schedule.json";

        static RuntimeData()
        {
            s_movieContent = ReadFromFile(MOVIE_DB_PATH);
            s_scheduleContent = ReadFromFile(SCHEDULE_DB_PATH);
        }

        private static string s_movieContent;
        private static string s_scheduleContent;

        public static Movies GetAllMovies()
        {
            if (String.IsNullOrEmpty(s_movieContent))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Movies>(s_movieContent);
        }

        public static ScheduleData GetMovieSchedule(string MovieId)
        {
            if (String.IsNullOrEmpty(s_scheduleContent))
            {
                return null;
            }
            MovieSchedule movieSchedule = JsonConvert.DeserializeObject<MovieSchedule>(s_scheduleContent);
            foreach (ScheduleData schedule in movieSchedule.Values)
            {
                if (schedule.Id == MovieId)
                {
                    return schedule;
                }
            }
            return null;
        }

        private static string ReadFromFile(string dbName)
        {
            string strDbPath = Application.StartupPath;
            strDbPath = Path.Combine(strDbPath, dbName);
            string content = String.Empty;
            if (File.Exists(strDbPath))
            {
                using (StreamReader reader = new StreamReader(strDbPath, Encoding.Default))
                {
                    try
                    {
                        content = reader.ReadToEnd();
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }
            return content;
        }
    }
}
