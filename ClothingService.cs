using ClothingStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ClothingStoreApi.Services
{
    public class ClothingService
    {
    private readonly IMongoCollection<Hoodie> _clothingCollection;
    public ClothingService
    (
        IOptions<ClothingStoreDatabaseSettings> clothingStoreDatabaseSettings
    )
    {
        var mongoClient = new MongoClient
        (
            clothingStoreDatabaseSettings.Value.ConnectionString
        );

        var mongoDatabase = mongoClient.GetDatabase
        (
            clothingStoreDatabaseSettings.Value.DatabaseName
        );

        _clothingCollection = mongoDatabase.GetCollection<Hoodie>
        (
            clothingStoreDatabaseSettings.Value.ClothingCollectionName
        );
    }

    public async Task<List<Hoodie>> GetAsync() =>
        await _clothingCollection.Find(_ => true).ToListAsync();

    public async Task<Hoodie?> GetAsync(string id) =>
        await _clothingCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Hoodie newHoodie) =>
        await _clothingCollection.InsertOneAsync(newHoodie);

    public async Task UpdateAsync(string id, Hoodie updatedHoodie) =>
        await _clothingCollection.ReplaceOneAsync(x => x.Id == id, updatedHoodie);

    public async Task RemoveAsync(string id) =>
        await _clothingCollection.DeleteOneAsync(x => x.Id == id);

    }
}