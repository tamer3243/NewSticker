
[System.Serializable]
public class Attribute
{
    public CharacterStat<int> hp;
    public CharacterStat<int> atk;
    public CharacterStat<int> atkSpd;
    public CharacterStat<int> stamina;
    public CharacterStat<int> mana;
    // Constructor với giá trị ban đầu
   
      public Attribute()
    {
        hp = new CharacterStat<int>(0);
        atk = new CharacterStat<int>(0);
        atkSpd = new CharacterStat<int>(1);
        stamina = new CharacterStat<int>(0);
        mana = new CharacterStat<int>(0);
    }
    public Attribute(int hp, int atk, int atkSpd, int stamina, int mana)
    {
        this.hp = new CharacterStat<int>(hp);
        this.atk = new CharacterStat<int>(atk);
        this.atkSpd = new CharacterStat<int>(atkSpd);
        this.stamina = new CharacterStat<int>(stamina);
        this.mana = new CharacterStat<int>(mana);
    }

    // 🔹 Nạp chồng toán tử cộng (+)
    public static Attribute operator +(Attribute a, Attribute b)
    {
        return new Attribute(
            a.hp.Value + b.hp.Value,
            a.atk.Value + b.atk.Value,
            a.atkSpd.Value + b.atkSpd.Value,
            a.stamina.Value + b.stamina.Value,
            a.mana.Value + b.mana.Value
        );
    }

    // 🔹 Nạp chồng toán tử trừ (-)
    public static Attribute operator -(Attribute a, Attribute b)
    {
        return new Attribute(
            a.hp.Value - b.hp.Value,
            a.atk.Value - b.atk.Value,
            a.atkSpd.Value - b.atkSpd.Value,
            a.stamina.Value - b.stamina.Value,
            a.mana.Value - b.mana.Value
        );
    }
}
