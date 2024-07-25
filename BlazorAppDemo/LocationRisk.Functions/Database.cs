using LocationRisk_Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocationRisk.Functions
{
    public static class Database
    {

        public static List<Location_Risk_Data> LoadResults(int count)
        {
            return LocationRisk.Database.Reader.LoadResults(count);
        }

        public static bool SaveResult(int status, string? text, string? title, int? distance, string? image)
        {
            return LocationRisk.Database.Saver.SaveResult(status, text, title,distance, image);
        }
    }
}
