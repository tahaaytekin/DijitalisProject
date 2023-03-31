using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.ComponentModel;

public enum AddressType { A1, A2, A3, B1, B2, B3, C1, C2, C3, D1, D2, D3 }
public enum MassType { Heavy, Light }
public enum ContentType { drink, food }
public class Raf : MonoBehaviour
{
    public TextMeshProUGUI addresTypeTxt;
    public AddressType addressType;

    public List<MeshRenderer> meshRenderers;

    public int remainingTime;
    public TextMeshProUGUI remainingTimeTxt;

    public MassType massType;
    public TextMeshProUGUI massTxt;

    public ContentType contentType;
    public TextMeshProUGUI contentTxt;

    private void Start()
    {
        Describing();
        EventManager.Instance.OnContentType += ContentType;
        EventManager.Instance.OnMassType += MassType;
        EventManager.Instance.OnRemainingType += RemainingType;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnContentType -= ContentType;
        EventManager.Instance.OnMassType -= MassType;
        EventManager.Instance.OnRemainingType -= RemainingType;
    }
    public void Describing()
    {
        contentTxt.text = contentType.ToString();

        remainingTimeTxt.text = remainingTime.ToString();

        massTxt.text = massType.ToString();

        addresTypeTxt.text = addressType.ToString();
    }
    public void ContentType()
    {
        if (contentType == global::ContentType.drink)
        {
            ColoringYellow();
        }
        else
        {
            ColoringGreen();
        }
    }
    public void MassType()
    {
        if (massType == global::MassType.Heavy)
        {
            ColoringRed();
        }
        else
        {
            ColoringBlue();
        }
    }
    public void RemainingType()
    {
        if (remainingTime <= 30)
        {
            ColoringRed();
        }
        else
        {
            ColoringGreen();
        }
    }
    public void ColoringRed()
    {
        foreach (var item in meshRenderers)
        {
            item.materials[0].color = Color.red;
        }
    }
    public void ColoringGreen()
    {
        foreach (var item in meshRenderers)
        {
            item.materials[0].color = Color.green;
        }
    }
    public void ColoringBlue()
    {
        foreach (var item in meshRenderers)
        {
            item.materials[0].color = Color.blue;
        }
    }
    public void ColoringYellow()
    {
        foreach (var item in meshRenderers)
        {
            item.materials[0].color = Color.yellow;
        }
    }
}
