using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    Button btn;
    Raf currentRaf;
    public TextMeshProUGUI currentRemainingTimeTxt, currentMassTxt, currentContentType;
    public GameObject choosePanel, uiButton, adreessContentDataPanel;
    public void OpenPanel()
    {
        uiButton.SetActive(false);
        choosePanel.SetActive(true);
        choosePanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.Linear);
    }
    public void OpenAddressPanel()
    {
        currentRaf = null;
        GameObject go = EventSystem.current.currentSelectedGameObject;
        currentRaf = go.GetComponentInParent<Raf>();

        currentRemainingTimeTxt.text = "Remaining Time : " + currentRaf.remainingTime.ToString();

        currentMassTxt.text = "Mass Type : " + currentRaf.massType.ToString();

        currentContentType.text = "Content Type : " + currentRaf.contentType.ToString();

        uiButton.SetActive(false);
        choosePanel.SetActive(false);
        adreessContentDataPanel.SetActive(true);
        adreessContentDataPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.Linear);
    }
    public void CloseAddressPanel()
    {
        adreessContentDataPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            adreessContentDataPanel.SetActive(false);
            uiButton.SetActive(true);
        });
    }
    public void RemainingType()
    {
        EventManager.Instance.RemainingType();
    }
    public void ContentType()
    {
        EventManager.Instance.ContentType();
    }
    public void MassType()
    {
        EventManager.Instance.MassType();
    }
    public void ExitButtonOnClick()
    {
        choosePanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            choosePanel.SetActive(false);
            uiButton.SetActive(true);
        });
    }
}
