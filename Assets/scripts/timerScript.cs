using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class timerScript : MonoBehaviour
{
    public float elapsedTime;
    public float maxTimeToCompleteLeel = 100f;
    public float bestTime;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bestTimeText;

    private saveManager saves;

    private void Awake()
    {
        saves = GetComponent<saveManager>();
    }
    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= maxTimeToCompleteLeel)
        {
            SceneManager.LoadScene("loseScene");
        }

        timerText.text = "Tiempo restante: " + elapsedTime.ToString("F0") + "/" + maxTimeToCompleteLeel;
        bestTimeText.text = "Mejor tiempo: " + bestTime.ToString("F0");
    }

    public void CompleteLevel()
    {
        if(elapsedTime < bestTime)
        {
            bestTime = elapsedTime;
            saves.SaveData();

        }
    }
}
