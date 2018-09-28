using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BottleWithDeadWater", menuName = "Inventory/BottleWithDeadWater")]
public class BottleWithDeadWater : Artifacts
{
    new public string Size = "BottleSize";
    int MpForHeal = 0;                          //Percent

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
                    MpForHeal = 20;
                    break;
                case "Medium":
                    MpForHeal = 13;
                    break;
                case "Small":
                    MpForHeal = 7;
                    break;
                default:
                    break;
            }
            if (MpForHeal != 0)
                GameProcess.instance.Player.CurrentMana += Convert.ToUInt32(GameProcess.instance.Player.MaxMana * MpForHeal / 100.0f);
        }
    }
}
