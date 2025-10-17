using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToastMessageUI : MonoBehaviour
{
    public float acceleration = 5f;
    public float lifeTime = 0.75f;

    public TextMeshProUGUI tmp;

    public RectTransform rectTransform;

    public void Show(int amount)
    {
        tmp.text = CurrencyFormatter.Format(amount);
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        float speed = 0f;
        float timer = 0f;
        Color color = tmp.color;

        while (timer < 1)
        { 
            timer += Time.deltaTime / lifeTime;

            speed += acceleration;
            transform.localPosition += Vector3.up * speed * Time.deltaTime;

            color.a = 1 - timer;
            tmp.color = color;

            yield return null;
        }

        gameObject.SetActive(false);
        ToastMessageManager.Instance.DisableView(this);
    }
}
