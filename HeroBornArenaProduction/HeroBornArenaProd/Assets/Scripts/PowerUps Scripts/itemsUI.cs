using UnityEngine;
using UnityEngine.UI;

public class ItemsUI : MonoBehaviour
{
    public Text Items;
    private GameBehavior _gameManager;

    void Update()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        Items.text = _gameManager.Items.ToString("" + _gameManager.Items);
    }
}