
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class UserDetails<T>{
    [JsonIgnore]
    [BsonId]
    public ObjectId _id {get;set;}
    public T? profileImage {get;set;}
    public string userName{get;set;}
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string zip { get; set; }
    public string country { get; set; }
}

public class UpdatedProfileImage<T>{
    public string userName{get;set;}
    public T profileImage{get;set;}
}