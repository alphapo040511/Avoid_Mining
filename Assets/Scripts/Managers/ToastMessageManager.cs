using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastMessageManager : SingletonMonoBehaviour<ToastMessageManager>
{
    public ToastMessageUI uiPrefab;
    public int initialUICount = 128;

    private Queue<ToastMessageUI> queue = new Queue<ToastMessageUI>();

    private void Start()
    {
        for(int i = 0; i < initialUICount; i++)
        {
            ToastMessageUI view = Instantiate(uiPrefab,transform);
            view.gameObject.SetActive(false);
            queue.Enqueue(view);
        }
    }

    public void ShowMessage(int amount, Vector2 pos)
    {
        ToastMessageUI view;
        if (queue.Count > 0)
        {
            view = queue.Dequeue();
        }
        else
        {
            view = Instantiate(uiPrefab, transform);
        }

        view.rectTransform.position = pos;
        view.Show(amount);
    }    
    
    public void DisableView(ToastMessageUI view)
    {
        queue.Enqueue(view);
    }
}
