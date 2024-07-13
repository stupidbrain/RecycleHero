using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelector : MonoBehaviour {

	//public SceneFader fader;

	public Button[] levelButtons;

	void Start ()
	{
		int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i + 1 > levelReached)
				levelButtons[i].interactable = false;
		}
	}

	/*public void Select (string levelName)
	{
        SceneManager.LoadScene(scene);
    }*/

}
