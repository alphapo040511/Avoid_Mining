using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellerView : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI priceText;
    public Button button;

    public Action onClick;

    // Start is called before the first frame update
    void Start()
    {
        if (button != null)
            button.onClick.AddListener(OnClick);
    }

    public void Init(Sprite icon, string name)
    {
        if (itemImage != null)
            itemImage.sprite = icon;

        if (name != null)
            itemName.text = name;
    }

    public void UpdatePrice(string price)
    {
        priceText.text = price;
    }

    private void OnClick()
    {
        onClick?.Invoke();
    }
}
