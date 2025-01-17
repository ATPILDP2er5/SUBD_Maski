﻿using Microsoft.Data.SqlClient;

namespace SYBD_Maski
{
    public class ConnectionBase
    {
        static public List<List<Product>> products_List = [];
        static public List<String> FilterElements = ["Все типы"];
        static public List<String> SortVar = ["Без сортировки","По названию (по возарстанию)", "По названию (по убыванию)", "По номеру завода (по возврастанию)", "По номеру завода (по убыванию)","По цене (по возврастанию)", "По цене (по убыванию)"];
    }
    public class SortElimaent
    {
        static public void GetElementsSort()
        {
            string query = @"
            SELECT        Title
FROM            ProductType";
            using (SqlConnection connection = new(Connection.SQL_ConStr))
            {
                connection.Open();

                using (SqlCommand command = new(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ConnectionBase.FilterElements.Add(reader["Title"].ToString());
                        }
                    }
                }
            }
        }
        public static void SortElements()
        {

        }
        public static void ShearchElementDinamics(object a)
        {

        }
    }
}