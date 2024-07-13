using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class CountDown : MonoBehaviour
{

    public int timeLeft = 60; //Seconds Overall
    public Text countdown; //UI Text Object
    public playerLife3 playerlife;
    public Spawner spawner;
    public Pause pausecontrol;
    bool die;

    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
        
    }

    void Update()
    {
        countdown.text = ("Time Left:" + timeLeft); //Showing the Score on the Canvas
        if (timeLeft == 0)
        {
            playerlife.WinLevel();
            spawner.StopSpawn();
            pausecontrol.PauseGame();
            this.enabled = false;
        }
    }

    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}