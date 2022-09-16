// See https://aka.ms/new-console-template for more information

using Weaponry;
using Weaponry.Interfaces;
using Weaponry.Weapons;

var ak = new Ak47Rifle(30) { Damage = 64 };
(ak as IMeleeWeapon).MeleeAttack();

if (ak is IThrowable a)
    Console.WriteLine();

// var akAsFiregun = ak as IFiregun;
if (ak is IFiregun akAsFiregun)
    akAsFiregun.SingleShoot();


var akAsAuto = (IAutoShootFiregun)ak;
akAsAuto.Autoshoot();

var axe = new ThrowingAxe { MeleeDamage = 100, ThrowDamage = 250 };

axe.Throw();


IThrowable axeAsThrowing = (IThrowable)axe;

axeAsThrowing.Throw();


var axeAsMelee = (IMeleeWeapon)axe;
axeAsMelee.MeleeAttack();

var man = new Armyman();
man.Throw(axe);
man.MeleeAttack(axe);