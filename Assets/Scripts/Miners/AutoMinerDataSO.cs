using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MinerData", menuName = "Custom Data/MinerData")]
public class AutoMinerDataSO : ScriptableObject
{
    public string minerId;                      // id
    public float GenerationInterval;            // �ڿ� ���� �ֱ�
    public int generationAmount;                // �ڿ� ������
    public Sprite pickImage;                    // ��� �̹���
    public Sprite mineralImage;                 // ���� �̹���
}
