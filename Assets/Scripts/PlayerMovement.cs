using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public int playerID;
    float horizontalMovement;
    bool jump = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal" + playerID.ToString()) * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        
        if (animator.GetFloat("Speed") == 0f) {
            animator.SetBool("IsShooting", false);
        }

        if (Input.GetButtonDown("Jump" + playerID.ToString())) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }
}
