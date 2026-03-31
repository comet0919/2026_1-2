using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    public int curentLives;

    public float invincibeTime = 1.0f;
    public bool isinvincible = false;
    void Start()
    {
        curentLives = maxLives;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("missile"))
        {
            curentLives--;
            Destroy(other.gameObject);

            if(curentLives <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);
    }

    void RestarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
