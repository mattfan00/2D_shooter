using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public static float shootingAnimationSpeed = 1.0f;
    public int playerID;
    float targetTime = shootingAnimationSpeed;
    bool shootTimerActivated = false;

    // Update is called once per frame
    void Update()
    {
        if (shootTimerActivated) {
            targetTime -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire" + playerID)) {
            Shoot();
        }

        if (targetTime <= 0f) {
            StopShooting();
        }
    }

    void Shoot() {
        if (shootTimerActivated) {
            targetTime = shootingAnimationSpeed;
        }
        if (animator.GetFloat("Speed") > 0.01f) {
            Debug.Log("Shoot timer activated");
            shootTimerActivated = true;
        }
        animator.SetBool("IsShooting", true);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void StopShooting() {
        shootTimerActivated = false;
        targetTime = shootingAnimationSpeed;
        Debug.Log("stopp shooting");
        animator.SetBool("IsShooting", false);
    }
}
