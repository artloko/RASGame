using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyBasicStats))]
public class EnemyCombat : GeneralCombat
{
    
    public event System.Action OnAttack;

    public EnemyBasicStats enemyBasicStats;

	void Start () {
        enemyBasicStats = GetComponent<EnemyBasicStats>();
	}

    public void Attack(GameProcess targetPlayer)
    {
        if (attackCooldown <= 0 && targetPlayer.Player.Status != PlayerMainScript.statusEnum.Dead)
        {
            StartCoroutine(DoDamage(targetPlayer, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 100f / enemyBasicStats.attackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator DoDamage(GameProcess targetPlayer, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (targetPlayer.Player.isInvulnerability)
            targetPlayer.Player.takeDamage(0);
        else
            targetPlayer.Player.takeDamage(Convert.ToUInt32(UnityEngine.Random.Range(enemyBasicStats.CurrentDamage - 0.2f * enemyBasicStats.CurrentDamage,
                enemyBasicStats.CurrentDamage + 0.2f * enemyBasicStats.CurrentDamage)));
        if (targetPlayer.Player.CurrentHealth == 0)
        {
            inCombat = false;
        }
    }
}
