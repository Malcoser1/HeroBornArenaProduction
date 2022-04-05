using UnityEngine;

public class Quit: MonoBehaviour
{
    public void quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
