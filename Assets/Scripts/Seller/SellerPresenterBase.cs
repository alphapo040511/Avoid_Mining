using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SellerPresenterBase : MonoBehaviour
{
    public SellerView view;

    public UnityEvent onPurchase;

    private void Start()
    {
        Initialize();
    }
    
    protected virtual void Initialize()
    {
        view.onClick += OnPurchase;
    }

    protected virtual void OnPurchase()
    {
        
    }

    protected virtual void Complete()
    {
        onPurchase?.Invoke();
    }
}
