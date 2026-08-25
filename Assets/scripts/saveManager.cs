using UnityEngine;

public class saveManager : MonoBehaviour
{

    private timerScript timer;

    private void Awake()
    {
        timer = GetComponent<timerScript>();
        LoadData();
    }

    public void LoadData()
    {
        if(timer != null)
        {
            timer.bestTime = PlayerPrefs.GetFloat("saveTime", timer.bestTime);
        }
    }

    public void DeleteBestTime()
    {
        PlayerPrefs.DeleteKey("saveTime");
    }

    public void SaveData()
    {
        if( timer != null )
        {
            PlayerPrefs.SetFloat("saveTime", timer.bestTime);
        }
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
