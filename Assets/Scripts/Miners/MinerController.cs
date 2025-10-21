using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinerController : MonoBehaviour
{
    [Header("생성기 데이터")]
    public AutoMinerDataSO minerData;

    public AutoMinerBase minerPrefabs;

    public TextMeshProUGUI generateInfoText;

    public Stack<AutoMinerBase> miners = new Stack<AutoMinerBase>();



    // Start is called before the first frame update
    void Start()
    {
        UpdateInfoText();
        StartCoroutine(GenerateResource());
    }

    IEnumerator GenerateResource()
    {
        while(true)
        {
            if (minerData != null && miners.Count > 0)
            {
                int amount = minerData.GetAmount(miners.Count);
                ResourceManager.Instance.AddResource(amount);
            }
            yield return new WaitForSeconds(1);
        }
    }

    [ContextMenu("New Miner")]
    public bool GenerateMiner()
    {
        if (miners.Count >= minerData.maxCount) return false;

        AutoMinerBase miner = Instantiate(minerPrefabs, transform);
        miner.transform.localPosition = GetNewMinerPosition(miners.Count + 1);
        miner.ChangeImage(minerData);
        miners.Push(miner);

        UpdateInfoText();

        return true;
    }

    Vector3 GetNewMinerPosition(int index)
    {
        //Vector3 pos = new Vector3(75 * index, 0, 0);

        //if(index % 2 == 0)
        //{
        //    // 짝수
        //    pos += Vector3.down * 50;
        //}
        //else
        //{
        //    pos += Vector3.right * 10 + Vector3.up * 25;
        //}

        Vector3 pos = new Vector3(60 * index, Random.Range(30f, 45f), 0);

        return pos;
    }

    void UpdateInfoText()
    {
        int value = minerData.GetAmount(miners.Count);

        generateInfoText.text = $"{CurrencyFormatter.Format(value)}/s";
    }
}
