﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarcraftLibrary
{
    public class Blacksmith : Moveable
    {
        public Blacksmith(string name, int health = 20, int cost = 10, int lvl = 1, bool isDestroyed = false, int speed = 15, int damage = 0) : base(name, health, cost, lvl, isDestroyed, speed, damage)
        { }

        public void UpgradeArmor() { }

        public void UpgradeWeapoon() { }

        public void UpgradeBow() { }

        public override string Attack()
        {
            return $"{Name} не может нанести удар.{0}";
        }
    }
}
