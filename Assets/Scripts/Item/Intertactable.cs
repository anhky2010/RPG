using UnityEngine;

public class Intertactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactableTranform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;//check pham vi nhin thay nhau

    void Update()
    {
        if (isFocus && hasInteracted == false)
        {
            float distance = Vector3.Distance(player.position, interactableTranform.position);
            if (distance < radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        // Debug.Log("Va cham");
    }
    public void onFocused(Transform playertransform)
    {
        isFocus = true;
        player = playertransform;
        hasInteracted = false;
    }
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = true;
    }

    void OnDrawGizmosSelected()
    {
        if (interactableTranform == null)
        {
            interactableTranform = this.transform;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactableTranform.position, radius);
    }

}
