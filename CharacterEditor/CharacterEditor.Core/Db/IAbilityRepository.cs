﻿namespace CharacterEditor.Core.Db;

public interface IAbilityRepository
{
    public IEnumerable<Ability> GetAllAbilities();
}