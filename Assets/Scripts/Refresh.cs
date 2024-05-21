using UnityEngine;

public class Refresh : MonoBehaviour
{
    public void Refreshhh()
    {
        PlayerPrefs.SetInt("GoldPerClick", 0);
        PlayerPrefs.SetInt("GoldPerSec", 0);
        PlayerPrefs.SetInt("CurrentGold", 0);
        PlayerPrefs.SetInt("LevelPrice", 10);
        PlayerPrefs.SetInt("LevelPriceScale", 10);
        PlayerPrefs.SetInt("MobIndex", 0);
    }
}
