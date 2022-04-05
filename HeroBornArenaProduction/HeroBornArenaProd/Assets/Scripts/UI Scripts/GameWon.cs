using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{


	public float restartDelay = 1f;

	public GameObject completeLevelUI;

	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true);
	}

}