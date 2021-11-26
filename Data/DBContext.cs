using System;
using System.Linq;

namespace FileData
{
    public class DBContext
    {

        public DBContext()
        {
            using (DBConnection dbConnection = new DBConnection())
            {
                var subTypes = dbConnection.Adult.Select(c => new
                {
                    firstname = c.FirstName,
                    lastname = c.LastName,
                    hairColor = c.HairColor,
                    eyeColor = c.EyeColor,
                    age = c.Age,
                    weight = c.Weight,
                    height = c.Height,
                    sex = c.Sex
                });
                var list = subTypes.ToList();
                foreach (var s in list)
                {
                    Console.WriteLine(s.firstname+s.lastname);
                }
            }
        }
    }
}