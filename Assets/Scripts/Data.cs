using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Symbols
{
    ten,
    jack,
    queen,
    king,
    ace,
    symbol_1,
    symbol_2,
    symbol_3,

    scatter,
    wild
}

[Serializable]
public enum BetAmounts
{
    _10 = 10,
    _20 = 20,
    _30 = 30,
    _40 = 40,
    _50 = 50,
    _60 = 60,
    _70 = 70,
    _80 = 80,
    _90 = 90,
    _100 = 100
};

[Serializable]
public enum LinesAmount
{
    _5  = 5,
    _7  = 7,
    _10 = 10
};

public class Reel
{
    public Symbols[] squares { get; private set; }
}
public static class Data
{
    public static int NR_OF_REELS => 5;    
    public static int NR_OF_SQUARES => 3;


    public static LinesAmount MIN_NR_OF_LINES => LinesAmount._5;
    public static LinesAmount MAX_NR_OF_LINES => LinesAmount._10;

    public static BetAmounts MIN_BET => BetAmounts._10;
    public static BetAmounts MAX_BET => BetAmounts._100;
        
};

//public static Dictionary<List<Symbols>, int> payoutTable = new Dictionary<List<Symbols>, int>
//        {
//            { new List<Symbols>{ Symbols.ten, Symbols.ten, Symbols.ten }, 10 },

//            { new List<Symbols>{ Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten }, 20 },
//            { new List<Symbols>{ Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten,Symbols.ten }, 50 }
//        };
