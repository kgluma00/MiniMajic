using NRules;
using NRules.Fluent;
using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            List<Warrior> warriors = new List<Warrior>();

            var sword = new Sword(rng.Next(11, 19));
            var spear = new Spear(rng.Next(11, 19));
            var hammer = new Hammer(rng.Next(11, 19));

            var weaponType = new WeaponType(sword, spear, hammer);

            for (var i = 0; i < 5; i++)
            {
                var hp = rng.Next(90, 100);
                string warriorName = "Sime " + i.ToString();
                Warrior warrior = new Warrior(warriorName, hp, weaponType);
                warriors.Add(warrior);
            }

            Console.WriteLine("Starting battle...");
            var warIdx = rng.Next(warriors.Count);
            var warrior1 = warriors[warIdx];

            var warIdx2 = rng.Next(warriors.Count);
            var warrior2 = warriors[warIdx2];

            var winner = StartBattle(warrior1, warrior2);

            Console.WriteLine($"The winner is {winner.WarriorName} with {winner.WarriorHealth} hp left!");
        }

        private static Warrior StartBattle(Warrior warrior1, Warrior warrior2)
        {
            bool battle = true;
            Random random = new Random();

            bool alive = true;

            while (battle)
            {
                int damage = warrior1.WeaponType.Hammer.WeaponStrength;

                warrior1.WarriorHealth = warrior1.WarriorHealth - damage;

                alive = checkAlive(warrior1);

                Console.WriteLine($"Warrior 1 attacked and dealt {damage} points of damage!");

                if (!alive)
                {
                    break;
                }

                alive = true;

                int damage2 = warrior2.WeaponType.Sword.WeaponStrength;

                warrior2.WarriorHealth = warrior2.WarriorHealth - damage2;

                Console.WriteLine($"Warrior 2 attacked and dealt {damage} points of damage!");
                alive = checkAlive(warrior2);
                if (!alive)
                {
                    break;
                }
            }

            Warrior winner;

            if (warrior1.WarriorHealth > 0)
            {
                winner = warrior1;
            }
            else
            {
                winner = warrior2;
            }

            return winner;
        }

        private static bool checkAlive(Warrior warrior)
        {
            bool alive = true;

            if (warrior.WarriorHealth > 0)
            {
                alive = true;
            }
            else
            {
                alive = false;
            }

            return alive;
        }
    }
}


