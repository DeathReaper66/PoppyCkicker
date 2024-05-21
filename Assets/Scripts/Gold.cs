using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentGoldTMP;
    [SerializeField] private TMP_Text _goldPerSecondTMP;
    [SerializeField] private GameObject _mob;

    private float _goldPerSecTimer = 0f;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("GoldPerClick") == 0)
            PlayerPrefs.SetInt("GoldPerClick", 1);

        _goldPerSecondTMP.text = PlayerPrefs.GetInt("GoldPerSec").ToString();
        _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();
    }

    private void FixedUpdate()
    {
        _goldPerSecTimer += Time.fixedDeltaTime;
        if (_goldPerSecTimer > 1f)
        {
            _goldPerSecTimer = 0f;
            PlayerPrefs.SetInt("CurrentGold", PlayerPrefs.GetInt("CurrentGold") + PlayerPrefs.GetInt("GoldPerSec"));
            _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();
        }
    }

    public void MobOnClick()
    {
        _mob.GetComponent<Animator>().SetTrigger("OnClick");
        PlayerPrefs.SetInt("CurrentGold", PlayerPrefs.GetInt("CurrentGold") + PlayerPrefs.GetInt("GoldPerClick"));
        _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();
        Debug.Log(PlayerPrefs.GetInt("GoldPerClick"));
    }

    public void SetGoldPerClick(int ValueForSum)
    {
        PlayerPrefs.SetInt("GoldPerClick", PlayerPrefs.GetInt("GoldPerClick") + ValueForSum);
    }

    public void SetGoldPerSec(int ValueForSum)
    {
        PlayerPrefs.SetInt("GoldPerSec", PlayerPrefs.GetInt("GoldPerSec") + ValueForSum);
        _goldPerSecondTMP.text = PlayerPrefs.GetInt("GoldPerSec").ToString();
    }
}
