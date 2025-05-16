using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStat
{

    public int hp;
    public int atk;
    public int atkSpd;
    public int stamina;
    public int mana;


    public ItemStat() { }

    public ItemStat(int hp, int atk, int atkSpd, int stamina, int mana)
    {
        this.hp = hp;
        this.atk = atk;
        this.atkSpd = atkSpd;
        this.stamina = stamina;
        this.mana = mana;
    }
    // Nạp chồng toán tử +
    public static ItemStat operator +(ItemStat a, ItemStat b)
    {
        return new ItemStat(
            a.hp + b.hp,
            a.atk + b.atk,
            a.atkSpd + b.atkSpd,
            a.stamina + b.stamina,
            a.mana + b.mana
        );
    }

    // Nạp chồng toán tử -
    public static ItemStat operator -(ItemStat a, ItemStat b)
    {
        return new ItemStat(
            a.hp - b.hp,
            a.atk - b.atk,
            a.atkSpd - b.atkSpd,
            a.stamina - b.stamina,
            a.mana - b.mana
        );
    }
}
