using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleWarriorNPC : EnemyNPCAnim
{
    protected override void Die()
    {
        base.Die();
        animator.SetTrigger("Die");
    }
}
