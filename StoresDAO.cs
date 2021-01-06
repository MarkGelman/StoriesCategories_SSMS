using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30122020_SSMS_EXAMEN
{
    class StoresDAO
    {
        string _query;
        SqlConnection connection = SSMS_ExamenConfig.connection;
        SqlCommand command;
        SqlDataReader reader;
       
        public void AddStore(Stores s)
        {

            _query = $"INSERT INTO Stores" +
                    $"VALUES ({s.Name},{s.Floor},{s.Name})";
            int row = NonReader(_query);
        }

        public void DeleteStore(int id)
        {
            _query = $"DELETE FROM Stores WHERE id ={id}";
            int row = NonReader(_query);
        }

        public List<Stores> GetAllStores()
        {
            _query = $"SELECT * FROM Stores";
            return Reader(_query);
        }

        public List<Stores> GetById(int id)
        {
            _query = $"SELECT * FROM Stores Where id = {id}";
            return Reader(_query);

        }


        public void UpdateStore(int id, Stores s)
        {
            _query = $"UPDATE Stores SET id = {s.Id},name = {s.Name}, floor = {s.Floor},category_id = {s.Category_Id} ";
            int row = NonReader(_query);
        }

        public List<Stores> Reader(string query)
        {
            List<Stores> allStores = new List<Stores>();
            using (command = new SqlCommand(query, connection))
            {
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Stores t = new Stores

                        {
                            Id = (long)reader["id"],
                            Category_Id = (long)reader["category_id"],
                            Floor = (int)reader["floor"],
                            Name = (string)reader["name"]
                        };
                        allStores.Add(t);
                    }
                }
            }
            return allStores;
        }

        public int NonReader(string query)
        {
            using (command = new SqlCommand(query, connection))
            {
                return command.ExecuteNonQuery();
            }
        }

        public List<Stores> GetAllByCategoryAndFloor (string category, int floor)
        {
            _query = $"SELEC s.name FROM Categories c JOIN Stores s ON s.category_id = c.id WHERE s.floor = {floor} AND c.name = {category} ";
            return Reader(_query);
        }

    }
}
