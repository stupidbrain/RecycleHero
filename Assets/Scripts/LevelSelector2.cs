using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelector2 : MonoBehaviour
{

    public int startlevel;
    int levelDisplay;
    public Button[] levelButtons;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        levelDisplay = levelReached - startlevel + 1;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelDisplay)
                levelButtons[i].interactable = false;
        }
    }

    /*public void Select (string levelName)
	{
        SceneManager.LoadScene(scene);
    }*/

}
