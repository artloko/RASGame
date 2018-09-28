using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerAnim : CharacterAnimation {

    Combat combat;
    GameProcess gameProcess;
    bool isDead = false;

    protected override void Start()
    {
        base.Start();
        combat = GetComponentInParent<Combat>();
        gameProcess = GetComponentInParent<GameProcess>();
        combat.OnAttack += OnAttack;
    }

    protected override void Update()
    {
        base.Update();
        animator.SetBool("inCombat", combat.inCombat);
        if (gameProcess.Player.Status == PlayerMainScript.statusEnum.Dead && !isDead)
        {
            animator.SetTrigger("Die");
            isDead = true;
        }

    }
}
