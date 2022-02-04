using UnityEngine;

public class Hole : MonoBehaviour
{
    public Transform respawn;
    
    private void OnTriggerEnter(Collider other)
    {
        var rigidbody = other.attachedRigidbody;
        
        rigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.MovePosition(respawn.position);
        
        Scene.ResetClickCount();
    }
}
