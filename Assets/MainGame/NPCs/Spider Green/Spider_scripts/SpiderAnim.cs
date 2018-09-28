using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderAnim : CharacterAnimation {

    EnemyCombat enemyCombat;

    protected override void Start()
    {
        base.Start();
        enemyCombat = GetComponentInParent<EnemyCombat>();
        enemyCombat.OnAttack += OnAttack;
    }

    protected override void Update()
    {
        base.Update();
        animator.SetBool("inCombat", enemyCombat.inCombat);
    }   
}
