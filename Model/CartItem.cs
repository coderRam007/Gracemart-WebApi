using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


public class CartItem{

    public int qty { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public double price { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public string image { get; set; }
    public Rating rating { get; set; }
  
}


// DTO for handling cart data
public class CartData

{
    [JsonIgnore]
    [BsonId]
     public ObjectId _id{get;set;}
    public string userName { get; set; }
    public List<CartItem> Items { get; set; }
}