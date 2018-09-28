using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] defaultAttackAnimationSet;
    protected AnimationClip[] currentAttackAnimationSet;

    const float locomotionAnimationSmoothTime = .1f;
    private float speedPercent;
    UnityEngine.AI.NavMeshAgent agent;
    protected Animator animator;
    protected AnimatorOverrideController overrideController;

    protected virtual void Start()
    {
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimationSet = defaultAttackAnimationSet;
    }

    protected virtual void Update()
    {
        speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
    }
    

    protected virtual void OnAttack()
    {
        animator.SetTrigger("Attack");
        int attackIndex = Random.Range(0, currentAttackAnimationSet.Length);
        overrideController[replaceableAttackAnim.name] = currentAttackAnimationSet[attackIndex]; 
    }

}
