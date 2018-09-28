using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3.0f;

    bool isFocus = false;
    bool hasInteracted = false;
    Transform player;
    public Transform InteractionTransform;

    public virtual void Interact()
    {
        //Debug.Log("INTERACT");  
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, InteractionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if (InteractionTransform == null)
            InteractionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, radius);
    }
}
