using UnityEngine;
using System.Collections.Generic;

public class MNG_Payment : MonoBehaviour
{
    public static MNG_Payment singleton;

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }


    public int CalculateTotalPayout()
    {
        int totalPayout = 0;

        List<PayLine> payLines = new List<PayLine>();

        Do3LinesCheck(ref payLines);
        Do5LinesCheck(ref payLines);
        Do9LinesCheck(ref payLines);

        DoScatterCheck(ref payLines);

        foreach (PayLine payLine in payLines)
            while (payLine.size >= 3)
            {
                int payout = CalculatePayLine(payLine);
                totalPayout += payout;

                if (payout == 0)
                    payLine.Remove();
                else
                    break;
            }

        return totalPayout;
    }


    private int CalculatePayLine(PayLine payLine)
    {
        if (!PayData.payTable.ContainsKey(payLine))
            return 0;

        return PayData.payTable[payLine] * (int)MNG_Controls.singleton.bet;
    }

    private void Do3LinesCheck(ref List<PayLine> payLines)
    {

        if (MNG_Controls.singleton.lines < LinesAmount._3)
            return;

        PayLine[] lines = new PayLine[3] { new(), new(),new() };

        for (int l = 0; l < 3; l++) // line index
            for (int s = 0; s < 5; s++) // symbol index
                lines[l].Add(MNG_Base.singleton.reels[s].squares[l]);

        payLines.Add(lines[0]);
        payLines.Add(lines[1]);
        payLines.Add(lines[2]);

    }
    private void Do5LinesCheck(ref List<PayLine> payLines)
    {
        if (MNG_Controls.singleton.lines < LinesAmount._5)
            return;

        PayLine[] lines = new PayLine[2] { new(), new() };

        lines[0].Add(MNG_Base.singleton.reels[0].squares[0]);
        lines[0].Add(MNG_Base.singleton.reels[1].squares[1]);
        lines[0].Add(MNG_Base.singleton.reels[2].squares[2]);
        lines[0].Add(MNG_Base.singleton.reels[3].squares[1]);
        lines[0].Add(MNG_Base.singleton.reels[4].squares[0]);

        lines[1].Add(MNG_Base.singleton.reels[0].squares[2]);
        lines[1].Add(MNG_Base.singleton.reels[1].squares[1]);
        lines[1].Add(MNG_Base.singleton.reels[2].squares[0]);
        lines[1].Add(MNG_Base.singleton.reels[3].squares[1]);
        lines[1].Add(MNG_Base.singleton.reels[4].squares[2]);


        payLines.Add(lines[0]);
        payLines.Add(lines[1]);
    }
    private void Do9LinesCheck(ref List<PayLine> payLines)
    {
        if (MNG_Controls.singleton.lines < LinesAmount._9)
            return;

        PayLine[] lines = new PayLine[4] {new(), new(), new(), new()};

        lines[0].Add(MNG_Base.singleton.reels[0].squares[0]);
        lines[0].Add(MNG_Base.singleton.reels[1].squares[0]);
        lines[0].Add(MNG_Base.singleton.reels[2].squares[2]);
        lines[0].Add(MNG_Base.singleton.reels[3].squares[0]);
        lines[0].Add(MNG_Base.singleton.reels[4].squares[0]);

        lines[1].Add(MNG_Base.singleton.reels[0].squares[2]);
        lines[1].Add(MNG_Base.singleton.reels[1].squares[2]);
        lines[1].Add(MNG_Base.singleton.reels[2].squares[0]);
        lines[1].Add(MNG_Base.singleton.reels[3].squares[2]);
        lines[1].Add(MNG_Base.singleton.reels[4].squares[2]);

        lines[2].Add(MNG_Base.singleton.reels[0].squares[1]);
        lines[2].Add(MNG_Base.singleton.reels[1].squares[1]);
        lines[2].Add(MNG_Base.singleton.reels[2].squares[0]);
        lines[2].Add(MNG_Base.singleton.reels[3].squares[1]);
        lines[2].Add(MNG_Base.singleton.reels[4].squares[1]);

        lines[3].Add(MNG_Base.singleton.reels[0].squares[1]);
        lines[3].Add(MNG_Base.singleton.reels[1].squares[1]);
        lines[3].Add(MNG_Base.singleton.reels[2].squares[2]);
        lines[3].Add(MNG_Base.singleton.reels[3].squares[1]);
        lines[3].Add(MNG_Base.singleton.reels[4].squares[1]);


        payLines.Add(lines[0]);
        payLines.Add(lines[1]);
        payLines.Add(lines[2]);
        payLines.Add(lines[3]);
    }

    private void DoScatterCheck(ref List<PayLine> payLines)
    {
        PayLine scatterPayLine = new PayLine();

        foreach (Reel reel in MNG_Base.singleton.reels)
            foreach (Symbols symbol in reel.squares)
                if (symbol == Symbols.scatter)
                    scatterPayLine.Add(symbol);

        payLines.Add(scatterPayLine);
    
        // Trigger free games check
    }

}
