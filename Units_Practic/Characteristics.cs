﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Practic
{
    public class Characteristics
    {
        double strength;
        int strenghtMax;
        int strenghtMin;

        double dexterity;
        int dexterityMax;
        int dexterityMin;

        double constitution;
        int constitutionMax;
        int constitutionMin;

        double intelligence;
        int intelligenceMax;
        int intelligenceMin;

        public Characteristics(Units unt)
        {
            switch (unt)
            {
                case Units.Warrior:
                    strenghtMax = 250;
                    strenghtMin = 30;

                    dexterity = 15;
                    dexterityMax = 70;
                    dexterityMin = 15;

                    constitutionMax = 100;
                    constitutionMin = 20;

                    intelligenceMax = 50;
                    intelligenceMin = 10;
                break;

                case Units.Rogue:
                    strenghtMax = 55;
                    strenghtMin = 15;

                    dexterityMax = 250;
                    dexterityMin = 30;

                    constitutionMax = 80;
                    constitutionMin = 20;

                    intelligenceMax = 70;
                    intelligenceMin = 15;
                break;

                case Units.Wizard:
                    strenghtMax = 45;
                    strenghtMin = 10;

                    dexterityMax = 70;
                    dexterityMin = 20;

                    constitutionMax = 60;
                    constitutionMin = 15;

                    intelligenceMax = 250;
                    intelligenceMin = 35;
                break;

                default:
                    throw new Exception("Unknown unit");
                break;
            }

            strength = strenghtMin;
            dexterity = dexterityMin;
            constitution = constitutionMin;
            intelligence = intelligenceMin;
        }

        public double HealthUpdate(Units unt)
        {
            double health;

            switch (unt)
            {
                case Units.Warrior:
                    health = strength * 2 + constitution * 10;
                    break;

                case Units.Rogue:
                    health = strength + constitution * 6;
                    break;

                case Units.Wizard:
                    health = strength + constitution * 3;
                    break;

                default:
                    throw new Exception("Unknown unit");
                    break;
            }

            return health;
        }

        public double ManaUpdate(Units unt)
        {
            double mana;

            switch (unt)
            {
                case Units.Warrior:
                    mana = intelligence;
                    break;

                case Units.Rogue:
                    mana = intelligence * 1.5;
                    break;

                case Units.Wizard:
                    mana = intelligence * 2;
                    break;

                default:
                    throw new Exception("Unknown unit");
                    break;
            }

            return mana;
        }

        public double ManaAttackUpdate(Units unt)
        {
            double manaAttack;

            switch (unt)
            {
                case Units.Warrior:
                    manaAttack = intelligence;
                    break;

                case Units.Rogue:
                    manaAttack = intelligence * 2;
                    break;

                case Units.Wizard:
                    manaAttack = intelligence * 5;
                    break;

                default:
                    throw new Exception("Unknown unit");
                    break;
            }

            return manaAttack;
        }

        public double AttackUpdate(Units unt)
        {
            double attack;

            switch (unt)
            {
                case Units.Warrior:
                    attack = strength * 5 + dexterity;
                    break;

                case Units.Rogue:
                    attack = strength * 2 + dexterity * 4;
                    break;

                case Units.Wizard:
                    attack = strength * 3;
                    break;

                default:
                    throw new Exception("Unknown unit");
                    break;
            }

            return attack;
        }

        public double PhysicalProtectionUpdate(Units unt)
        {
            double physicalProtection;

            switch (unt)
            {
                case Units.Warrior:
                    physicalProtection = dexterity + constitution * 2;
                    break;

                case Units.Rogue:
                    physicalProtection = dexterity * 1.5;
                    break;

                case Units.Wizard:
                    physicalProtection = dexterity * 0.5 + constitution;
                    break;

                default:
                    throw new Exception("Unknown unit");
                    break;
            }

            return physicalProtection;
        }
    }
}
