namespace AdventureGame.Core;

public interface ICharacter
{
    public void Attack(ICharacter enemy);
    
    public void TakeDamage (int damage);

}
    

