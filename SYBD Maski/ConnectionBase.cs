namespace SYBD_Maski
{
    public class ConnectionBase
    {
        static public List<List<Product>> products_List = [];
        static public List<String> FilterElements = ["Все типы"];
        static public List<String> SortVar = ["По названию (по возарстанию)", "По названию (по убыванию)", "По номеру завода (по возврастанию)", "По номеру завода (по убыванию)","По цене (по возврастанию)", "По цене (по убыванию)"];
    }
    public class SortElimaent
    {
        static public void ElementsSort(object a)
        {

        }
    }
}