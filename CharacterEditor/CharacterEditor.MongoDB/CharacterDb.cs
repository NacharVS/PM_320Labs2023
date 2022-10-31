﻿using CharacterEditor.Core.Matching;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CharacterEditor.MongoDB;

public class CharacterDb
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; internal set; } = null!;

    [BsonIgnoreIfNull] public string? Name { get; internal set; }
    [BsonIgnoreIfNull] public string? ClassName { get; internal set; }
    [BsonIgnoreIfDefault] public int Strength { get; internal set; }
    [BsonIgnoreIfDefault] public int Dexterity { get; internal set; }
    [BsonIgnoreIfDefault] public int Constitution { get; internal set; }
    [BsonIgnoreIfDefault] public int Intelligence { get; internal set; }
    [BsonIgnoreIfDefault] public int Experience { get; internal set; }
    [BsonIgnoreIfDefault] public IEnumerable<ItemDb>? Inventory { get; internal set; }
    [BsonIgnoreIfDefault] public IEnumerable<AbilityDb>? Abilities { get; internal set; }
    [BsonIgnoreIfDefault] public IEnumerable<MatchInfo>? MatchHistory { get; internal set; }
}