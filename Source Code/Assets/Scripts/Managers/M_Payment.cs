using UnityEngine;
using System.Collections.Generic;

public class M_Payment : MonoBehaviour
{
    public static M_Payment singleton;

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }

    public int CalculateTotalPayout()
    {
        int totalPayout = 0;

        List<PayLine> payLines = new List<PayLine>();

        Do3LinesCheck(ref payLines);
        Do5LinesCheck(ref payLines);
        Do7LinesCheck(ref payLines);
        Do9LinesCheck(ref payLines);
        Do11LinesCheck(ref payLines);
        Do13LinesCheck(ref payLines);
        Do15LinesCheck(ref payLines);
        Do17LinesCheck(ref payLines);
        Do20LinesCheck(ref payLines);

        DoScatterCheck(ref payLines);

        int ind = 0;
        foreach (PayLine payLine in payLines)
        {
            while (payLine.size >= 2)
            {
                int payout = CalculatePayLine(payLine);
                if (payout == 0)
                {
                    M_UI_Reels.singleton.ToggleDisplayPayline(ind, false);

                    payLine.Remove();
                }
                else
                {
                    M_UI_Reels.singleton.ToggleDisplayPayline(ind, true);

                    totalPayout += payout;
                    break;
                }

            }
            ind++;

        }
        return totalPayout;


        /*
            For each payline check for a win like this:
            
            If payline is winning 
                add win and go to next payline
            Else
                Check same payline with 1 less symbol (needs at least 2 symbols in payline)
         */
    }


    private int CalculatePayLine(PayLine payLine)
    {
        if (!PayData.payTable.ContainsKey(payLine))
            return 0;

        return PayData.payTable[payLine] * (int)M_Controls.singleton.bet;
    }

    private void Do3LinesCheck(ref List<PayLine> payLines)
    {

        if (M_Controls.singleton.lines < LineAmounts._3)
            return;

        PayLine payLine1 = new PayLine();
        PayLine payLine2 = new PayLine();
        PayLine payLine3 = new PayLine();


        payLine1.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine1.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine1.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine1.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine1.Add(M_Reels.singleton.reels[4].squares[1]);

        payLine2.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine2.Add(M_Reels.singleton.reels[1].squares[0]);
        payLine2.Add(M_Reels.singleton.reels[2].squares[0]);
        payLine2.Add(M_Reels.singleton.reels[3].squares[0]);
        payLine2.Add(M_Reels.singleton.reels[4].squares[0]);

        payLine3.Add(M_Reels.singleton.reels[0].squares[2]);
        payLine3.Add(M_Reels.singleton.reels[1].squares[2]);
        payLine3.Add(M_Reels.singleton.reels[2].squares[2]);
        payLine3.Add(M_Reels.singleton.reels[3].squares[2]);
        payLine3.Add(M_Reels.singleton.reels[4].squares[2]);


        payLines.Add(payLine1);
        payLines.Add(payLine2);
        payLines.Add(payLine3);

    }
    private void Do5LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._5)
            return;

        PayLine payLine4 = new PayLine();
        PayLine payLine5 = new PayLine();

        payLine4.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine4.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine4.Add(M_Reels.singleton.reels[2].squares[2]);
        payLine4.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine4.Add(M_Reels.singleton.reels[4].squares[0]);

        payLine5.Add(M_Reels.singleton.reels[0].squares[2]);
        payLine5.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine5.Add(M_Reels.singleton.reels[2].squares[0]);
        payLine5.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine5.Add(M_Reels.singleton.reels[4].squares[2]);


        payLines.Add(payLine4);
        payLines.Add(payLine5);
    }
    private void Do7LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._7)
            return;

        PayLine payLine6 = new PayLine();
        PayLine payLine7 = new PayLine();

        payLine6.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine6.Add(M_Reels.singleton.reels[1].squares[0]);
        payLine6.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine6.Add(M_Reels.singleton.reels[3].squares[0]);
        payLine6.Add(M_Reels.singleton.reels[4].squares[1]);

        payLine7.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine7.Add(M_Reels.singleton.reels[1].squares[2]);
        payLine7.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine7.Add(M_Reels.singleton.reels[3].squares[2]);
        payLine7.Add(M_Reels.singleton.reels[4].squares[1]);

        payLines.Add(payLine6);
        payLines.Add(payLine7);
    }
    private void Do9LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._9)
            return;

        PayLine payLine8 = new PayLine();
        PayLine payLine9 = new PayLine();

        payLine8.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine8.Add(M_Reels.singleton.reels[1].squares[0]);
        payLine8.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine8.Add(M_Reels.singleton.reels[3].squares[2]);
        payLine8.Add(M_Reels.singleton.reels[4].squares[2]);

        payLine9.Add(M_Reels.singleton.reels[0].squares[2]);
        payLine9.Add(M_Reels.singleton.reels[1].squares[2]);
        payLine9.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine9.Add(M_Reels.singleton.reels[3].squares[0]);
        payLine9.Add(M_Reels.singleton.reels[4].squares[0]);



        payLines.Add(payLine8);
        payLines.Add(payLine9);
    }
    private void Do11LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._11)
            return;

        PayLine payLine10 = new PayLine();
        PayLine payLine11 = new PayLine();


        payLine10.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine10.Add(M_Reels.singleton.reels[1].squares[2]);
        payLine10.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine10.Add(M_Reels.singleton.reels[3].squares[0]);
        payLine10.Add(M_Reels.singleton.reels[4].squares[1]);

        payLine11.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine11.Add(M_Reels.singleton.reels[1].squares[0]);
        payLine11.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine11.Add(M_Reels.singleton.reels[3].squares[2]);
        payLine11.Add(M_Reels.singleton.reels[4].squares[1]);


        payLines.Add(payLine10);
        payLines.Add(payLine11);
    }
    private void Do13LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._13)
            return;

        PayLine payLine12 = new PayLine();
        PayLine payLine13 = new PayLine();


        payLine12.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine12.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine12.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine12.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine12.Add(M_Reels.singleton.reels[4].squares[0]);

        payLine13.Add(M_Reels.singleton.reels[0].squares[2]);
        payLine13.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine13.Add(M_Reels.singleton.reels[2].squares[1]);
        payLine13.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine13.Add(M_Reels.singleton.reels[4].squares[2]);


        payLines.Add(payLine12);
        payLines.Add(payLine13);
    }
    private void Do15LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._15)
            return;

        PayLine payLine14 = new PayLine();
        PayLine payLine15 = new PayLine();


        payLine14.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine14.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine14.Add(M_Reels.singleton.reels[2].squares[0]);
        payLine14.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine14.Add(M_Reels.singleton.reels[4].squares[0]);

        payLine15.Add(M_Reels.singleton.reels[0].squares[2]);
        payLine15.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine15.Add(M_Reels.singleton.reels[2].squares[2]);
        payLine15.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine15.Add(M_Reels.singleton.reels[4].squares[2]);


        payLines.Add(payLine14);
        payLines.Add(payLine15);
    }
    private void Do17LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._17)
            return;

        PayLine payLine16 = new PayLine();
        PayLine payLine17 = new PayLine();


        payLine16.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine16.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine16.Add(M_Reels.singleton.reels[2].squares[0]);
        payLine16.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine16.Add(M_Reels.singleton.reels[4].squares[1]);

        payLine17.Add(M_Reels.singleton.reels[0].squares[1]);
        payLine17.Add(M_Reels.singleton.reels[1].squares[1]);
        payLine17.Add(M_Reels.singleton.reels[2].squares[2]);
        payLine17.Add(M_Reels.singleton.reels[3].squares[1]);
        payLine17.Add(M_Reels.singleton.reels[4].squares[1]);


        payLines.Add(payLine16);
        payLines.Add(payLine17);
    }
    private void Do20LinesCheck(ref List<PayLine> payLines)
    {
        if (M_Controls.singleton.lines < LineAmounts._20)
            return;

        PayLine payLine18 = new PayLine();
        PayLine payLine19 = new PayLine();
        PayLine payLine20 = new PayLine();


        payLine18.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine18.Add(M_Reels.singleton.reels[1].squares[0]);
        payLine18.Add(M_Reels.singleton.reels[2].squares[2]);
        payLine18.Add(M_Reels.singleton.reels[3].squares[0]);
        payLine18.Add(M_Reels.singleton.reels[4].squares[0]);

        payLine19.Add(M_Reels.singleton.reels[0].squares[2]);
        payLine19.Add(M_Reels.singleton.reels[1].squares[2]);
        payLine19.Add(M_Reels.singleton.reels[2].squares[0]);
        payLine19.Add(M_Reels.singleton.reels[3].squares[2]);
        payLine19.Add(M_Reels.singleton.reels[4].squares[2]);

        payLine20.Add(M_Reels.singleton.reels[0].squares[0]);
        payLine20.Add(M_Reels.singleton.reels[1].squares[2]);
        payLine20.Add(M_Reels.singleton.reels[2].squares[2]);
        payLine20.Add(M_Reels.singleton.reels[3].squares[2]);
        payLine20.Add(M_Reels.singleton.reels[4].squares[0]);


        payLines.Add(payLine18);
        payLines.Add(payLine19);
        payLines.Add(payLine20);
    }


    private void DoScatterCheck(ref List<PayLine> payLines)
    {
        PayLine scatterPayLine = new PayLine();

        foreach (Reel reel in M_Reels.singleton.reels)
            foreach (Symbols symbol in reel.squares)
                if (symbol == Symbols.scatter)
                    scatterPayLine.Add(symbol);

        payLines.Add(scatterPayLine);
    
        // Trigger free games check
    }

}
