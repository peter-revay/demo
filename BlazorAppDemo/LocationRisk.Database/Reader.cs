using LocationRisk_Database.Context;
using LocationRisk_Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationRisk.Database
{
    public class Reader
    {
        public static List<Location_Risk_Data> LoadResults(int count)
        {
            using var db = new BankaContext();
            try
            {
                var data = db.SavedResults.Take(count).ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool LoadResult(int count, out string text, out string title, out string image, out int status)
        {
            text = string.Empty;
            title = string.Empty;
            image = string.Empty;
            status = 1;

            using var db = new BankaContext();
            try
            {
                var data = db.SavedResults.Take(1).First();
                if (data != null)
                {
                    text = data.Text;
                    title = data.Title;
                    image = data.Image;
                    status = data.Status ?? 1;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
