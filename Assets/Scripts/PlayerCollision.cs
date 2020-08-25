using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.name == "Enemy") {

    }
  }
}
