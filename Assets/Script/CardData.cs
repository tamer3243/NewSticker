using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card System/Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite cardImage;
    public int maxTargets;
    public List<ScriptableObject> abilityObjects; // Chứa danh sách các kỹ năng

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
