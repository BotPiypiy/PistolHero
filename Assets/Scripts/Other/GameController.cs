using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    int timeBeforeStart = 3;
    [SerializeField]
    Text timeBeforeStartText;
    [SerializeField]
    GameObject pauseButton;
    [SerializeField]
    GameObject flyingEnemy;
    [SerializeField]
    GameObject groundEnemy;
    [SerializeField]
    GameObject endPortal;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            int enem = Random.Range(1, 3);
            if (enem == 1)
                Instantiate(flyingEnemy, new Vector3(Random.Range(-10f, 10f), 6f, Random.Range(-5f, 20f)), Quaternion.identity);
            else
                Instantiate(groundEnemy, new Vector3(Random.Range(-10f, 10f), 2f, Random.Range(-5f, 20f)), Quaternion.identity);
        }

        Time.timeScale = 0;
        StartCoroutine(WaitForStart(timeBeforeStart));
    }

    IEnumerator WaitForStart(int sec)
    {
        for (int i = 0; i < sec; i++)
        {
            timeBeforeStartText.text = (sec - i).ToString();
            yield return new WaitForSecondsRealtime(1f);
        }

        timeBeforeStartText.gameObject.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            endPortal.SetActive(true);
    }
}
