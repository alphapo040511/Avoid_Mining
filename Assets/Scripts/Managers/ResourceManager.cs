using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class ResourceManager : SingletonMonoBehaviour<ResourceManager>
{
    public BigInteger gold { get; private set; }

    public void AddResource(BigInteger amount)
    {
        gold += amount;
    }

    public bool UseResource(int amount)
    {
        if (gold - amount < 0) return false;        // ��� �Ұ�


        gold -= amount;         // ���
        return true;
    }
}
