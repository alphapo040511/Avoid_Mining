using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualSellerPresneter : SellerPresenterBase
{
    public ManualMiner miner;

    protected override void Initialize()
    {
        base.Initialize();
        view.Init(miner.data.pickImage, miner.data.minerId);
        UpdataPrice();
    }

    protected override void OnPurchase()
    {
        int count = miner.currentLevel;
        int price = miner.data.PriceByPower(count - 1, 3);

        if (ResourceManager.Instance.UseResource(price))
        {
            Complete();
            UpdataPrice();
        }
    }

    protected override void Complete()
    {
        base.Complete();
        miner.LevelUp();
    }

    private void UpdataPrice()
    {
        int count = miner.currentLevel;
        int price = miner.data.PriceByPower(count - 1, 3);
        view.UpdatePrice(CurrencyFormatter.Format(price));
    }
}
