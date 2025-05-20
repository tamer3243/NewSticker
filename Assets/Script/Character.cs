using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using DG.Tweening;
using MyBox;
using NUnit.Framework;
using StatMaster;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour, ICharacter
{
    Attribute currentAttribute;
    public Backpack Backpack;
    public bool canAttack = true;
    public bool canControl;
    public Attribute attribute { get => currentAttribute; set => attribute = value; }
    public Skill[] SkillSet = new Skill[4];
    public Character character;
    public CharacterData data;
    void Start()
    {
        character = GetComponent<Character>();
        Init();
    }

    [ButtonMethod]
    public void Init()
    {
        InitStat();
        InitSkillSet();
    }

    public void InitStat()
    {

        currentAttribute = new(data.baseStat.hp, data.baseStat.atk,  data.baseStat.stamina, data.baseStat.mana);
        ItemStat totalStatBonus = new ItemStat();
        Backpack.items.ForEach(item => totalStatBonus += item.statbonus);

        currentAttribute.hp.Modifiers.Add(Modifier.Plus(totalStatBonus.hp, "+hp"));
        currentAttribute.atk.Modifiers.Add(Modifier.Plus(totalStatBonus.atk, "+atk"));
        currentAttribute.stamina.Modifiers.Add(Modifier.Plus(totalStatBonus.stamina, "+stamina"));
        currentAttribute.mana.Modifiers.Add(Modifier.Plus(totalStatBonus.mana, "+mana"));

        Debug.Log(currentAttribute.atk.Value);
    }
    public void InitSkillSet()
    {
        for (int i = 0; i < SkillSet.Length; i++)
        {
            SkillSet[i] = new Skill(character, data.skillSet[0]);
        }
    }

    public void TakeDamage(int damage)
    {
        attribute.hp.BaseFlatPlus.Modifiers.Add(Modifier.Minus(damage));
    }
    public void Equip(Item item) => Backpack.items.Add(item);

    public bool IsAlive()
    {
        if (currentAttribute.hp.Value > 0) return true;
        return false;
    }

    public bool CanAttack()
    {
        return canAttack;
    }
  
    public void TakeDamage(object damage)
    {
        throw new System.NotImplementedException();
    }
}
