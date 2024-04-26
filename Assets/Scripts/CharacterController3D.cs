using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 20f;

    private CharacterController controller;
    private Vector3 moveDirection;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // V�rifie si le personnage est au sol
        isGrounded = controller.isGrounded;

        // Si le personnage est au sol, permet les mouvements horizontaux
        if (isGrounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);
            moveDirection = moveHorizontal * Camera.main.transform.right+moveVertical*Camera.main.transform.forward;
            moveDirection *= moveSpeed;

        }

        // Applique la gravit�
        moveDirection.y -= gravity * Time.deltaTime;

        // D�place le personnage
        controller.Move(moveDirection * Time.deltaTime);
    }
}

