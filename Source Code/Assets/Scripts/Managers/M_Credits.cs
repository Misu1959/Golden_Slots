/*
    Credit = total available credit
    Payout = credit that can be added to Credit or DoubledDown (Can be seen as potential credit)
 */


using System;
using UnityEngine;


public class M_Credits : MonoBehaviour
{
    public static M_Credits singleton;

    public Action onCreditsChange;
    
    public Action onPayoutChange;

    [field:SerializeField] public int creditAmount { get; private set; }
    public int payout { get; private set; }


    private void Start() => Setup();
    private void Awake() => Initialize();
    private void Initialize()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }

    private void Setup()
    {
        M_Controls.singleton.onSpin += () => RemoveCredit(M_Controls.singleton.totalBet);
    }
    public void TakeWin()
    {
        AddCredit(payout);
        RemovePayout();
    }

    private void AddCredit(int creditAmountToAdd)
    {
        creditAmount += creditAmountToAdd;
        onCreditsChange?.Invoke();
    }
    private void RemoveCredit(int creditAmountToRemove)
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
    private void RemovePayout()
    {
        payout = 0;
        onPayoutChange?.Invoke();
    }
}
