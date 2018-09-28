using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DecoctionOfFrogLegs", menuName = "Inventory/DecoctionOfFrogLegs")]
public class DecoctionOfFrogLegs : Artifacts
{
    public override void Use()
    {
        if (GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Paralyzed && GameProcess.instance.Player.Status != PlayerMainScript.statusEnum.Dead)
        {
            base.Use();

            if (PlayerController.instance.focus is EnemyNPC && (PlayerController.instance.focus as EnemyNPC).enemy.Status == PlayerMainScript.statusEnum.Ill)
            {
                if (Vector3.Distance(GameProcess.instance.PlayerObj.transform.position, (PlayerController.instance.focus as EnemyNPC).InteractionTransform.position) < Distance)
                {
                    (PlayerController.instance.focus as EnemyNPC).enemy.Status = PlayerMainScript.statusEnum.Weakened;
                    RemoveFromInventory();
                }
            }
            else if (PlayerController.instance.focus == null && GameProcess.instance.Player.Status == PlayerMainScript.statusEnum.Ill)
            {
                GameProcess.instance.Player.Status = PlayerMainScript.statusEnum.Weakened;
                RemoveFromInventory();
            }
        }
    }
}
