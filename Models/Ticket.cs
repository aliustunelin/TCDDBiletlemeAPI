using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TCDDBiletlemeAPI.Models;


public class Ticket{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string VagonAd { get; set; }
    public int Kapasite { get; set; }
    public int DoluKoltukAdet { get; set; }

    
}
