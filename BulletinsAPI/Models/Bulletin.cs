using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BulletinsAPI.Models
{
    public class Bulletin
    {
        public Guid Id;
        public string Description;
        public string Title;
        public string Url;
        public int Votes;
        public string AvatarUrl;
        public string BulletinImageUrl;
    }
}