using System;
using System.Collections.Generic;
using DC.Core;
using Microsoft.Build.Tasks;
using Microsoft.Data.SqlClient;

namespace DC.SQLServices
{
    public sealed class ProductRepository:IProductRepository
    {
        readonly string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool ProductsAdd(string id, string nameProduct)
        {
            if (id != null && nameProduct != null)
            {
                string queryString = $"INSERT INTO dbo.Repository (Id,NameProduct) VALUES (@Id, @NameProduct)";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();

                    SqlParameter idParameter = new SqlParameter("@Id", id);
                    command.Parameters.Add(idParameter);
                    SqlParameter nameParameter = new SqlParameter("@NameProduct", nameProduct);
                    command.Parameters.Add(nameParameter);

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public Product ProductsGetbyId(string id)
        {
            string queryString = $"SELECT * FROM dbo.Repository WHERE CONVERT(VARCHAR, Id) = (@Id)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlParameter idParameter = new SqlParameter("@Id", id);
                command.Parameters.Add(idParameter);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Product(reader[0].ToString(), reader[1].ToString());
                    }
                    else
                    {
                        return new Product(null, null);
                    }
                }
            }
        }

        public IList<Product> ProductsGetAll()
        {
            string queryString = "GetProducts";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<Product> products = new List<Product>();
                    while (reader.Read())
                    {
                        products.Add(new Product(Convert.ToString(reader[0]), Convert.ToString(reader[1])));
                    }
                    return products;
                }
            }
        }
    }
}
