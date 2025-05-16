using StatMaster;

[System.Serializable]
public class CharacterStat<T> : ModifiableValue<T>
{
    public IModifiableValue<T> BaseFlatPlus { get; }
    public IModifiableValue<T> BasePlus { get; }
    public IModifiableValue<T> BaseTimes { get; }
    public IModifiableValue<T> TotalPlus { get; }
    public IModifiableValue<T> TotalTimes { get; }

    public CharacterStat(T initialValue) : base(initialValue)
    {
        BaseFlatPlus = new ModifiableValue<T>();
        BasePlus = new ModifiableValue<T>();
        BaseTimes = new ModifiableValue<T>(One());
        TotalPlus = new ModifiableValue<T>();
        TotalTimes = new ModifiableValue<T>(One());

        // Value = ((baseValue + BaseFlatPlus) * BaseTimes + BasePlus) * TotalTimes + TotalPlus.
        InitializeModifiers();
    }

    private void InitializeModifiers()
    {
        Modifiers.Add(100, Modifier.Plus(BaseFlatPlus));
        Modifiers.Add(200, Modifier.Times(BaseTimes));
        Modifiers.Add(300, Modifier.Plus(BasePlus));
        Modifiers.Add(400, Modifier.Times(TotalTimes));
        Modifiers.Add(500, Modifier.Plus(TotalPlus));
    }

    private static T One() => Modifier.GetOperator<T>().One;
}