﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryWithInterfaces
{
    public class Machinegun : IWeapon, IMultiShoot
    {
        public int Damage { get; set; }
        public int Durability { get; set; }
        public int MaxShots { get; set; }
        public int CurrentShots { get; set; }

        public Machinegun(int damage, int durability, int maxShots)
        {
            Damage = damage;
            Durability = durability;
            MaxShots = maxShots;
            CurrentShots = maxShots;
        }

        public void Shoot() 
        {
            if (Durability > 0 && CurrentShots > 0)
            {
                Durability -= 1;
                CurrentShots -= 1;
                Console.WriteLine($"{GetType().Name} выстрелил с уроном {Damage}");
            }
            else
            {
                Console.WriteLine($"{GetType().Name} не смог выстрелить");
            }
        }

        public void Upgrade()
        {
            Damage += 3;
            Console.WriteLine($"{GetType().Name} был улучшен");
        }

        public void Repair()
        {
            Durability += 1;
            Console.WriteLine($"{GetType().Name} был починен");
        }

        public void Reload()
        {
            CurrentShots = MaxShots;
            Console.WriteLine($"{GetType().Name} перезаражен");
        }

        public void MultiShoot()
        {
            CurrentShots -= 3;
            Console.WriteLine($"{GetType().Name} выстрелил очередью с уроном {Damage*3}");
        }
    }
}