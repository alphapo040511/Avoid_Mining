using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MinerData", menuName = "Custom Data/MinerData")]
public class AutoMinerDataSO : ScriptableObject
{
    public string minerId;                      // id
    public string minerName;                    // 채굴기 이름

    public Sprite pickImage;                    // 곡괭이 이미지
    public Sprite mineralImage;                 // 광물 이미지

    public int maxCount = 20;                   // 최대 개수

    public int minAmount = 5;                   // 최소 생성량
    public int maxAmount = 1000000;             // 최대 생성량

    public int firstPrice = 50;                 // 첫 구매 가격
    public int endPrice = 50000;                // 마지막 구매 가격

    public float beta = 2;                      // 가격 증가율 계수
    public float priceValue = 1f;               // 생산률 증가 계수


    public int GetAmount(int count)       // 자원 생성량
    {
        if (count <= 0) return 0;

        // 지수 증가율 r 계산
        double r = Math.Pow((double)maxAmount / minAmount, priceValue / (maxCount - 1));

        // 현재 생산량 계산
        double amount = minAmount * Math.Pow(r, count - 1);

        // 최대값 cap
        if (amount > maxAmount) amount = maxAmount;

        return (int)amount;
    }

    public int PriceByPower(int count)
    {
        if (count <= 0) return firstPrice;
        if (count >= maxCount - 1) return endPrice;

        double t = (double)(count) / (maxCount - 1);
        double price = firstPrice + (endPrice - firstPrice) * Math.Pow(t, beta);
        return (int)price;
    }

    [ContextMenu("생산량 확인")]
    public void DebugMPS()
    {
        string debug = "";
        for(int i = 1; i <= maxCount; i++)
        {
            debug += $"채굴기 {i} 대 | ";
            debug += GetAmount(i);
            debug += "\n";
        }

        Debug.Log(debug);
    }

    [ContextMenu("구매가 확인")]
    public void DebugPrice()
    {
        string debug = "";
        for (int i = 0; i < maxCount; i++)
        {
            debug += $"채굴기 {i} 대 보유중 | ";
            debug += PriceByPower(i);
            debug += "\n";
        }

        Debug.Log(debug);
    }
}
