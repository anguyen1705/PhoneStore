using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models.Entities;
using PhoneStore.Models.db;

namespace PhoneStore.DAO
{
    public class ColorDAO
    {
        PhoneStoreEntities db = new PhoneStoreEntities();

        public List<Color> getListColor()
        {
            List<Color> colors = new List<Color>();

            String sql = "SELECT* FROM color WHERE color.activeFlag = 1";

            List<color> listcolors = db.colors.SqlQuery(sql).ToList<color>();
            foreach (color c in listcolors)
            {
                colors.Add(new Color(c.id, c.name));
            }
            return colors;

        }
    }
}