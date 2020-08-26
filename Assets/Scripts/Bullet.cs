using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.right);
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerHealth playerHealth = hitInfo.GetComponent<PlayerHealth>();

        if (playerHealth) {
            playerHealth.TakeDamage(damage);
        }
        
        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
