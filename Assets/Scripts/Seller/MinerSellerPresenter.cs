using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerSellerPresenter : SellerPresenterBase
{
    public MinerController minerController;

    protected override void Initialize()
    {
        base.Initialize();
        view.Init(minerController.minerData.pickImage, minerController.minerData.minerName);
        UpdataPrice();
    }

    protected override void OnPurchase()
    {
        int count = minerController.miners.Count;
        int price = minerController.minerData.PriceByPower(count);

        if(ResourceManager.Instance.UseResource(price))
        {
            Complete();
            UpdataPrice();
        }
    }

    protected override void Complete()
    {
        base.Complete();
        minerController.GenerateMiner();
    }

    private void UpdataPrice()
    {
        int count = minerController.miners.Count;
        int price = minerController.minerData.PriceByPower(count);
        view.UpdatePrice(CurrencyFormatter.Format(price));
    }
}
