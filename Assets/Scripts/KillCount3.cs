using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class KillCount3 : MonoBehaviour
{
    public Flowchart flowchart;
    static Text KillText;
    public static int Killed;

    void Start()
    {
        KillText = GetComponent<Text>();
        Killed = PlayerPrefs.GetInt("killCount");
        UpdateKilled(0);
        flowchart.SetIntegerVariable("totalkilled", Killed);
    }

    public static void UpdateKilled(int amount)
    {
        Killed += 1;
        KillText.text = "已回收: " + Killed.ToString();
    }

    public void UpdateTotal()
    {
        Killed -= 1000;
    }

}
