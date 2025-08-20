using DataLayer.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MenuItemsRepository : IMenuItems
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Restoran;Integrated Security=True;";
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> list = new List<MenuItem>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "SELECT * FROM MenuItem";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    MenuItem mi = new MenuItem();
                    mi.Id = sqlDataReader.GetInt32(0);
                    mi.Title = sqlDataReader.GetString(1);
                    mi.Description = sqlDataReader.GetString(2);
                    mi.Price = sqlDataReader.GetDecimal(3);
                    list.Add(mi);

                }

            }
            return list;
        }

        public bool InsertMenuItem(MenuItem menuItem)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "insert into MenuItem(Title,Description,Price) values(@Title,@Description,@Price)";
                sqlCommand.Parameters.AddWithValue("@Title", menuItem.Title);
                sqlCommand.Parameters.AddWithValue("@Description", menuItem.Description);
                sqlCommand.Parameters.AddWithValue("@Price", menuItem.Price);

                int res = sqlCommand.ExecuteNonQuery();

                return res > 0;
            }
        }
    }
}
