var knife = new Knife(50);
var shuriken = new Shuriken();
var katana = new Katana(70);
var pistol = new Pistol(100);
var machinegun = new Machinegun(120);
var Valerii = new Gunslinger();
var Fedya = new Mechanic();

Valerii.PicUpWeapon(pistol);
Valerii.PicUpWeapon(machinegun);
Valerii.MultiFire(machinegun);
Valerii.ThrowThrowableWeapon(knife);
Valerii.ThrowThrowableWeapon(shuriken);
Valerii.Fire(pistol);
Valerii.HitByMleeWeapon(katana);
Valerii.Reload(pistol);

Fedya.UpgradeWeapon(katana);
Valerii.HitByMleeWeapon(katana);
Fedya.UpgradeWeapon(pistol);
Valerii.Fire(pistol);
Fedya.ShowInfo(pistol);
Fedya.RepairWeapon(pistol);
Fedya.ShowInfo(pistol);