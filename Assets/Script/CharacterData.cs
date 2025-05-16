using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/CharacterData")]
public class CharacterData : ScriptableObject
{
    public BaseStat baseStat;
    public string nameCharacter;
    public Sprite characterSprite;
    public List<SkillData> skillSet;
}
