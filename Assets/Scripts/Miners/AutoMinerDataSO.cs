using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MinerData", menuName = "Custom Data/MinerData")]
public class AutoMinerDataSO : ScriptableObject
{
    public string minerId;                      // id
    public float GenerationInterval;            // 자원 생성 주기
    public int generationAmount;                // 자원 생성량
    public Sprite pickImage;                    // 곡괭이 이미지
    public Sprite mineralImage;                 // 광물 이미지
}
