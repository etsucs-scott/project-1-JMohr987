namespace AdventureGame.Core;

//Defines the contract for attacking and taking damage
public interface ICharacter
{
    public void Attack(ICharacter enemy);
    
    public void TakeDamage (int damage);

}
    

