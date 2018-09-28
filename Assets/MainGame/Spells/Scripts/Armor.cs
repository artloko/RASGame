using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Spell
{
    static float mana;
    public static float time;

    public override void Magically(MagicalCharacter from, PlayerMainScript to = null, uint manaForCast = 0)
    {
        if (from.isUsable(Convert.ToUInt32(from.MaxMana * 0.2f)) && (from.Status != PlayerMainScript.statusEnum.Dead
            && from.Status != PlayerMainScript.statusEnum.Paralyzed))
        {
            mana = from.MaxMana * 0.2f;
            from.CurrentMana -= Convert.ToUInt32(mana);
            time = mana / 12f;
            if (time >= 1.0f)
                from.isInvulnerability = true;
        }
    }
    public override void Use()
    {
        //Use the item
        //Something might happen

        Debug.Log("Using " + name);
    }
}
