using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SQLandCommandRunner;

namespace COmmandRunner
{
    public class StockRepository
    {
       string _connString = "";
        public List<Stock> GetAllStocks()
        {
            var stocks = new List<Stock>();

            using (var conn = new SqlConnection(_connString))
            {
                conn.Open();

                var selectQuery = "select * from stock";

                var command = new SqlCommand(selectQuery, conn);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var stock = new Stock();

                    stock.Id = Convert.ToInt32(reader["Id"]);
                    stock.ProductName = reader["ProductName"].ToString();
                    stock.Quantity = Convert.ToInt32(reader["Quantity"]);

                    stocks.Add(stock);
                }
            }

            return stocks;
        }
    }
}