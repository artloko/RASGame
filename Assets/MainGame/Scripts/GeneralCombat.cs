using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCombat : MonoBehaviour {

    protected float attackCooldown = 0f;
    protected const float combatCooldown = 5f;
    protected float lastAttackTime;

    public float attackDelay = .6f;
    public bool inCombat { get; protected set; }


    protected virtual void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (Time.time - lastAttackTime > combatCooldown)
        {
            inCombat = false;
        }
    }
}
