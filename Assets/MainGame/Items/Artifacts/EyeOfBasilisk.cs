using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EyeOfBasilisk", menuName = "Inventory/EyeOfBasilisk")]
public class EyeOfBasilisk : Artifacts
{
    public override void Use()
    {
        if (GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Paralyzed && GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Dead)
        {
            if (!isRenewable)
                RemoveFromInventory();
            base.Use();
            if (PlayerController.instance.focus is EnemyNPC && Vector3.Distance(GameProcess.instance.PlayerObj.transform.position, (PlayerController.instance.focus as EnemyNPC).InteractionTransform.position) < Distance
                    && (PlayerController.instance.focus as EnemyNPC).enemy.Status != PlayerMainScript.statusEnum.Dead)
            {
                (PlayerController.instance.focus as EnemyNPC).enemy.Status = PlayerMainScript.statusEnum.Paralyzed;
            }
        }
    }
}
