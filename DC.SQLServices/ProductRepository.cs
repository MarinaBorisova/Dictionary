using System;
using System.Collections.Generic;
using DC.Core;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

namespace DC.SQLServices
{
    public sealed class ProductRepository:IProductRepository
    {
        readonly string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool AddProduct(Product product)
        {
            if (product.Id != null && product.NameProduct != null)
            {
                string queryString = $"INSERT INTO dbo.Repository (Id,NameProduct) VALUES ('{product.Id}', '{product.NameProduct}')";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();

                    command.ExecuteNonQuery();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public Product GetProduct(string id)
        {
            string queryString = $"SELECT * FROM dbo.Repository WHERE CONVERT(VARCHAR, Id) = ('{id}')";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
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

        public IList<Product> GetProducts()
        {
            string queryString ="SELECT * FROM dbo.Repository;";
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
