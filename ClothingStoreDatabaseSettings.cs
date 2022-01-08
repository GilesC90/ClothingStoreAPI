namespace ClothingStoreApi.Models
{
    public class ClothingStoreDatabaseSettings
    {
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ClothingCollectionName { get; set; } = null!;
    }
}