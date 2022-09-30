using Core;
using Interfaces;
using Weapons;

Shooter shooter = new();

shooter.PickUpItem(new Knife());
shooter.PickUpItem(new Pistol());
shooter.PickUpItem(new Machinegun());

shooter.FireFromAllWeapons();

