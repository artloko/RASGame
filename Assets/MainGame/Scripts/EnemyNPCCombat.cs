using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyNPC))]
public class EnemyNPCCombat : GeneralCombat
{

    public event System.Action OnAttack;

    EnemyNPC enemyNPC;

    void Start()
    {
        enemyNPC = GetComponent<EnemyNPC>();
    }

    public void Attack(PlayerMainScript targetPlayer)
    {
        if (attackCooldown <= 0 && targetPlayer.Status != PlayerMainScript.statusEnum.Dead)
        {
            StartCoroutine(DoDamage(targetPlayer, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 100f / enemyNPC.enemy.CurrentAttackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator DoDamage(PlayerMainScript targetPlayer, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (targetPlayer.isInvulnerability)
            targetPlayer.takeDamage(0);
        else
            targetPlayer.takeDamage(Convert.ToUInt32(UnityEngine.Random.Range(enemyNPC.enemy.CurrentDamage - 0.2f * enemyNPC.enemy.CurrentDamage,
                enemyNPC.enemy.CurrentDamage + 0.2f * enemyNPC.enemy.CurrentDamage)));

        if (targetPlayer.CurrentHealth == 0)
        {
            inCombat = false;
        }
    }
}
