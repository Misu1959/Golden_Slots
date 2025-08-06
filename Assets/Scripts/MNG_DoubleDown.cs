using System;
using UnityEngine;

using Random = UnityEngine.Random;

public class MNG_DoubleDown : MonoBehaviour
{
    public static MNG_DoubleDown singleton;

    public Action onEnterDD;
    public Action onExitDD;

    public Action onPickCard;


    private void Awake() => Initialize();

    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }

    private void Start() => onExitDD += MNG_Credits.singleton.RemovePayout;

    public void EnterDD() => onEnterDD?.Invoke();
    public void ExitDD() => onExitDD?.Invoke();

    public void PickCard(DoubleDownCards myCard)
    {
        DoubleDownCards randCard = (DoubleDownCards)Random.Range(0, 2);

        if (myCard == randCard)
            MNG_Credits.singleton.AddPayout(MNG_Credits.singleton.payout);
        else
            ExitDD();

        onPickCard?.Invoke();
    }

    public void TakeWin()
    {
        MNG_Credits.singleton.AddCredit(MNG_Credits.singleton.payout);
        ExitDD();
    }

}
