using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1WinLabel;
    public GameObject player2WinLabel;
    public float restartDelay = 2f;
    bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if (players.Length == 1) {
                gameOver = true;
                if (players[0].gameObject.name == "Player 1") {
                    player1WinLabel.SetActive(true);
                } else {
                    player2WinLabel.SetActive(true);
                }
                Invoke("Restart", restartDelay);
            }
        }
    }

    void Restart() {
        player1WinLabel.SetActive(false);
        player2WinLabel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
