using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BottleWithAliveWater", menuName = "Inventory/BottleWithAliveWater")]
public class BottleWithAliveWater : Artifacts
{
    new public string Size = "BottleSize";
    int HpForHeal = 0;                          //Percent

    public override void Use()
    {
        if (GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Paralyzed && GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Dead)
        {
            if (!isRenewable)
                RemoveFromInventory();
            base.Use();
            switch (Size)
            {
                case "Big":
                    HpForHeal = 20;
                    break;
                case "Medium":
                    HpForHeal = 13;
                    break;
                case "Small":
                    HpForHeal = 7;
                    break;
                default:
                    break;
            }
            if (HpForHeal != 0)
                GameProcess.instance.Player.CurrentHealth += Convert.ToUInt32(GameProcess.instance.Player.MaxHealth * HpForHeal / 100.0f);
        }
    }
}
