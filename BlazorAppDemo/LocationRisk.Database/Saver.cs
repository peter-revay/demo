using LocationRisk_Database.Context;
using LocationRisk_Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationRisk.Database
{
    public class Saver
    {
        public static bool SaveResult(int status, string? text, string? title,int? distance, string? image)
        {
            using var db = new BankaContext();
            try
            {
                db.SavedResults.Add(new Location_Risk_Data{Text = text, Status = status, Title = title,Distance = distance, Image = image});
                db.SaveChanges();

            } catch (Exception ex) {
                return false;
            }

            return true;
        }



    }
}
