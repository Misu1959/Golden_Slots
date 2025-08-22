using System;
using UnityEngine;

public class MNG_Credits : MonoBehaviour
{
    public static MNG_Credits singleton;

    public Action onCreditsChange;
    
    public Action onPayoutChange;
    public Action onPayoutReset;


    public int creditAmount { get; private set; } = 500;
    public int payout { get; private set; }


    private void Awake() => Initialize();
    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }


    public void AddCredit(int creditAmountToAdd)
    {
        creditAmount += creditAmountToAdd;
        onCreditsChange?.Invoke();
    }
    public void RemoveCredit(int creditAmountToRemove)
    {
        creditAmount -= creditAmountToRemove;
        onCreditsChange?.Invoke();
    }


    public void AddPayout(int payoutToAdd)
    {
        if (payoutToAdd == 0)
            return;

        payout += payoutToAdd;
        onPayoutChange?.Invoke();
    }
    public void RemovePayout()
    {
        payout = 0;

        onPayoutChange?.Invoke();
        onPayoutReset?.Invoke();
    }
}
