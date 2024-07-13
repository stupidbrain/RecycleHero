using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour {

    static Text KillText;
    public static int Killed;
    
    void Start () {
        KillText = GetComponent<Text>();
        Killed = 0;
        //UpdateKilled(0);
    }

    public static void UpdateKilled(int amount)
    {
        Killed += 100;
        KillText.text = "已回收: " + Killed.ToString();
    }
    
}
