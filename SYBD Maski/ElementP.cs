﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SYBD_Maski
{
    public class Product
    {
        public int id { get; set; }
        public string? Name { get; set; }          // Имя/Тип
        public int? Articul { get; set; }      // Артикул
        public string? Description { get; set; }  // Описание
        public String? Cost { get; set; }         // Цена
        public string? ImageSource { get; set; }  // Путь к изображению
    }
    public class Connection
    {
        static public List<Product> products = [];
        static public List<List<Product>> PagesProduct = [];
        public static string SQL_ConStr = @"Server=213.155.192.79,3002;Database=Maska_Def_LDP;Integrated Security=False;TrustServerCertificate=True;User=u23dmitriev;Password=be3v;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        public static void AddItem(List<Product> ProductPage)
        {
            List<Product> Product = [];
            foreach (var item in ProductPage)
            {
                Product.Add(item);
            }
            if (Product.Count > 0) 
                PagesProduct.Add(Product);
        }

    }
    public class Func
    {
        public static void LoadData()
        {


            string query = @"
            SELECT 
    Product.ProductTypeID AS TypeID,
    Product.Title AS Name, 
    Product.ArticleNumber AS Articul, 
    Product.MinCostForAgent AS Cost, 
    Product.Image AS ImageSource,
    COALESCE(STRING_AGG(Material.Title, ', '), '-') AS Description
FROM 
    Product
LEFT JOIN 
    ProductMaterial ON Product.ID = ProductMaterial.ProductID 
LEFT JOIN 
    Material ON ProductMaterial.MaterialID = Material.ID
GROUP BY 
	Product.ProductTypeID,
    Product.Title, 
    Product.ArticleNumber, 
    Product.MinCostForAgent, 
    Product.Image;";



            using (SqlConnection connection = new(Connection.SQL_ConStr))
            {
                connection.Open();

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String path;
                            if (File.Exists("Resources" + reader["ImageSource"].ToString()))
                            {
                                path = "Resources" + (reader["ImageSource"].ToString()).Replace('/', '\\');
                            }
                            else
                            {
                                path = "Resources\\products\\picture.png";
                            }
                            Product product = new()
                            {
                                id = Convert.ToInt32(reader["TypeID"]),
                                Name = reader["Name"].ToString(),
                                Articul = Int32.Parse(reader["Articul"].ToString()),
                                Description = "Материалы:" + reader["Description"].ToString(),
                                Cost = Convert.ToDouble(reader["Cost"]) + " руб.", // Добавляем "руб." к стоимости
                                ImageSource = path
                            };

                            Connection.products.Add(product);
                        }
                    }
                }
            }
            


        }
    }


}
