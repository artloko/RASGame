using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicStats : MonoBehaviour {

    Animator animator;
    EnemyController enemyController;
    new public string name = "New enemy";
    public float attackSpeed = 120f;
    uint currentHealth;
    public uint MaxHealth = 100;
    public uint CurrentDamage = 15;
    public bool IsDead
    {
        get
        {
            return CurrentHealth == 0;
        }
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

    void Awake()
    {
        currentHealth = MaxHealth;
    }

    public uint CurrentHealth
    {
        get { return currentHealth; }
        private set
        {
            if (value > MaxHealth)
                currentHealth = MaxHealth;
            else
                currentHealth = value;
        }
    }

    public virtual void Die()
    {
        Debug.Log("Died.");
    }

    public void takeDamage(uint damage)
    {
        Debug.Log("Enemy takes" + damage + " damage.");
        if ((int)CurrentHealth - (int)damage <= 0)
            CurrentHealth = 0;
        else
            CurrentHealth -= damage;
        if (IsDead)
        {
            animator.SetTrigger("Die");
            GameProcess gameProcess = enemyController.target.GetComponent<GameProcess>();
            if (gameProcess != null)
            {
                gameProcess.Player.Gold += Convert.ToUInt32(currentHealth / 10 + 1 / (float)gameProcess.Player.CurrentLevel * gameProcess.Player.Intelligence);
                gameProcess.Player.GetExperience(Convert.ToUInt32(currentHealth / 10 + 1 / (float)gameProcess.Player.CurrentLevel * gameProcess.Player.Intelligence));
            }
        }     
    }
}
