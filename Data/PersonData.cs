﻿using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersonData
    {
        private string connectionString = "Data Source= LAB1504-15\\SQLEXPRESS;Initial Catalog= FACTURADB;Integrated Security=True;";
        public List<Product> Get()
        {
            List<Product> people = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetPeopleProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = reader.GetInt32("product_id");
                        string name = reader.GetString("name");
                        decimal price = reader.GetDecimal("price");
                        int stock = reader.GetInt32("stock");

                        people.Add(new Product(id, name, price, stock));
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según tus necesidades
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return people;
        }


        public void Insert(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertProductsProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@product_id", product.product_id);
                command.Parameters.AddWithValue("@name", product.name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@stock", product.stock);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según tus necesidades
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateProductsProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@product_id", product.product_id);
                command.Parameters.AddWithValue("@name", product.name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@stock", product.stock);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según tus necesidades
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void Delete(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteProductsProcedure", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@product_id", productId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Manejar la excepción según tus necesidades
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;

//namespace DataAccess
//{
//    internal class DataAccessLayer
//    {
//        private string connectionString = "tu_cadena_de_conexión";

//        public List<Person> GetPeople()
//        {
//            List<Person> people = new List<Person>();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                SqlCommand command = new SqlCommand("GetPeopleProcedure", connection);
//                command.CommandType = CommandType.StoredProcedure;

//                try
//                {
//                    connection.Open();
//                    SqlDataReader reader = command.ExecuteReader();

//                    while (reader.Read())
//                    {
//                        Person person = new Person();
//                        person.PersonID = Convert.ToInt32(reader["PersonID"]);
//                        person.FirstName = reader["FirstName"].ToString();
//                        person.LastName = reader["LastName"].ToString();
//                        person.Age = Convert.ToInt32(reader["Age"]);

//                        people.Add(person);
//                    }

//                    reader.Close();
//                }
//                catch (Exception ex)
//                {
//                    // Manejar la excepción según tus necesidades
//                    Console.WriteLine("Error: " + ex.Message);
//                }
//            }

//            return people;
//        }
//    }
//}

//namespace Entity
//{
//    internal class Person
//    {
//        public int PersonID { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public int Age { get; set; }
//    }
//}