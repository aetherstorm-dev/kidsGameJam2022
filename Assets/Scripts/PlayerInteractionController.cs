using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractionController : MonoBehaviour
{
    public float radius = 1.0f;

    public void OnInteractButton(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Performed) return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            IInteractionReceiver receiver = collider.GetComponent<IInteractionReceiver>();
            if (receiver != null)
            {
                receiver.Interact();

                if (!receiver.ShouldPassThrough())
                    break;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
