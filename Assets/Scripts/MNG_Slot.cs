using System;
using System.Linq.Expressions;
using UnityEngine;

public class MNG_Slot : MonoBehaviour
{
    public static MNG_Slot singleton;

    public Action onEnterFreeSpinsMode;



    private void Awake() => Initialize();
    
    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }

    public void TakeWin()
    {
        MNG_Credits.singleton.AddCredit(MNG_Credits.singleton.payout);
        MNG_Credits.singleton.RemovePayout();
    }

    public void Spin()
    {
        MNG_Credits.singleton.RemoveCredit(MNG_Controls.singleton.totalBet);

        MNG_Credits.singleton.AddPayout(5);
    }


    private bool CompareSymbols(Symbols square1, Symbols square2) => square1 == square2;

    private void CheckPayTable()
    {

    }
    private void CheckForBonusGames()
    {

    }

    public void EnterFreeSpinsMode()
    {
        onEnterFreeSpinsMode?.Invoke();
    }

    public void EnterDoubleDownMode()
    {

    }

}
