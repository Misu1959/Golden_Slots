using System;
using UnityEngine;


public class MNG_Base : MonoBehaviour
{
    public static MNG_Base singleton;

    private void Awake() => Initialize();
    
    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }


    public void Spin()
    {
        MNG_Credits.singleton.RemoveCredit(MNG_Controls.singleton.totalBet);
        MNG_Credits.singleton.AddPayout(5);
    }

    public void TakeWin()
    {
        MNG_Credits.singleton.AddCredit(MNG_Credits.singleton.payout);
        MNG_Credits.singleton.RemovePayout();
    }
    private void CheckForBonusGames()
    {

    }
}
