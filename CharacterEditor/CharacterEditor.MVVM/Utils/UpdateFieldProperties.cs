using System;
using System.Collections.Generic;
using CharacterEditor.MVVM.Utils;

namespace CharacterEditor.MVVM.Utils;

public static class UpdateFieldProperties
{
    private static readonly Dictionary<UpdateFieldValues, Type[]> Attributes =
        new()
        {
            {
                UpdateFieldValues.All,
                new[] { typeof(CharacterPropertyAttribute) }
            },
            {
                UpdateFieldValues.Stat, new[] { typeof(CharacterStatAttribute) }
            },
            {
                UpdateFieldValues.Level,
                new[] { typeof(CharacterLevelAttribute) }
            },

        };

    public static Type[] GetAttributes(UpdateFieldValues value)
    {
        return Attributes[value];
    }
}