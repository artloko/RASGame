using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalCharacter : PlayerMainScript {

    uint currentMana;
    public uint MaxMana { get; set; }

    public MagicalCharacter(string currName, raceEnum currRace, classEnum currClass, genderEnum currGender,
        int currStrength, int currIntelligence, int currAgility) :
        base(currName, currRace, currClass, currGender, currStrength, currIntelligence, currAgility)
    {
        MaxMana = Convert.ToUInt32(100.0f * (1.0 + Convert.ToDouble(Intelligence) / 10));
        CurrentMana = MaxMana;
    }

    public uint CurrentMana
    {
        get { return currentMana; }
        set
        {
            if (value > MaxMana)
                currentMana = MaxMana;
            else
                currentMana = value;
        }
    }

    public bool isUsable(uint mana)
    {
        if ((int)CurrentMana - (int)mana >= 0)
        {
            return true;
        }
        return false;
    }

    public void addHealth(uint hpForHeal, PlayerMainScript obj = null)
    {
        if (isUsable(hpForHeal * 2))
        {
            currentMana -= hpForHeal * 2;
            if (CurrentHealth + hpForHeal >= MaxHealth)
                CurrentHealth = MaxHealth;
            else
                CurrentHealth += hpForHeal; 
        }
    }

    public override string Info()
    {
        return String.Format(base.Info() + "The character's current Mana is: {0}\\{1}\n", CurrentMana, MaxMana);
    }
}
