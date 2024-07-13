using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class playerLife2 : MonoBehaviour
{

    public GameObject gameover;
    public GameObject buildManager;
    public GameObject WaveSpawner2;
    public Flowchart flowchart;
    //public Spawner spawn;
    public static bool dead;
    public static bool GameIsOver;
    public GameObject completeLevelUI;
    public string nextLevel = "Level03";
    public int levelToUnlock = 3;
    int moneycount;
    int killCount;
    public static int life;
    public int killMoney;
    Text lifeText;
    public Text countstartext;


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
            WaveSpawner2.SetActive(false);
            Killall();
            gameover.SetActive(true);
            //Invoke("Pause", 0);
            dead = true;
            //spawn.StopSpawn();
            
        }
        lifeText.text = life.ToString("00");
    }

    public void WinLevel()
    {
        if (dead != true)
        {
            GameIsOver = true;
            PlayerPrefs.SetInt("LevelReached", levelToUnlock);
            PlayerPrefs.SetInt("playerLife", life);
            moneycount = MoneyCount2.money;
            PlayerPrefs.SetInt("moneycount", moneycount);
            killCount = KillCount2.Killed;
            PlayerPrefs.SetInt("killCount", killCount);
        }
        
        
        

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

    public void Killall()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in gameObjects)
        {
            //killMoney = gameObject.GetComponent<Enemy2>().prize;
            MoneyCount2.UpdateMoney(100);
            KillCount2.UpdateKilled(1);
            GameObject.Destroy(target);
        }
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        return;
    }

}




