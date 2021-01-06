using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30122020_SSMS_EXAMEN
{
    class CategoriesDAO
    {
        string _query;
        SqlConnection connection = SSMS_ExamenConfig.connection;
        SqlCommand command;
        
        public void AddCategory(Categories c)
        {

            _query = $"INSERT INTO Categories" +
                    $"VALUES ({ c.Id},{ c.Name})";
            int row = NonReader(_query);
        }

        public void DeleteCategory(int id)
        {
            _query = $"DELETE FROM Categories WHERE id ={id}";
            int row = NonReader(_query);
        }

        public void GetAllCategories()
        {
            _query = $"SELECT * FROM Categories";
            Reader(_query).ForEach(t => Console.WriteLine($"{t}"));
        }


        public void UpdateCategory(int id, Categories c)
        {
            _query = $"UPDATE Category SET id = {c.Id},name = {c.Name}";
            int row = NonReader(_query);
        }

        public List<Categories> Reader(string query)
        {
            List<Categories> allCategories = new List<Categories>();
            using (command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Categories t = new Categories

                        {
                            Id = (Int64)reader["id"],
                            Name = (string)reader["name"]
                        };
                        allCategories.Add(t);
                    }
                }
                return allCategories;
            }
        }

        public int NonReader(string query)
        {
            using (command = new SqlCommand(query, connection))
            {
                return command.ExecuteNonQuery();
            }
        }

        public List<Categories> GetById (int id)
        {
            _query = $"SELECT * FROM Categories Where id = {id}";
            return Reader(_query);
           
        }

        public List<Categories> GetLargestTypeOfStories ()
        {
            _query ="SELECT c.id,c.name" +
                    "FROM (SELECT category_id, Count(*) Numbers_Of_Category" +
                            "FROM Stores" +
                            "CROUP BY category_id) nn" +
                    "JOIN Categories c ON  Stores.category_id = Categories.id" +
                    "WHERE nn.Numbers_Of_Category  =(" +
                                                       "SELECT TOP 1 Count(*) FROM Stores" +
                                                       "GROUP BY category_id" +
                                                       "Order BY Count(*) DESC);";
            return Reader(_query);
        }
    
    }
}
