using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canMove = true;
    public float movementSpeed = 1f;
    public float jumpHeight;
    public CharacterController player;
    public float gravity;
    public Animator animator;

    public Transform pivot;
    public float rotateSpeed = 0f;

    public GameObject playerModel;

    private Vector3 newMove;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
       // player.transform.position = new Vector3(38, 43, 29);
    }

    // Update is called once per frame
    void Update()

    {   if (canMove)
        {
            newMove = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            newMove = newMove.normalized * movementSpeed;
            if (player.isGrounded)// Jeżeli obiekt jest na ziemii, wtedy możemy podskoczyć
            {
                newMove.y = 0;
                /* if (Input.GetButtonDown("Jump"))
                 {
                     newMove.y = jumpHeight;
                 }*/
            }
            newMove.y = newMove.y + (Physics.gravity.y * gravity * Time.deltaTime);
            player.Move(newMove * Time.deltaTime);

            //Ruch  w różne strony wprost proporconalnie do rotacji kamery 
            if(Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(newMove.x, 0f, newMove.z));
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }

            animator.SetFloat("speed", (Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal"))));
        }
    }
}

