using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using YG;

public class AdsPanelPerMinute : MonoBehaviour
{
    [SerializeField] private GameObject _adsPanel;
    [SerializeField] private GameObject _doubleXPanel;
    [SerializeField] private GameObject _panel;
    [SerializeField] private YandexGame _yg;
    [SerializeField] private TMP_Text _currentGoldTMP;
    private float _timer = 0;

    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= 66f)
        {
            _timer = 0f;
            StartCoroutine(AdsPanel());
        }
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= 1)
            _panel.SetActive(false);
        else
            _panel.SetActive(true);
    }

    private IEnumerator AdsPanel()
    {
        _adsPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        _yg._FullscreenShow();
        _adsPanel.SetActive(false);
        _timer = 0f;
    }

    public void ShowDoubleXPanel()
    {
        _doubleXPanel.SetActive(true);
    }

    public void DisableDoubleXPanel()
    {
        _doubleXPanel.SetActive(false);
    }

    public void TripleXAdsButton()
    {
        if (PlayerPrefs.GetInt("CurrentGold") >= 1)
            _yg._RewardedShow(1);
    }

    public void Reward()
    {
        PlayerPrefs.SetInt("CurrentGold", PlayerPrefs.GetInt("CurrentGold") * 2);
        _currentGoldTMP.text = PlayerPrefs.GetInt("CurrentGold").ToString();
        _doubleXPanel.SetActive(false);
    }
}
