using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites = new List<Sprite>();

    public float initSpeed = 1000f;
    public float gravity = 9.8f;
    public float verticalSpeed = 500f; 
    public float lifeTime = 0.75f;

    public RectTransform rectTransform;

    void OnEnable()
    {
        image.sprite = sprites[Random.Range(0, sprites.Count)];
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        float speed = initSpeed * Random.Range(0.7f, 1f);
        float timer = 0f;
        float vertical = verticalSpeed * Random.value;
        if(Random.value < 0.5f)
        {
            vertical *= -1;
        }

        while (timer < 1)
        {
            timer += Time.deltaTime / lifeTime;

            speed -= gravity;
            transform.localPosition += Vector3.up * speed * Time.deltaTime + Vector3.right * vertical * Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
        ClickEffectSpawner.Instance.DisableView(this);
    }
}
