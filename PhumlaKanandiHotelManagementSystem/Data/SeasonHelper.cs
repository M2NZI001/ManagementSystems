using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhumlaKanandiHotelManagementSystem.Data
{
    public static class SeasonHelper
    {
        public static string GetCurrentSeason(DateTime date)
        {
            // Define the start and end dates for each season
            DateTime lowSeasonStart = new DateTime(date.Year, 12, 1);
            DateTime lowSeasonEnd = new DateTime(date.Year, 12, 7);

            DateTime midSeasonStart = new DateTime(date.Year, 12, 8);
            DateTime midSeasonEnd = new DateTime(date.Year, 12, 15);

            DateTime highSeasonStart = new DateTime(date.Year, 12, 16);
            DateTime highSeasonEnd = new DateTime(date.Year, 12, 31);

            // Check the current date against the defined seasons
            if (date >= lowSeasonStart && date <= lowSeasonEnd)
            {
                return "Low Season";
            }
            else if (date >= midSeasonStart && date <= midSeasonEnd)
            {
                return "Mid Season";
            }
            else if (date >= highSeasonStart && date <= highSeasonEnd)
            {
                return "High Season";
            }

            // Default to Low Season if none match
            return "Low Season";
        }
    }

}

