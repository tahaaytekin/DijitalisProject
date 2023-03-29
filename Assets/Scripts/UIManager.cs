using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject choosePanel, uiButton;
    public void OpenPanel()
    {
        uiButton.SetActive(false);
        choosePanel.SetActive(true);
        choosePanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.Linear);
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
