using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyNPC))]
public class EnemyNPCController : MonoBehaviour {

    public float lookRadius = 5.0f;

    Transform target;
    Vector3 startPosition;
    NavMeshAgent agent;
    EnemyNPCCombat enemyNPCCombat;
    EnemyNPC enemyNPC;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        target = GameProcess.instance.PlayerObj.transform;
        agent = GetComponent<NavMeshAgent>();
        enemyNPCCombat = GetComponent<EnemyNPCCombat>();
        enemyNPC = GetComponent<EnemyNPC>();
    }


    // Update is called once per frame
    void Update()
    {
        if (enemyNPC.enemy.Status != PlayerMainScript.statusEnum.Dead && enemyNPC.enemy.Status != PlayerMainScript.statusEnum.Paralyzed)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    GameProcess targetPlayer = target.GetComponent<GameProcess>();
                    if (targetPlayer != null)
                    {
                        enemyNPCCombat.Attack(targetPlayer.Player);
                    }
                    FaceTarget();
                }
            }
            if (distance > lookRadius)
            {
                agent.SetDestination(startPosition);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5.0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
