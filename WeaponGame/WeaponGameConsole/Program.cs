using Weapons;
using Weapons.Heroes;
using WeaponsInterfaces;

var ct = new CounterTerrorist();
var engineer = new Engineer();

var m416 = new M416(30);
ct.PickUpWeapon(m416);
ct.AutoShoot(m416);
engineer.Upgrade(m416);
ct.Reload(m416);
ct.AutoShoot(m416);

var shotgun = new Shotgun(6);
shotgun.Shot();
shotgun.Shot();
shotgun.Shot();
shotgun.Reload();
shotgun.Repair();
shotgun.Shot();

var shuricen = new Shuriken();
ct.PickUpWeapon(shuricen as IWeapon);
ct.Throw(shuricen);


var axe = new Axe();
axe.Hit();
axe.Hit();
axe.Upgrade(); 
axe.Repair();
axe.Hit();

var knife = new Knife();
knife.Hit();
knife.Throw();
knife.Upgrade();
knife.Repair();
