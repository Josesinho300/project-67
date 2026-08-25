using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class scoreManager : MonoBehaviour
{
    public int enemiesKilled;
    public int allEnemies = 3;
    public TextMeshProUGUI enemiesText;
    public int destroyDoor1;
    public int destroyDoor2;
    public int destroyShield;

    private timerScript Timer;

    public GameObject door1;
    public GameObject door2;
    public GameObject shield;

    private void Awake()
    {
        Timer = GetComponentInParent<timerScript>();
    }

    private void Update()
    {
        if (enemiesKilled >= allEnemies)
        {
            Timer.CompleteLevel();
            SceneManager.LoadScene("winScene");
        }

        enemiesText.text = "Enemigos: " + enemiesKilled + "/" + allEnemies;

        if (enemiesKilled >= destroyDoor1)
        {
            Destroy(door1.gameObject);
        }

        if (enemiesKilled >= destroyDoor2)
        {
            Destroy(door2.gameObject);
        }

        if (enemiesKilled >= destroyShield)
        {
            Destroy(shield.gameObject);
        }
    }
}
