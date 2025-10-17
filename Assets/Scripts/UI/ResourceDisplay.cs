using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    public TextMeshProUGUI resourceText;

    public float uiUpdateInterval = 0.2f;
    private float uiTimer;

    void Update()
    {
        uiTimer += Time.deltaTime;
        if (uiTimer >= uiUpdateInterval)                // 매번 UI를 업데이트 하면 렉 걸리니까요..ㅠ
        {
            uiTimer = 0;
            resourceText.text = CurrencyFormatter.Format(ResourceManager.Instance.gold);
        }
    }
}
