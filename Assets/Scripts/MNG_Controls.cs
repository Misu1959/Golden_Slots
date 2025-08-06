using System;
using UnityEngine;

using static Constants;

public class MNG_Controls : MonoBehaviour
{
    public static MNG_Controls singleton;

    public Action onTotalBetChange;
    public Action onBetChange;
    public Action onLinesChange;


    public int totalBet { get; private set; } // total bet = bet * lines
    public BetAmounts bet { get; private set; } = BetAmounts._10;
    public LinesAmount lines    { get; private set; } = LinesAmount._5;


    private void Awake() => Initialize();
    void Start() => Setup();
    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }

    private void Setup()
    {
        bet   = MIN_BET;
        lines = MIN_NR_OF_LINES;

        CalculateTotalBet();

        onBetChange += CalculateTotalBet;
        onLinesChange += CalculateTotalBet;
    }

    private void CalculateTotalBet()
    {
        totalBet = (int)bet * (int)lines;
        onTotalBetChange?.Invoke();
    }

    public void IncreaseBet()
    {
        if (bet == MAX_BET)
            return;

        BetAmounts[] values = (BetAmounts[])Enum.GetValues(typeof(BetAmounts));
        int index = Array.IndexOf(values, bet);
        bet = values[index + 1];

        onBetChange?.Invoke();
    }
    public void DecreaseBet()
    {
        if (bet == MIN_BET)
            return;

        BetAmounts[] values = (BetAmounts[])Enum.GetValues(typeof(BetAmounts));
        int index = Array.IndexOf(values, bet);
        bet = values[index - 1];
        
        onBetChange?.Invoke();
    }

    public void IncreaseLines()
    {
        if (lines == MAX_NR_OF_LINES)
            return;

        LinesAmount[] values = (LinesAmount[])Enum.GetValues(typeof(LinesAmount));
        int index = Array.IndexOf(values, lines);
        lines = values[index + 1];
        
        onLinesChange?.Invoke();
    }
    public void DecreaseLines()
    {
        if (lines == MIN_NR_OF_LINES)
            return;

        LinesAmount[] values = (LinesAmount[])Enum.GetValues(typeof(LinesAmount));
        int index = Array.IndexOf(values, lines);
        lines = values[index - 1];
        
        onLinesChange?.Invoke();
    }

    public void SetBetToMaxBet()
    {
        int index = 0;
        BetAmounts[] values = (BetAmounts[])Enum.GetValues(typeof(BetAmounts));

        while (index < values.Length)
        {
            if (MNG_Credits.singleton.creditAmount < (int)values[index] * (int)lines)
                break;

            bet = values[index++];
        }

        if (index == 0)
            bet = values[0];

        onBetChange?.Invoke();
    }

}
