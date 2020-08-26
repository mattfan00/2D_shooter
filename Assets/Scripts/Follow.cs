using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform followPlayer;
    public Vector3 offset = new Vector3(0f, 1f, 0f);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, followPlayer.position + offset, 1f);
    }
}
