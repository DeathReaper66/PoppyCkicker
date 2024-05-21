using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Image _mob;
    [SerializeField] private Sprite[] _mobs;
    [SerializeField] private TMP_Text _currentGoldTMP;
    [SerializeField] private TMP_Text _priceTMP;
    [SerializeField] private GameObject _mainButton;

    private void Awake()
    {
        _mob.sprite = _mobs[PlayerPrefs.GetInt("MobIndex")];

        if (PlayerPrefs.GetInt("LevelPrice") == 0)
            PlayerPrefs.SetInt("LevelPrice", 10);
        if (PlayerPrefs.GetInt("LevelPriceScale") == 0)
            PlayerPrefs.SetInt("LevelPriceScale", 10);
        if (PlayerPrefs.GetInt("MobIndex") >= 9)
            Destroy(_mainButton);

        _priceTMP.text = PlayerPrefs.GetInt("LevelPrice").ToString();
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= PlayerPrefs.GetInt("LevelPrice"))
            _panel.SetActive(false);
        else
            _panel.SetActive(true);
    }

    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= PlayerPrefs.GetInt("LevelPrice"))
        {

            PlayerPrefs.SetInt("CurrentGold", PlayerPrefs.GetInt("CurrentGold") - PlayerPrefs.GetInt("LevelPrice"));
            _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();

            PlayerPrefs.SetInt("MobIndex", PlayerPrefs.GetInt("MobIndex") + 1);
            Debug.Log(PlayerPrefs.GetInt("MobIndex"));
            _mob.sprite = _mobs[PlayerPrefs.GetInt("MobIndex")];

            PlayerPrefs.SetInt("LevelPrice", PlayerPrefs.GetInt("LevelPrice") * PlayerPrefs.GetInt("LevelPriceScale"));
            _priceTMP.text = PlayerPrefs.GetInt("LevelPrice").ToString();

            if (PlayerPrefs.GetInt("MobIndex") == 3)
                PlayerPrefs.SetInt("LevelPriceScale", 5);
            if (PlayerPrefs.GetInt("MobIndex") == 6)
                PlayerPrefs.SetInt("LevelPriceScale", 2);
            if (PlayerPrefs.GetInt("MobIndex") >= 9)
                Destroy(_mainButton);
        }
    }
}
