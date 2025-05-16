public interface ICharacter
{
   
    public Attribute attribute{ get; set; }
    public bool IsAlive();
    public bool CanAttack();
    void TakeDamage(int damage);
}