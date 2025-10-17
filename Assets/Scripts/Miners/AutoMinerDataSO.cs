using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MinerData", menuName = "Custom Data/MinerData")]
public class AutoMinerDataSO : ScriptableObject
{
    public string minerId;                      // id

    public Sprite pickImage;                    // ��� �̹���
    public Sprite mineralImage;                 // ���� �̹���

    public int maxCount = 20;                   // �ִ� ����

    public int minAmount = 5;                   // �ּ� ������
    public int maxAmount = 1000000;             // �ִ� ������

    public int firstPrice = 50;                 // ù ���� ����
    public int endPrice = 50000;                // ������ ���� ����


    public int GetAmount(int count)       // �ڿ� ������
    {
        if (count <= 0) return 0;

        // ���� ������ r ���
        double r = Math.Pow((double)maxAmount / minAmount, 1.0 / (maxCount - 1));

        // ���� ���귮 ���
        double amount = minAmount * Math.Pow(r, count - 1);

        // �ִ밪 cap
        if (amount > maxAmount) amount = maxAmount;

        return (int)amount;
    }

    public int PriceByPower(int count, double beta = 2)
    {
        if (count <= 0) return firstPrice;
        if (count >= maxCount - 1) return endPrice;

        double t = (double)(count) / (maxCount - 1);
        double price = firstPrice + (endPrice - firstPrice) * Math.Pow(t, beta);
        return (int)price;
    }

    [ContextMenu("���귮 Ȯ��")]
    public void DebugMPS()
    {
        string debug = "";
        for(int i = 1; i <= maxCount; i++)
        {
            debug += $"ä���� {i} �� | ";
            debug += GetAmount(i);
            debug += "\n";
        }

        Debug.Log(debug);
    }

    [ContextMenu("���Ű� Ȯ��")]
    public void DebugPrice()
    {
        string debug = "";
        for (int i = 0; i < maxCount; i++)
        {
            debug += $"ä���� {i} �� ������ | ";
            debug += PriceByPower(i);
            debug += "\n";
        }

        Debug.Log(debug);
    }
}
