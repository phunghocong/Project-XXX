using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private CharacterController controller;
    public float speed;
    Vector3 velocity;

    public Transform groundcheck;

    private float groundDis = 0.4f;

    public LayerMask whatisGround;

    public bool isGrounded;

    public float jumpforce = 6f;

    public float gravity = -19.8f;

    [SerializeField]
    private float slopeForce;

    [SerializeField] private float slopeforceRaylenght;



    void Start()
    {
        

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundcheck.position, groundDis, whatisGround);
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * speed * Time.deltaTime);

        velocity += Physics.gravity *2 * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpforce * -2f * gravity);
        }

        if((z !=0 || x!=0) && OnSlope())
        {
            controller.Move(Vector3.down * controller.height / 2 * slopeForce);
        }


    }

    private bool OnSlope()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return false;
        }

        RaycastHit hit;

        if(Physics.Raycast(transform.position,Vector3.down,out hit,controller.height /2 * slopeforceRaylenght))
        {
            if(hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }
}
