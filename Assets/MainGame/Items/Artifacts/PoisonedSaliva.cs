using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PoisonedSaliva", menuName = "Inventory/PoisonedSaliva")]
public class PoisonedSaliva : Artifacts {

    public uint charges = 10;
    bool isFired = false;

    public override void Use()
    {
        if (GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Paralyzed && GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Dead)
        {
            base.Use();
            if (PlayerController.instance.focus is Enemy || PlayerController.instance.focus is EnemyNPC)
            {
                if (PlayerController.instance.focus is EnemyNPC && Vector3.Distance(GameProcess.instance.PlayerObj.transform.position, (PlayerController.instance.focus as EnemyNPC).InteractionTransform.position) < Distance)
                {
                    isFired = true;
                    (PlayerController.instance.focus as EnemyNPC).enemy.Status = PlayerMainScript.statusEnum.Ill;
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
