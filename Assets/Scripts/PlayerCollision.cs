using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public PlayerHealth playerHealth;
  void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.name == "Bullet") {
      Debug.Log("hit by bullet");
      playerHealth.TakeDamage(1);
    }
  }
}
