using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageResult_plife3 : MonoBehaviour
{

    public playerLife3 playerlife;
    //public WaveSpawner2 wavespawner;
    public int Relife = 10;
    public int alive = 0;
    public int setwaveindex = 0;
    

    bool videoWatched;

    void Start()
    {

        videoWatched = false;
    }

    public void Restart()
    {
       
        playerlife.SendMessage("SetLife", Relife);
        //wavespawner.SendMessage("SetEnemiesAlive", alive);
        //wavespawner.SendMessage("SetwaveIndex", setwaveindex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SceneManager.LoadScene("title");
    }

    public void WatchVideo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    
}