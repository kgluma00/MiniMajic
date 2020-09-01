using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IWarrior
    {
        public void ListAllWarriors(List<Warrior> warriors);

        public string WarriorName { get; set; }

        public int WarriorHealth { get; set; }
    }
}
