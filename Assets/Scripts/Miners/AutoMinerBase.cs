using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoMinerBase : MonoBehaviour
{
    [Header("miner references")]
    public Image pick;
    public Image mineral;
    public Transform pickPivot;

    [Header("Animation Settings")]
    public Vector3 originAngle = new Vector3(0, 0, -30f);
    public Vector3 targetAngle = new Vector3(0, 0, -60f);
    public float rotateSpeed = 6f;

    private float interval = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        interval = Random.Range(1f, 1.5f);

        pickPivot.transform.localEulerAngles = originAngle;

        StartCoroutine(AnimationCoroutine());
    }


    IEnumerator AnimationCoroutine()
    {
        while(true)
        {
            StartCoroutine(MiningAnimation());
            yield return new WaitForSeconds(interval);
        }
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
