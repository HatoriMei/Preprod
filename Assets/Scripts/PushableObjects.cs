using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float PushPower = 5f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Pushable")
        {
            Rigidbody box = hit.collider.GetComponent<Rigidbody>();
            if (box != null)
            {
                Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
                box.velocity = pushDirection * PushPower;
            }
        }
    }
}
