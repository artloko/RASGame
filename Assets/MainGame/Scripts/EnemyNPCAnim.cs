using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNPCAnim : CharacterAnimation
{

    EnemyNPCCombat combat;
    EnemyNPC enemyNPC;
    bool isDead = false;

    protected override void Start()
    {
        base.Start();
        combat = GetComponentInParent<EnemyNPCCombat>();
        enemyNPC = GetComponentInParent<EnemyNPC>();
        combat.OnAttack += OnAttack;
    }

    protected override void Update()
    {
        base.Update();
        animator.SetBool("inCombat", combat.inCombat);
        if (enemyNPC.enemy.Status == PlayerMainScript.statusEnum.Dead && !isDead)
        {
            Die();
            isDead = true;
            return;
        }
        if (isDead && enemyNPC.enemy.CurrentHealth > 0)
        {
            animator.SetTrigger("Alived");
            isDead = false;
        }
    }

    protected void Alived()
    {
    }

    protected virtual void Die()
    {
        Debug.Log("Died.");
    }
}
