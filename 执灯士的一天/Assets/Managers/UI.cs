using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("End screen")]
    [SerializeField] private UI_FadeScreen fadeScreen;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject restartButton;
    [Space]

    [SerializeField] private GameObject InGameUI;

    void Start()
    {
        SwitchTo(InGameUI);
    }
    
    public void SwitchTo(GameObject _menu)
    { 
        for (int i = 0; i < transform.childCount; i++)
        {
            bool fadeScreen = transform.GetChild(i).GetComponent<UI_FadeScreen>() != null;

            if (fadeScreen == false)
                transform.GetChild(i).gameObject.SetActive(false);
        }

        if (_menu != null)
             _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if (_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            CheckForInGameUI();
            return;
        }
        SwitchTo(_menu);
    }

    public void CheckForInGameUI()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
                return;
        }
        SwitchTo(InGameUI);
    }
    public void SwitchOnEndScreen()
    {
        fadeScreen.FadeOut();
        StartCoroutine(EndScreenCorutione());
    }
    IEnumerator EndScreenCorutione()
    {
        yield return new WaitForSeconds(1f);
        endText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        restartButton.SetActive(true);

    }
   public void RestartGameButton() => GameManager.instance.RestartScene();
}
