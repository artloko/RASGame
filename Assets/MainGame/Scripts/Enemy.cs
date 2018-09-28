using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyBasicStats))]
public class Enemy : Interactable {

    GameProcess gameProcces;
    public EnemyBasicStats enemy;

    void Start()
    {
        gameProcces = GameProcess.instance;
        enemy = GetComponent<EnemyBasicStats>();
    }

    public override void Interact()
    {
        base.Interact();
        Combat combat = gameProcces.PlayerObj.GetComponent<Combat>();
        if (combat != null)
        {
            combat.Attack(enemy);
        }
    }
}
