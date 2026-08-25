using UnityEngine;

public class enemyStats : MonoBehaviour
{
    public int maxLive;
    public int currentLive;
    public scoreManager Score;

    private void Awake()
    {
        Score = GameObject.FindGameObjectWithTag("ScoreController").GetComponent<scoreManager>();
    }

    private void Start()
    {
        currentLive = maxLive;
    }

    public void TakeDamage(int damage)
    {
        currentLive -= damage;
        if(currentLive <= 0)
        {
            Score.enemiesKilled++;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<playerBullets>())
        {
            TakeDamage(collision.transform.GetComponent<playerBullets>().damage);
            Destroy(collision.gameObject);
        }
    }
}
