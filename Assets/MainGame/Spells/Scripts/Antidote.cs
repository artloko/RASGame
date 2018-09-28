using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antidote : Spell
{
    public override void Magically(MagicalCharacter from, PlayerMainScript to = null, uint manaForCast = 0)
    {
        if (from.isUsable(30) && (from.Status != PlayerMainScript.statusEnum.Dead
            && from.Status != PlayerMainScript.statusEnum.Paralyzed) && to.Status == PlayerMainScript.statusEnum.Ill)
        {
            from.CurrentMana -= 30;
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
