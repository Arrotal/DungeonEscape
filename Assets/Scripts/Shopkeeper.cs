using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    private Player _player;
    [SerializeField] private Image _selection;
    private int _currentSelected, _selectionCost;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _player = collision.GetComponent<Player>();
            shopUI.SetActive(true);
            UIManager.Instance.GemCount(_player.GemCount());

            _selection.enabled = false;
        }

        
    }
    public void SelectItem(int selection)
    {
        _currentSelected = selection;
        _selection.enabled = true;
        switch (selection)
        {
            case 0:
                _selection.rectTransform.anchoredPosition = new Vector2(_selection.rectTransform.anchoredPosition.x, 84);
                _selectionCost = 200;
                break;
            case 1:
                _selection.rectTransform.anchoredPosition = new Vector2(_selection.rectTransform.anchoredPosition.x, -17);
                _selectionCost = 400;
                break;
            case 2:
                _selection.rectTransform.anchoredPosition = new Vector2(_selection.rectTransform.anchoredPosition.x, -126);
                _selectionCost = 100;
                break;

        }
    }

    public void Buy()
    {
        if (_player.GemCount() >= _selectionCost)
        {
            _player.GemRemove(_selectionCost);
            UIManager.Instance.GemCount(_player.GemCount());
            switch (_currentSelected)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    GameManager.Instance.HasKey = true;
                    break;
            }
        }
        else
        {
            Debug.Log("You do not have enough Gems.");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopUI.SetActive(false);
        }
    }
}
