using UnityEngine;
using TMPro;

public class GoldPerSec : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Gold _goldManager;
    [SerializeField] private TMP_Text _goldPerSecondTMP;
    [SerializeField] private TMP_Text _currentGoldTMP;
    [SerializeField] private int _price;
    [SerializeField] private int _value;

    private void LateUpdate()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= _price)
            _panel.SetActive(false);
        else
            _panel.SetActive(true);
    }

    public void BuyGoldPerSec()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= _price)
        {
            PlayerPrefs.SetInt("CurrentGold", PlayerPrefs.GetInt("CurrentGold") - _price);
            _goldManager.SetGoldPerSec(_value);
            _goldPerSecondTMP.text = PlayerPrefs.GetInt("GoldPerSec").ToString();
            _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();
        }
    }
}
