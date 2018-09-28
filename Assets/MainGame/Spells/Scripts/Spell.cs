using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagic
{
   void Magically(MagicalCharacter from, PlayerMainScript to = null, uint manaForCast = 0);
}

public abstract class Spell : MonoBehaviour, IMagic {
    
    new public string name = "New Spell";
    public Sprite icon = null;


    private int minMana;
    public bool TalkingComponent { get; set; }
    public bool MotorComponent { get; set; }
    public abstract void Magically(MagicalCharacter from, PlayerMainScript to, uint spellPower = 0);
    public int MinMana
    {
        get
        {
            return minMana;
        }
        set
        {
            if (value < 0)
                return;
            else
                minMana = value;
        }
    }

    public virtual void Use()
    {
        //Use ther item
        //Something might happen

        Debug.Log("Using " + name);
    }
}
