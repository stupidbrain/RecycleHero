using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class PlayerLife : MonoBehaviour {

	public int maxLife=10;
	public GameObject gameover;
	public GameObject buildManager;
	//public Spawner spawn;
	public static bool dead;
    public static bool GameIsOver;
    public GameObject completeLevelUI;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public static int life;
    int moneycount;
    int killCount;
    public Flowchart flowchart;

    Text lifeText;
    

    void Start () {
		lifeText = GetComponent<Text> ();
        life = maxLife;        
		dead = false;
		UpdateLife (0);
              
    }

    public void UpdateLife (int hurt) {
		life -= hurt;
		if (life <= 0 && !dead) {
			buildManager.SetActive(false);
			gameover.SetActive(true);
			//spawn.StopSpawn();
			dead = true;
		}
		lifeText.text = life.ToString ("00");
        Debug.Log("life remain: " + life);
	}

   
    public void WinLevel()
    {
        GameIsOver = true;
        PlayerPrefs.SetInt("LevelReached", levelToUnlock);
        PlayerPrefs.SetInt("playerLife", life);
        moneycount = MoneyCount.money;
        PlayerPrefs.SetInt("moneycount", moneycount);
        killCount = KillCount.Killed;
        PlayerPrefs.SetInt("killCount", killCount);

        Debug.Log("Level01 remain life = " + life);
        if (dead != true)
        {
            completeLevelUI.SetActive(true);
            flowchart.ExecuteBlock("levelCompleted");
            flowchart.SetIntegerVariable("life", life);
        }
        
    }

}


