using UnityEngine;
using UnityEngine.UI;

public class healthUI : MonoBehaviour
{
    public Text Lives;
    private GameBehavior _gameManager;

    void Update()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        Lives.text = _gameManager.HP.ToString("" + _gameManager.HP);
    }
}