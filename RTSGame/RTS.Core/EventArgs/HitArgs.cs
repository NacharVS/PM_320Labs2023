﻿namespace RTS.Core.EventArgs;

public class HitArgs : System.EventArgs
{
    public int Damage { get; set; }
    public int PreviousHealth { get; set; }
    public int CurrentHealth { get; set; }

    public HitArgs(int damage, int unitHealth)
    {
        Damage = damage;
        PreviousHealth = unitHealth;
        CurrentHealth = unitHealth - damage;
    }
}