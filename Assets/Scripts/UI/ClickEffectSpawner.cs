using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffectSpawner : SingletonMonoBehaviour<ClickEffectSpawner>
{
    public ClickEffect clickEffectPrefab;
    public Canvas canvas;

    private Queue<ClickEffect> effectQueue = new Queue<ClickEffect>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out mousePos
            );

            float x = Random.Range(-30f, 30f);
            float y = Random.Range(-10f, 10f);

            mousePos += new Vector2(x, y);

            ClickEffect effect = GenerateEffect();
            effect.GetComponent<RectTransform>().anchoredPosition = mousePos;
            effect.gameObject.SetActive( true );
        }
    }

    ClickEffect GenerateEffect()
    {
        ClickEffect effect;

        if(effectQueue.Count > 0)
        {
            effect = effectQueue.Dequeue();
        }
        else
        {
            effect = Instantiate(clickEffectPrefab, canvas.transform);
        }

        return effect;
    }

    public void DisableView(ClickEffect effect)
    {
        effectQueue.Enqueue(effect);
    }
}
