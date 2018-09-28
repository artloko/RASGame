using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStats : EnemyBasicStats {

    
    public override void Die()
    {
        base.Die();

        //Die animation

        gameObject.SetActive(false);
    }

}
