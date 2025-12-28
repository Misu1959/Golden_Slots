using UnityEngine;
using System.Collections.Generic;
using System;

public class M_Payment : MonoBehaviour
{
    public static M_Payment singleton;

    public PayLine[] payLines { get; private set; }

    private void Awake() => Initialize();

    private void Start() => Setup();

    private void Initialize()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }

    private void Setup()
    {
        CreatePayLines();
        SetPayLines();

        M_Controls.singleton.onSpin += () => Invoke(nameof(UpdatePayLines), Time.deltaTime);
    }

    private void CreatePayLines()
    {
        payLines = new PayLine[(int)Constants.MAX_NR_OF_LINES + 1];

        for (int i = 0; i < payLines.Length; i++)
            payLines[i] = new PayLine(i);

    }
    private void SetPayLines()
    {
        {
            payLines[0].AddReelSquare(1);
            payLines[0].AddReelSquare(1);
            payLines[0].AddReelSquare(1);
            payLines[0].AddReelSquare(1);
            payLines[0].AddReelSquare(1);
        } // PayLine 1

        {
            payLines[1].AddReelSquare(0);
            payLines[1].AddReelSquare(0);
            payLines[1].AddReelSquare(0);
            payLines[1].AddReelSquare(0);
            payLines[1].AddReelSquare(0);
        } // PayLine 2

        {
            payLines[2].AddReelSquare(2);
            payLines[2].AddReelSquare(2);
            payLines[2].AddReelSquare(2);
            payLines[2].AddReelSquare(2);
            payLines[2].AddReelSquare(2);
        } // PayLine 3

        {
            payLines[3].AddReelSquare(0);
            payLines[3].AddReelSquare(1);
            payLines[3].AddReelSquare(2);
            payLines[3].AddReelSquare(1);
            payLines[3].AddReelSquare(0);
        } // PayLine 4

        {
            payLines[4].AddReelSquare(2);
            payLines[4].AddReelSquare(1);
            payLines[4].AddReelSquare(0);
            payLines[4].AddReelSquare(1);
            payLines[4].AddReelSquare(2);
        } // PayLine 5

        {
            payLines[5].AddReelSquare(1);
            payLines[5].AddReelSquare(0);
            payLines[5].AddReelSquare(1);
            payLines[5].AddReelSquare(0);
            payLines[5].AddReelSquare(1);
        } // PayLine 6

        {
            payLines[6].AddReelSquare(1);
            payLines[6].AddReelSquare(2);
            payLines[6].AddReelSquare(1);
            payLines[6].AddReelSquare(2);
            payLines[6].AddReelSquare(1);
        } // PayLine 7

        {
            payLines[7].AddReelSquare(0);
            payLines[7].AddReelSquare(0);
            payLines[7].AddReelSquare(1);
            payLines[7].AddReelSquare(2);
            payLines[7].AddReelSquare(2);
        } // PayLine 8

        {
            payLines[8].AddReelSquare(2);
            payLines[8].AddReelSquare(2);
            payLines[8].AddReelSquare(1);
            payLines[8].AddReelSquare(0);
            payLines[8].AddReelSquare(0);
        } // PayLine 9

        {
            payLines[9].AddReelSquare(1);
            payLines[9].AddReelSquare(2);
            payLines[9].AddReelSquare(1);
            payLines[9].AddReelSquare(0);
            payLines[9].AddReelSquare(1);
        } // PayLine 10

        {
            payLines[10].AddReelSquare(1);
            payLines[10].AddReelSquare(0);
            payLines[10].AddReelSquare(1);
            payLines[10].AddReelSquare(2);
            payLines[10].AddReelSquare(1);
        } // PayLine 11

        {
            payLines[11].AddReelSquare(0);
            payLines[11].AddReelSquare(1);
            payLines[11].AddReelSquare(1);
            payLines[11].AddReelSquare(1);
            payLines[11].AddReelSquare(0);
        } // PayLine 12

        {
            payLines[12].AddReelSquare(2);
            payLines[12].AddReelSquare(1);
            payLines[12].AddReelSquare(1);
            payLines[12].AddReelSquare(1);
            payLines[12].AddReelSquare(2);
        } // PayLine 13

        {
            payLines[13].AddReelSquare(0);
            payLines[13].AddReelSquare(1);
            payLines[13].AddReelSquare(0);
            payLines[13].AddReelSquare(1);
            payLines[13].AddReelSquare(0);
        } // PayLine 14

        {
            payLines[14].AddReelSquare(2);
            payLines[14].AddReelSquare(1);
            payLines[14].AddReelSquare(2);
            payLines[14].AddReelSquare(1);
            payLines[14].AddReelSquare(2);
        } // PayLine 15

        {
            payLines[15].AddReelSquare(1);
            payLines[15].AddReelSquare(1);
            payLines[15].AddReelSquare(0);
            payLines[15].AddReelSquare(1);
            payLines[15].AddReelSquare(1);
        } // PayLine 16

        {
            payLines[16].AddReelSquare(1);
            payLines[16].AddReelSquare(1);
            payLines[16].AddReelSquare(2);
            payLines[16].AddReelSquare(1);
            payLines[16].AddReelSquare(1);
        } // PayLine 17

        {
            payLines[17].AddReelSquare(0);
            payLines[17].AddReelSquare(0);
            payLines[17].AddReelSquare(2);
            payLines[17].AddReelSquare(0);
            payLines[17].AddReelSquare(0);
        } // PayLine 18

        {
            payLines[18].AddReelSquare(2);
            payLines[18].AddReelSquare(2);
            payLines[18].AddReelSquare(0);
            payLines[18].AddReelSquare(2);
            payLines[18].AddReelSquare(2);
        } // PayLine 19

        {
            payLines[19].AddReelSquare(0);
            payLines[19].AddReelSquare(2);
            payLines[19].AddReelSquare(2);
            payLines[19].AddReelSquare(2);
            payLines[19].AddReelSquare(0);
        } // PayLine 20
    }

    private void UpdatePayLines()
    {
        for (int paylineIndex = 0; paylineIndex < payLines.Length - 1; paylineIndex++)
        {
            payLines[paylineIndex].Clear(); // Clear all symbols from payline

            for (int symbolIndex = 0; symbolIndex < Constants.NR_OF_REELS; symbolIndex++)
            {
                int reelIndex = payLines[paylineIndex].reelSquare[symbolIndex].Item1;
                int squareIndex = payLines[paylineIndex].reelSquare[symbolIndex].Item2;

                Symbols symbol = M_Reels.singleton.reels[reelIndex].squares[squareIndex];

                payLines[paylineIndex].Add(symbol); // Add new symbol to payline
            }
        }

        payLines[20].Clear();
    }

    public int CalculatePayLine(PayLine payLine)
    {
        while (payLine.IsValid())
        {
            if (payLine.IsWinning())
                return PayData.payTable[payLine] * (int)M_Controls.singleton.bet;

            payLine.Remove();
        }

        return 0;
    }




    private void DoScatterCheck()
    {
        foreach (Reel reel in M_Reels.singleton.reels)
            foreach (Symbols symbol in reel.squares)
                if (symbol == Symbols.scatter)
                    payLines[20].Add(symbol);

        // Trigger free games check
    }

}
