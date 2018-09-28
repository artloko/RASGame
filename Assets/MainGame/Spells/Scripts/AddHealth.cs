using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : Spell {
    
    public override void Magically(MagicalCharacter from, PlayerMainScript to, uint manaForCast = 0)
    {
        if (from.isUsable(manaForCast) && from.Status != PlayerMainScript.statusEnum.Dead
            && from.Status != PlayerMainScript.statusEnum.Paralyzed)
        {
            from.CurrentMana -= manaForCast;
            if (to.CurrentHealth + manaForCast / 2 >= to.MaxHealth)
                to.CurrentHealth = to.MaxHealth;
            else
                to.CurrentHealth += manaForCast / 2;
        }
    }

    public override void Use()
    {
        //Use ther item
        //Something might happen

        Debug.Log("Using " + name);
    }
}
