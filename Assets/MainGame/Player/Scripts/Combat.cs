using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameProcess))]
public class Combat : GeneralCombat
{

    public event System.Action OnAttack;

    GameProcess myPlayer;

	void Start () {
        myPlayer = GetComponent<GameProcess>();
	}
	
    public void Attack(EnemyBasicStats targetEnemy)
    {
        if (attackCooldown <= 0f && targetEnemy.CurrentHealth > 0)
        {
            StartCoroutine(DoDamage(targetEnemy, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 100f / myPlayer.Player.CurrentAttackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    public void Attack(PlayerMainScript targetEnemy)
    {
        if (attackCooldown <= 0f && targetEnemy.Status != PlayerMainScript.statusEnum.Dead)
        {
            StartCoroutine(DoDamage(targetEnemy, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 100f / myPlayer.Player.CurrentAttackSpeed;
            inCombat = true;
            lastAttackTime = Time.time;
        }
    }

    IEnumerator DoDamage(EnemyBasicStats targetEnemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        targetEnemy.takeDamage(Convert.ToUInt32(UnityEngine.Random.Range(myPlayer.Player.CurrentDamage - myPlayer.Player.CurrentDamage * 0.2f,
               myPlayer.Player.CurrentDamage + myPlayer.Player.CurrentDamage * 0.2f)));
        if (targetEnemy.CurrentHealth == 0)
        {
            inCombat = false;
        }
    }

    IEnumerator DoDamage(PlayerMainScript targetEnemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        targetEnemy.takeDamage(Convert.ToUInt32(UnityEngine.Random.Range(myPlayer.Player.CurrentDamage - myPlayer.Player.CurrentDamage * 0.2f,
               myPlayer.Player.CurrentDamage + myPlayer.Player.CurrentDamage * 0.2f)));
        if (targetEnemy.CurrentHealth == 0)
        {
            inCombat = false;
        }
    }
}
