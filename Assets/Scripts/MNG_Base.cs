using System;
using UnityEngine;


public class MNG_Base : MonoBehaviour
{
    public static MNG_Base singleton;

    private Reel[] reels = new Reel[Constants.NR_OF_REELS] { new Reel(0), new Reel(1), new Reel(2), new Reel(3), new Reel(4) };




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
        MNG_Credits.singleton.AddPayout(MNG_Payment.singleton.CalculateTotalPayout());

        SetReels();
    }

    public void TakeWin()
    {
        MNG_Credits.singleton.AddCredit(MNG_Credits.singleton.payout);
        MNG_Credits.singleton.RemovePayout();
    }

    private void SetReels()
    {
        foreach (Reel reel in reels)
            reel.Stop();

        foreach (Reel reel in reels)
        {
            foreach (Symbols symbol in reel.Get())
                Debug.Log(symbol);

            Debug.Log("\n");
        }
    }
}