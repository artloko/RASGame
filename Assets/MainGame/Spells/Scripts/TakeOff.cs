using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOff : Spell
{
    public override void Magically(MagicalCharacter from, PlayerMainScript to = null, uint manaForCast = 0)
    {
        if (from.isUsable(85) && (from.Status != PlayerMainScript.statusEnum.Dead
            && from.Status != PlayerMainScript.statusEnum.Paralyzed) && to.Status == PlayerMainScript.statusEnum.Paralyzed)
        {
            from.CurrentMana -= 85;
            to.Status = PlayerMainScript.statusEnum.Weakened;
            to.CurrentHealth = 1;
        }
    }

    public virtual void Use()
    {
        //Use ther item
        //Something might happen

        Debug.Log("Using " + name);
    }
}
