using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    [SerializeField] private Text _gemCount, _HUDGemCount;
    [SerializeField] private List<GameObject> HealthBar;
    
    public static UIManager Instance
    {   
        get
        {

            if (_instance == null)
            {
                Debug.LogError("Missing UIManager");
            }
                return _instance;                    
         }
    
    }

    public void GemCount(int gemAmount)
    {
        _gemCount.text = gemAmount.ToString()+ " Gems";
        _HUDGemCount.text = gemAmount.ToString();
    }

    public void HealthUpdate(int Health)
    {
        
            for (int h = Health; h < HealthBar.Count; h++)
            {
                HealthBar[h].SetActive(false);
            }
        
    }

    private void Awake()
    {
        _instance = this;
    }
}
