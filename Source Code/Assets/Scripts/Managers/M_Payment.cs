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
            payLines[0].AddSquare(0, 1);
            payLines[0].AddSquare(1, 1);
            payLines[0].AddSquare(2, 1);
            payLines[0].AddSquare(3, 1);
            payLines[0].AddSquare(4, 1);
        } // PayLine 1

        {
            payLines[1].AddSquare(0, 0);
            payLines[1].AddSquare(1, 0);
            payLines[1].AddSquare(2, 0);
            payLines[1].AddSquare(3, 0);
            payLines[1].AddSquare(4, 0);

        } // PayLine 2

        {
            payLines[2].AddSquare(0,2);
            payLines[2].AddSquare(1,2);
            payLines[2].AddSquare(2,2);
            payLines[2].AddSquare(3,2);
            payLines[2].AddSquare(4, 2);
        } // PayLine 3

        {
            payLines[3].AddSquare(0,0);
            payLines[3].AddSquare(1,1);
            payLines[3].AddSquare(2,2);
            payLines[3].AddSquare(3,1);
            payLines[3].AddSquare(4, 0);
        } // PayLine 4

        {
            payLines[4].AddSquare(0,2);
            payLines[4].AddSquare(1,1);
            payLines[4].AddSquare(2,0);
            payLines[4].AddSquare(3,1);
            payLines[4].AddSquare(4, 2);
        } // PayLine 5

        {
            payLines[5].AddSquare(0,1);
            payLines[5].AddSquare(1,0);
            payLines[5].AddSquare(2,1);
            payLines[5].AddSquare(3,0);
            payLines[5].AddSquare(4, 1);
        } // PayLine 6

        {
            payLines[6].AddSquare(0,1);
            payLines[6].AddSquare(1,2);
            payLines[6].AddSquare(2,1);
            payLines[6].AddSquare(3,2);
            payLines[6].AddSquare(4, 1);
        } // PayLine 7

        {
            payLines[7].AddSquare(0,0);
            payLines[7].AddSquare(1,0);
            payLines[7].AddSquare(2,1);
            payLines[7].AddSquare(3,2);
            payLines[7].AddSquare(4, 2);
        } // PayLine 8

        {
            payLines[8].AddSquare(0,2);
            payLines[8].AddSquare(1,2);
            payLines[8].AddSquare(2,1);
            payLines[8].AddSquare(3,0);
            payLines[8].AddSquare(4, 0);
        } // PayLine 9

        {
            payLines[9].AddSquare(0,1);
            payLines[9].AddSquare(1,2);
            payLines[9].AddSquare(2,1);
            payLines[9].AddSquare(3,0);
            payLines[9].AddSquare(4, 1);
        } // PayLine 10

        {
            payLines[10].AddSquare(0,1);
            payLines[10].AddSquare(1,0);
            payLines[10].AddSquare(2,1);
            payLines[10].AddSquare(3,2);
            payLines[10].AddSquare(4, 1);
        } // PayLine 11

        {
            payLines[11].AddSquare(0,0);
            payLines[11].AddSquare(1,1);
            payLines[11].AddSquare(2,1);
            payLines[11].AddSquare(3,1);
            payLines[11].AddSquare(4, 0);
        } // PayLine 12

        {
            payLines[12].AddSquare(0,2);
            payLines[12].AddSquare(1,1);
            payLines[12].AddSquare(2,1);
            payLines[12].AddSquare(3,1);
            payLines[12].AddSquare(4, 2);
        } // PayLine 13

        {
            payLines[13].AddSquare(0,0);
            payLines[13].AddSquare(1,1);
            payLines[13].AddSquare(2,0);
            payLines[13].AddSquare(3,1);
            payLines[13].AddSquare(4, 0);
        } // PayLine 14

        {
            payLines[14].AddSquare(0,2);
            payLines[14].AddSquare(1,1);
            payLines[14].AddSquare(2,2);
            payLines[14].AddSquare(3,1);
            payLines[14].AddSquare(4, 2);
        } // PayLine 15

        {
            payLines[15].AddSquare(0,1);
            payLines[15].AddSquare(1,1);
            payLines[15].AddSquare(2,0);
            payLines[15].AddSquare(3,1);
            payLines[15].AddSquare(4, 1);
        } // PayLine 16

        {
            payLines[16].AddSquare(0,1);
            payLines[16].AddSquare(1,1);
            payLines[16].AddSquare(2,2);
            payLines[16].AddSquare(3,1);
            payLines[16].AddSquare(4, 1);
        } // PayLine 17

        {
            payLines[17].AddSquare(0,0);
            payLines[17].AddSquare(1,0);
            payLines[17].AddSquare(2,2);
            payLines[17].AddSquare(3,0);
            payLines[17].AddSquare(4, 0);
        } // PayLine 18

        {
            payLines[18].AddSquare(0,2);
            payLines[18].AddSquare(1,2);
            payLines[18].AddSquare(2,0);
            payLines[18].AddSquare(3,2);
            payLines[18].AddSquare(4, 2);
        } // PayLine 19

        {
            payLines[19].AddSquare(0,0);
            payLines[19].AddSquare(1,2);
            payLines[19].AddSquare(2,2);
            payLines[19].AddSquare(3,2);
            payLines[19].AddSquare(4, 0);
        } // PayLine 20


    }

    public void UpdatePayLines()
    {
        for(int i =0;i< (int)M_Controls.singleton.lines;i++)
            payLines[i].Update();

        payLines[(int)Constants.MAX_NR_OF_LINES].Update();
    }

}
