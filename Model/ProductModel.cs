using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Rating
{
    [JsonIgnore]
    [BsonId]
     public ObjectId id{get;set;}

    public double rate { get; set; }
    public int count { get; set; }
}

// Main ImageModel
public class ProductModel
{
    [JsonIgnore]
    [BsonId]
     public ObjectId _id{get;set;}
    public int id { get; set; }
    public string title { get; set; }
    public double price { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public string image { get; set; }
    public Rating rating { get; set; }
}
