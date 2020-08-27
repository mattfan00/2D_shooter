using UnityEngine;

public class FollowMiddle : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Camera camera;
    public float camSpeed = 1f;
    public float deadZone = 8f;

    // Update is called once per frame
    void Update()
    {
        Vector3 averagePosition;
        if (player1 == null) { // player1 is dead
            camera.orthographicSize = 4f;
            averagePosition = player2.position;
            averagePosition.z = transform.position.z;
        } else if (player2 == null) { // player2 is dead
            camera.orthographicSize = 4f;
            averagePosition = player1.position;
            averagePosition.z = transform.position.z;
        } else {
            // Vector3 newPosition = transform.position;
            // newPosition.x = player1.position.x + (player2.position.x - player1.position.x) / 2;
            if (Mathf.Abs(player1.position.x - player2.position.x) > deadZone) {
                float sizeX = Mathf.Abs(player1.position.x - player2.position.x) + 7f;
                float sizeY = Mathf.Abs(player1.position.y - player2.position.y) + 7f;
                float camSize = (sizeX > sizeY ? sizeX : sizeY);

                camera.orthographicSize = camSize * 0.25f;
            }

            averagePosition = player1.position + (player2.position - player1.position) / 2;
            averagePosition.z = transform.position.z;
        }

        transform.position = Vector3.Lerp(transform.position, averagePosition, camSpeed * Time.deltaTime);
    }
}
