using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMinerBase : MonoBehaviour
{
    [Header("생성기 데이터")]
    public AutoMinerDataSO minerData;

    [Header("miner references")]
    public Image pick;
    public Image mineral;
    public Transform pickPivot;

    [Header("Animation Settings")]
    public Vector3 originAngle = new Vector3(0, 0, -30f);
    public Vector3 targetAngle = new Vector3(0, 0, -60f);
    public float rotateSpeed = 6f;

    private float interval;
    private int amount;

    public float timer = 0f;

    private bool initialized = false;
    
    // Start is called before the first frame update
    void Start()
    {
        pickPivot.transform.localEulerAngles = originAngle;

        MinerSetting();
    }

    public void InitializeMiner(AutoMinerDataSO newData)
    {
        minerData = newData;        // 새로운 데이터 적용
        MinerSetting();
    }

    private void MinerSetting()
    {
        initialized = false;

        if (minerData != null)
        {
            pick.sprite = minerData.pickImage;
            mineral.sprite = minerData.mineralImage;

            interval = minerData.GenerationInterval;
            amount = minerData.generationAmount;
        }

        initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (initialized == false) return;

        timer += Time.deltaTime;
        if(timer >= interval)
        {
            timer -= interval;
            GenerateResource();
        }
    }

    void GenerateResource()
    {
        ResourceManager.Instance.AddResource(15);
        StartCoroutine(MiningAnimation());
        Debug.Log("자원 생산");
    }

    IEnumerator MiningAnimation()
    {
        Vector3 currentAngle = originAngle;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * rotateSpeed;
            currentAngle = Vector3.Slerp(originAngle, targetAngle, t);

            pickPivot.transform.localEulerAngles = currentAngle;

            yield return null;
        }

        while (t > 0)
        {
            t -= Time.deltaTime * rotateSpeed * 0.8f;
            currentAngle = Vector3.Slerp(originAngle, targetAngle, t);

            pickPivot.transform.localEulerAngles = currentAngle;

            yield return null;
        }

        pickPivot.transform.localEulerAngles = originAngle;
    }
}
