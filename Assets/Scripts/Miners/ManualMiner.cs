using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualMiner : MonoBehaviour
{
    public Button clickPoint;

    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ListenerSetting();
    }

    void ListenerSetting()
    {
        clickPoint.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        ResourceManager.Instance.AddResource(1000);

        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(null, rt.position);

        float randomX = Random.Range(-30f, 30f);
        float randomY = Random.Range(-30f, 30f);
        screenPos += new Vector3(randomX, randomY, 0);

        ToastMessageManager.Instance.ShowMessage(1000, screenPos);
    }
}
