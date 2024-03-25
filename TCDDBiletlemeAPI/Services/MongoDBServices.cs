using TCDDBiletlemeAPI.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace TCDDBiletlemeAPI.Services;


public class MongoDBServices{
    private readonly IMongoCollection<Ticket> _todosCollection;

    public MongoDBServices(IOptions<MongoDBSetting> mongoDBSettings){
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _todosCollection = database.GetCollection<Ticket>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Ticket todo){
        await _todosCollection.InsertOneAsync(todo);
        return;
    }

    public async Task<List<Ticket>> GetAsync(){
        return await _todosCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddtoTodoAsync(string id, string todoID){
        //eşleşenleri buluyor, güncelleme burası, put
        FilterDefinition<Ticket> filterDefinition = Builders<Ticket>.Filter.Eq("Id", id);
        UpdateDefinition<Ticket> updateDefinition = Builders<Ticket>.Update.AddToSet<String>("todosId", todoID);
        await _todosCollection.UpdateOneAsync(filterDefinition, updateDefinition);
        return ;
    }

    public async Task DeleteAsync(string id){
        FilterDefinition<Ticket> filterDefinition = Builders<Ticket>.Filter.Eq("Id", id);
        await _todosCollection.DeleteOneAsync(filterDefinition);
        return;
    }
}