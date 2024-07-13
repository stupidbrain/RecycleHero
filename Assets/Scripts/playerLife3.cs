using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class playerLife3 : MonoBehaviour
{

    public GameObject gameover;
    public GameObject buildManager;
    public Flowchart flowchart;
    //public GameObject WaveSpawner2;
    public Spawner spawn;
    public static bool dead;
    public static bool GameIsOver;
    public GameObject completeLevelUI;
    public string nextLevel = "Level03";
    public int levelToUnlock = 3;
    int moneycount;
    int killCount;

    int life;
    Text lifeText;


    void Start()
    {
        lifeText = GetComponent<Text>();
        life = 10;  //PlayerPrefs.GetInt("playerLife");
        if (dead == true)
        {
            life = 10;
            dead = false;
            GameIsOver = false;
        }
        else
        {
            dead = false;
            UpdateLife(0);
            GameIsOver = false;
        }
    }

    public void UpdateLife(int hurt)
    {
        life -= hurt;
        if (life <= 0 && !dead)
        {
            buildManager.SetActive(false);
            //WaveSpawner2.SetActive(false);
            gameover.SetActive(true);
            dead = true;
            spawn.StopSpawn();
            Invoke("Pause", 0);

        }
        lifeText.text = ("Life: " + life.ToString("00"));
    }

    public void WinLevel()
    {
        GameIsOver = true;
        PlayerPrefs.SetInt("LevelReached", levelToUnlock);
        PlayerPrefs.SetInt("playerLife", life);
        moneycount = MoneyCount2.money;
        PlayerPrefs.SetInt("moneycount", moneycount);
        killCount = KillCount2.Killed;
        PlayerPrefs.SetInt("killCount", killCount);

        if (life >= 0 && !dead)
        {
            completeLevelUI.SetActive(true);
            flowchart.ExecuteBlock("levelCompleted");
            flowchart.SetIntegerVariable("life", life);
        }
    }

    void SetLife(int Relife)
        {
            life = Relife;
        }

    public void Pause()
    {
        Time.timeScale = 0;
        return;
    }

}




