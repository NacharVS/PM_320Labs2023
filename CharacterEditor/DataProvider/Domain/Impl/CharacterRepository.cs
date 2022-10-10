using DataProvider.Models;
using Editor.Core;
using Editor.Core.Characters;
using MongoDB.Driver;

namespace DataProvider.Domain.Impl
{
    public class CharacterRepository : BaseRepository<Character, CharacterDb>
    {
        public CharacterRepository(MongoConnection<CharacterDb> connection) : base(connection)
        {
        }

        protected override Character? InitializeEntity(CharacterDb model)
        {
            return CastToEntity(model);
        }

        protected override Character? CastToEntity(CharacterDb model)
        {
            switch (model?.Class)
            {
                case "Warrior":
                    return new Warrior(
                        model.AvailableSkillPoints,
                        model.Experience,
                        model.Strength,
                        model.Dexterity,
                        model.Constitution,
                        model.Intelligence,
                        model.Abilities,
                        model.Name,
                        model.Inventory
                    );
                case "Rogue":
                    return new Rogue(
                        model.AvailableSkillPoints,
                        model.Experience,
                        model.Strength,
                        model.Dexterity,
                        model.Constitution,
                        model.Intelligence,
                        model.Abilities,
                        model.Name,
                        model.Inventory
                    );
                case "Wizard":
                    return new Wizard(
                        model.AvailableSkillPoints,
                        model.Experience,
                        model.Strength,
                        model.Dexterity,
                        model.Constitution,
                        model.Intelligence,
                        model.Abilities,
                        model.Name,
                        model.Inventory
                    );
            }

            return null;
        }
    }
}