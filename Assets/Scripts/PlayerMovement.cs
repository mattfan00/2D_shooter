using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public Transform firePoint;
    public int playerID;
    float horizontalMovement;
    bool jump = false;
    bool crouch = false;


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

        if (Input.GetButtonDown("Crouch" + playerID.ToString())) {
            crouch = true;
            animator.SetBool("IsCrouching", true);
            AdjustFirePoint(crouch);
        } else if (Input.GetButtonUp("Crouch" + playerID.ToString())) {
            crouch = false;
            animator.SetBool("IsCrouching", false);
            AdjustFirePoint(crouch);
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void AdjustFirePoint(bool isCrouching) {
        if (isCrouching) {
            Vector3 crouchingPosition = new Vector3(0.55f, -0.31f, 0f);
            Debug.Log(transform.rotation.y);
            if (transform.rotation.y == -1) {
                crouchingPosition.x *= -1;
            }
            firePoint.position = crouchingPosition + transform.position;
        } else {
            Vector3 standingPosition = new Vector3(0.55f, 0.09f, 0f);
            if (transform.rotation.y == -1) {
                standingPosition.x *= -1;
            }
            firePoint.position = standingPosition + transform.position;
        }
    }

    public void OnLanding() {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool crouching) {
        crouch = crouching;
        animator.SetBool("IsCrouching", crouch);
    }
}
