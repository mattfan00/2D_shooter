using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  public PlayerHealth playerHealth;
  void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.name == "Enemy") {
      playerHealth.TakeDamage(1);
    }
  }
}
