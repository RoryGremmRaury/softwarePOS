using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSystem.Models
{
    class DrinkSearch
    {
        public string drinkName { get; set; }
        
      

        static public List<string> GetData()
        {
        //    drinks = new ObservableCollection<Drink>(drinkEntities.Drink);
          //  List<string> data = new List<string>();
            //SqlConnection connection = new SqlConnection();
            //connection.ConnectionString = "Data Source=gk-ws01; Initial Catalog=pos_db; Integrated Security=True; MultipleActiveResultSets=True; App=EntityFramework";
            ////SqlDataAdapter adapter = new SqlDataAdapter();
            //SqlCommand command = new SqlCommand("select * from Drinks", connection);
            //command.CommandType = System.Data.CommandType.Text;
            //connection.Open();
            //using (SqlDataReader objReader = command.ExecuteReader())
            //{
            //    if (objReader.HasRows)
            //    {
            //        while (objReader.Read())
            //        {
            //            string item = objReader.GetString(objReader.GetOrdinal("Name"));
            //            data.Add(item);
            //        }
            //    }
            //}
            return GetData();



        }
    }
}
