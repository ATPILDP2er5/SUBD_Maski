namespace SYBD_Maski
{
    public interface IProduct
    {
        int? Articul { get; set; }
        string Cost { get; set; }
        string? Description { get; set; }
        string? ImageSource { get; set; }
        string? Name { get; set; }
    }
}