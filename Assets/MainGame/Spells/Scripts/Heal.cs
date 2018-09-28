using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Spell
{
    public override void Magically(MagicalCharacter from, PlayerMainScript to, uint manaForCast = 0)
    {
        if (from.isUsable(20) && (from.Status != PlayerMainScript.statusEnum.Dead
            && from.Status != PlayerMainScript.statusEnum.Paralyzed) && to.Status == PlayerMainScript.statusEnum.Weakened)
        {
            from.CurrentMana -= 20;
            to.Status = PlayerMainScript.statusEnum.Normal;
        }
    }

    public override void Use()
    {
        //Use ther item
        //Something might happen

        Debug.Log("Using " + name);
    }
}
