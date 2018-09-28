using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LightningStaff", menuName = "Inventory/LightningStaff")]
public class LightningStaff : Artifacts
{
    public uint charges = 10;
    bool isFired = false;

    public override void Use()
    {
        if (GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Paralyzed && GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Dead)
        {
            base.Use();
            if (PlayerController.instance.focus is Enemy || PlayerController.instance.focus is EnemyNPC)
            {
                if (PlayerController.instance.focus is Enemy && Vector3.Distance(GameProcess.instance.PlayerObj.transform.position, (PlayerController.instance.focus as Enemy).InteractionTransform.position) < Distance
                    && (PlayerController.instance.focus as Enemy).enemy.CurrentHealth > 0)
                {
                    isFired = true;
                    (PlayerController.instance.focus as Enemy).enemy.takeDamage(Power);
                }
                else if (PlayerController.instance.focus is EnemyNPC && Vector3.Distance(GameProcess.instance.PlayerObj.transform.position, (PlayerController.instance.focus as EnemyNPC).InteractionTransform.position) < Distance
                    && (PlayerController.instance.focus as EnemyNPC).enemy.Status != PlayerMainScript.statusEnum.Dead)
                {
                    isFired = true;
                    (PlayerController.instance.focus as EnemyNPC).enemy.takeDamage(Power);
                }
                if (isFired)
                    charges--;
                isFired = false;
                if (charges < 1)
                    isRenewable = false;
                if (!isRenewable)
                    RemoveFromInventory();
            }
        }
    }
}
