using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StageResult3 : MonoBehaviour
{

    public playerLife3 playerlife;
    //public WaveSpawner2 wavespawner;
    public int Relife = 10;
    public int alive = 0;
    public int setwaveindex = 0;
    

    void Start()
    {
        
    }

    

    public void Quit()
    {
        SceneManager.LoadScene("title");
    }

    
}