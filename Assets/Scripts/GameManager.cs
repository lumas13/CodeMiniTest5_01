using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject AddEnergy;
    public GameObject MinusEnergy;

    public int numberOfSpawn;
    public float levelTime;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < numberOfSpawn; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15f, 15f), 0.5f, Random.Range(-15f, 15f));

            if (Random.Range(0,2) < 1)
            {
                Instantiate(AddEnergy, randomPos, Quaternion.identity);
            }
            else
            {
                Instantiate(MinusEnergy, randomPos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
            print("Level Time: " + FormatTime(levelTime));
        }
        else
        {
            levelTime = 0;
            print("Times Up!");
        }    
    }

    public string FormatTime (float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time / 60 * minutes;
        int miliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, miliseconds);
    }

    public void AddTime()
    {
        levelTime += 5;

        for (int i = 0; i < 4; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15f, 15f), 0.5f, Random.Range(-15f, 15f));

            if (Random.Range(0, 2) < 1)
            {
                Instantiate(AddEnergy, randomPos, Quaternion.identity);
            }
            else
            {
                Instantiate(MinusEnergy, randomPos, Quaternion.identity);
            }
        }
    }

    public void LoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    public void WinScene()
    {
        SceneManager.LoadScene("WinScene");
    }    
}



