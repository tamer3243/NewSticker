using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ItemAbilities", menuName = "Ability/Item Abilities")]
public class ItemAbilities : ScriptableObject
{
    public List<ScriptableObject> abilityObjects; // Chứa các ScriptableObject

    public List<IAbility> GetAbilities()
    {
        List<IAbility> abilities = new List<IAbility>();
        foreach (var obj in abilityObjects)
        {
            if (obj is IAbility ability)
            {
                abilities.Add(ability);
            }
        }
        return abilities;
    }
}
