using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualMiner : MonoBehaviour
{
    public Button clickPoint;

    public AutoMinerDataSO data;
    public int currentLevel { get; private set; } = 1;

    private int currentValue;

    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ListenerSetting();
        currentValue = data.GetAmount(currentLevel);
    }

    void ListenerSetting()
    {
        clickPoint.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ResourceManager.Instance.AddResource(currentValue);

        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(null, rt.position);

        float randomX = Random.Range(-30f, 30f);
        float randomY = Random.Range(-30f, 30f);
        screenPos += new Vector3(randomX, randomY, 0);

        ToastMessageManager.Instance.ShowMessage(currentValue, screenPos);
    }

    public void LevelUp()
    {
        currentLevel = currentLevel + 1;
        currentValue = data.GetAmount(currentLevel);
    }
}
