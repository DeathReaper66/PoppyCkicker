using UnityEngine;
using TMPro;
using YG;

public class GoldPerClickButton : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Gold _goldManager;
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

    public void BuyGoldPerClick()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= _price)
        {
            PlayerPrefs.SetInt("CurrentGold", PlayerPrefs.GetInt("CurrentGold") - _price);
            _goldManager.SetGoldPerClick(_value);
            _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();
            YandexGame.NewLeaderboardScores("Leaders", PlayerPrefs.GetInt("GoldPerClick"));
        }
    }
}
