### Build and run
```bash
dotnet build
dotnet run --project ./src/AdventureGame.Console
```

## Notes
--Controls--
Use the Arrow keys to move and press Z to drink potions

--Display--
# = Wall
. = Empty space
@ = Player
M = Monster
W = weapon
P = potion
E = exit

--Gameplay--
Get to the exit to win!
If you run out of HP it's game over!
You start at 100 HP
drink potions to recover 20 hp, max of 150 hp
Pickup weapons to get a damage modifier
Battles start with the player attacking the monster (when you walk over the monster tile)
Player attacks first
damage is 10 + weapon modifier
Monster attacks after
damage is always 10 and hp is from 30-50
Battle ends when either the player or monter dies
--UML--
AdventerGameUML.drawio.png
Diagram displays the associations the required classes have with each other

--git--
git clone https://github.com/etsucs-scott/project-1-JMohr987.git
Enter the project directory for building and running
dotnet build
dotnet run --project ./src/AdventureGame.Console
