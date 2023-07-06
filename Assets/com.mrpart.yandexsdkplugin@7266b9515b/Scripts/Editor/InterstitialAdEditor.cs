#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YandexSDK;
public class InterstitialAdEditor : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private Text timerText;
    private int time = 3;
    private void OnEnable()
    {
        StartCoroutine(Count());
    }
    private void OnDestroy()
    {
        YaSDK.instance.OnInterstitialShown();
    }
    private IEnumerator Count()
    {
        int i = 0;
        while (i <= time)
        {
            timerText.text = "Рекламу можно закрыть через: " + (time - i).ToString();
            yield return new WaitForSecondsRealtime(1);
            i++;
        }
        timerText.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(true);
    }
    public void CloseAd()
    {
        Destroy(gameObject);
    }
}
#endif