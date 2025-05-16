using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "SkillSet")]
public class SkillData : ScriptableObject
{

    public string skillName;

    public Sprite skillIcon;
    [SerializeField] private List<ScriptableObject> abilityObjects; // Chứa danh sách các kỹ năng

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
