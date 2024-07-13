using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Star : MonoBehaviour {

    public GameObject starImg01;

    private void Start()
    {
        //starImg01 = GameObject.Find("StarImg0");
        
        starImg01.SetActive(true);
    }


}
