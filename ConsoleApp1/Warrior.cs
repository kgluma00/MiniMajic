using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Warrior : IWarrior
    {
        public string WarriorName { get; set; }

        public int WarriorHealth { get; set; }
        public WeaponType WeaponType { get; set; }

        public Warrior(string warriorName, int warriorHealth, WeaponType wepaonType)
        {
            WarriorName = warriorName;
            WarriorHealth = warriorHealth;
            WeaponType = wepaonType;
        }

        public void ListAllWarriors(List<Warrior> warriors)
        {
            foreach (var warrior in warriors)
            {
                Console.WriteLine(warrior.WarriorName + " ima " + warrior.WarriorHealth + " hp");
            }
        }
    }
}
