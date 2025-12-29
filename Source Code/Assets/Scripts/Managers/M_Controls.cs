using System;
using UnityEngine;

using static Constants;

public class M_Controls : MonoBehaviour
{
    public static M_Controls singleton {  get; private set; }

    public Action onAutoSpinsChange;
    public Action onLinesChange;
    public Action onBetChange;
    public Action onTotalBetChange;
    public Action onSpin;


    public AutoSpinAmounts autoSpins { get; private set; } = MIN_NR_OF_AUTO_SPINS;
    public LineAmounts lines { get; private set; } = MIN_NR_OF_LINES;
    public BetAmounts bet { get; private set; } = MIN_BET;
    public int totalBet { get; private set; } // total bet = bet * lines


    public int autoSpinsLeft { get; private set; } = (int)MIN_NR_OF_AUTO_SPINS;
    public bool isAutoSpinning { get; private set; }

    private void Awake() => Initialize();
    void Start() => Invoke(nameof(Setup), Time.deltaTime);
    private void Initialize()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }

    private void Setup()
    {
        onLinesChange += CalculateTotalBet;
        onBetChange += CalculateTotalBet;

        onAutoSpinsChange?.Invoke();
        onLinesChange?.Invoke();
        onBetChange?.Invoke();
    }

    #region Auto Spins

    public void StartAutoSpinning()
    {
        M_Credits.singleton.TakeWin();

        isAutoSpinning = true;
        autoSpinsLeft--;

        onSpin?.Invoke();
        onAutoSpinsChange?.Invoke();
    }

    public void StopAutoSpinning()
    {
        autoSpinsLeft = (int)autoSpins;
        isAutoSpinning = false;

        onAutoSpinsChange?.Invoke();
    }



    public void DecreaseAutoSpins()
    {
        if (autoSpins == MIN_NR_OF_AUTO_SPINS)
            return;

        AutoSpinAmounts[] values = (AutoSpinAmounts[])Enum.GetValues(typeof(AutoSpinAmounts));
        int index = Array.IndexOf(values, autoSpins);
        autoSpins = values[index - 1];
        autoSpinsLeft = (int)autoSpins;

        onAutoSpinsChange?.Invoke();
    }
    public void IncreaseAutoSpins()
    {
        if (autoSpins == MAX_NR_OF_AUTO_SPINS)
            return;

        AutoSpinAmounts[] values = (AutoSpinAmounts[])Enum.GetValues(typeof(AutoSpinAmounts));
        int index = Array.IndexOf(values, autoSpins);
        autoSpins = values[index + 1];
        autoSpinsLeft = (int)autoSpins;

        onAutoSpinsChange?.Invoke();
    }




    #endregion

    #region Lines

    public void MaxLines()
    {
        int index = 0;
        LineAmounts[] values = (LineAmounts[])Enum.GetValues(typeof(LineAmounts));

        while (index < values.Length)
        {
            if (M_Credits.singleton.creditAmount < (int)values[index] * (int)bet)
                break;

            index++;
        }

        lines = values[index - 1];

        onLinesChange?.Invoke();
    }
    public void DecreaseLines()
    {
        if (lines == MIN_NR_OF_LINES)
            return;

        LineAmounts[] values = (LineAmounts[])Enum.GetValues(typeof(LineAmounts));
        int index = Array.IndexOf(values, lines);
        lines = values[index - 1];

        onLinesChange?.Invoke();
    }
    public void IncreaseLines()
    {
        if (lines == MAX_NR_OF_LINES)
            return;

        LineAmounts[] values = (LineAmounts[])Enum.GetValues(typeof(LineAmounts));
        int index = Array.IndexOf(values, lines);
        lines = values[index + 1];

        onLinesChange?.Invoke();
    }


    #endregion

    #region Bet

    private void CalculateTotalBet()
    {
        totalBet = (int)bet * (int)lines;
        onTotalBetChange?.Invoke();
    }




    public void MaxBet()
    {
        int index = 0;
        BetAmounts[] values = (BetAmounts[])Enum.GetValues(typeof(BetAmounts));

        while (index < values.Length)
        {
            if (M_Credits.singleton.creditAmount < (int)values[index] * (int)lines)
                break;

            index++;
        }

        bet = values[index - 1];

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
    public void IncreaseBet()
    {
        if (bet == MAX_BET)
            return;

        BetAmounts[] values = (BetAmounts[])Enum.GetValues(typeof(BetAmounts));
        int index = Array.IndexOf(values, bet);
        bet = values[index + 1];

        onBetChange?.Invoke();
    }

    public void TotalMaxBet()
    {
        (LineAmounts, BetAmounts) bestPair = (MIN_NR_OF_LINES, MIN_BET);
        int closestBetDistance = Mathf.Abs((int)MIN_NR_OF_LINES * (int)MIN_BET - M_Credits.singleton.creditAmount);


        LineAmounts[] lineValues = (LineAmounts[])Enum.GetValues(typeof(LineAmounts));
        BetAmounts[] betValues = (BetAmounts[])Enum.GetValues(typeof(BetAmounts));


        int lineIndex = 0;
        while (lineIndex < lineValues.Length)
        {
            int betIndex = 0;
            while (betIndex < betValues.Length)
            {
                int betVal = (int)lineValues[lineIndex] * (int)betValues[betIndex];
                if (betVal > M_Credits.singleton.creditAmount)
                    break;

                int betDistance = Mathf.Abs(betVal - M_Credits.singleton.creditAmount);
                if (betDistance < closestBetDistance)
                {
                    closestBetDistance = betDistance;
                    bestPair.Item1 = lineValues[lineIndex];
                    bestPair.Item2 = betValues[betIndex];
                }

                betIndex++;
            }
            lineIndex++;
        }
        
        
        lines = bestPair.Item1;
        bet = bestPair.Item2;

        onLinesChange?.Invoke();
        onBetChange?.Invoke();
    }

    #endregion

    #region Spin

    public void Spin() => onSpin?.Invoke();

    #endregion
}
