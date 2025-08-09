using System;
using System.Collections.Generic;

using Random = UnityEngine.Random;

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
public enum DoubleDownCards
{
    red,
    black
};

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



public class Constants
{
    public const int NR_OF_STOPS = 100;

    public const int NR_OF_REELS    = 5;    
    public const int NR_OF_SQUARES  = 3;


    public const LinesAmount MIN_NR_OF_LINES = LinesAmount._5;
    public const LinesAmount MAX_NR_OF_LINES = LinesAmount._10;

    public const BetAmounts MIN_BET = BetAmounts._10;
    public const BetAmounts MAX_BET = BetAmounts._100;
        
};




public class VirtualReels
{
    /*
        25 tens
        12 jacks
        12 queens
        12 kings
        12 aces
        8  symbol_1
        8  symbol_2
        5  symbol_3
        4  wild
        2  scatter

    */

    public static List<Symbols[]> reels => new List<Symbols[]>()
    {
        // Reel 1
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.ten,        Symbols.king,       Symbols.queen,      Symbols.symbol_1,   Symbols.jack,       Symbols.ten,        Symbols.queen,      Symbols.scatter,    Symbols.queen,      Symbols.ten,
        Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.king,       Symbols.king,       Symbols.jack,       Symbols.symbol_2,   Symbols.jack,       Symbols.queen,      Symbols.scatter,
        Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.symbol_3,   Symbols.ten,        Symbols.king,       Symbols.symbol_2,   Symbols.symbol_1,   Symbols.symbol_3,   Symbols.ten,
        Symbols.ten,        Symbols.ace,        Symbols.ace,        Symbols.symbol_2,   Symbols.king,       Symbols.ten,        Symbols.symbol_3,   Symbols.symbol_1,   Symbols.ten,        Symbols.queen,
        Symbols.symbol_1,   Symbols.symbol_2,   Symbols.ten,        Symbols.queen,      Symbols.ace,        Symbols.queen,      Symbols.jack,       Symbols.ten,        Symbols.ten,        Symbols.ten,
        Symbols.jack,       Symbols.jack,       Symbols.ten,        Symbols.jack,       Symbols.queen,      Symbols.ten,        Symbols.jack,       Symbols.symbol_2,   Symbols.ten,        Symbols.jack,
        Symbols.symbol_2,   Symbols.ace,        Symbols.king,       Symbols.king,       Symbols.ace,        Symbols.wild,       Symbols.king,       Symbols.symbol_1,   Symbols.ten,        Symbols.ace,
        Symbols.ten,        Symbols.jack,       Symbols.ace,        Symbols.symbol_1,   Symbols.king,       Symbols.ace,        Symbols.wild,       Symbols.wild,       Symbols.ten,        Symbols.symbol_3,
        Symbols.symbol_2,   Symbols.queen,      Symbols.symbol_2,   Symbols.wild,       Symbols.jack,       Symbols.queen,      Symbols.queen,      Symbols.ten,        Symbols.symbol_1,   Symbols.symbol_1,
        Symbols.ace,        Symbols.ace,        Symbols.ace,        Symbols.king,       Symbols.king,       Symbols.jack,       Symbols.ten,        Symbols.ten,        Symbols.queen,      Symbols.symbol_3
        },

        // Reel2
        new Symbols[Constants.NR_OF_STOPS] 
        {
        Symbols.ten,        Symbols.king,       Symbols.king,       Symbols.symbol_1,   Symbols.symbol_3,   Symbols.jack,       Symbols.wild,       Symbols.jack,       Symbols.queen,      Symbols.symbol_2,
        Symbols.ace,        Symbols.queen,      Symbols.queen,      Symbols.ten,        Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.wild,       Symbols.ace,
        Symbols.jack,       Symbols.ten,        Symbols.symbol_3,   Symbols.queen,      Symbols.symbol_1,   Symbols.jack,       Symbols.symbol_1,   Symbols.ten,        Symbols.jack,       Symbols.ten,
        Symbols.wild,       Symbols.king,       Symbols.king,       Symbols.queen,      Symbols.queen,      Symbols.ace,        Symbols.symbol_1,   Symbols.symbol_2,   Symbols.ten,        Symbols.symbol_1,
        Symbols.ten,        Symbols.king,       Symbols.symbol_2,   Symbols.queen,      Symbols.ten,        Symbols.ten,        Symbols.symbol_2,   Symbols.king,       Symbols.jack,       Symbols.ace,
        Symbols.scatter,    Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.ace,        Symbols.king,       Symbols.symbol_2,   Symbols.ace,        Symbols.ace,
        Symbols.ten,        Symbols.queen,      Symbols.symbol_2,   Symbols.ten,        Symbols.queen,      Symbols.jack,       Symbols.ace,        Symbols.jack,       Symbols.symbol_3,   Symbols.queen,
        Symbols.ten,        Symbols.symbol_2,   Symbols.ten,        Symbols.wild,       Symbols.king,       Symbols.ten,        Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ten,
        Symbols.scatter,    Symbols.symbol_1,   Symbols.queen,      Symbols.symbol_3,   Symbols.jack,       Symbols.ten,        Symbols.symbol_2,   Symbols.jack,       Symbols.symbol_1,   Symbols.symbol_1,
        Symbols.queen,      Symbols.ten,        Symbols.ace,        Symbols.jack,       Symbols.ace,        Symbols.king,       Symbols.ten,        Symbols.jack,       Symbols.ten,        Symbols.symbol_3
        },

        // Reel 3
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.ten,        Symbols.queen,      Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.symbol_2,   Symbols.ten,        Symbols.scatter,
        Symbols.symbol_1,   Symbols.ten,        Symbols.jack,       Symbols.ace,        Symbols.jack,       Symbols.symbol_2,   Symbols.jack,       Symbols.ten,        Symbols.symbol_1,   Symbols.jack,
        Symbols.queen,      Symbols.ten,        Symbols.symbol_2,   Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.jack,       Symbols.ace,        Symbols.ten,
        Symbols.ace,        Symbols.queen,      Symbols.wild,       Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.queen,      Symbols.jack,       Symbols.symbol_3,
        Symbols.symbol_2,   Symbols.wild,       Symbols.ten,        Symbols.ten,        Symbols.scatter,    Symbols.queen,      Symbols.symbol_2,   Symbols.queen,      Symbols.jack,       Symbols.ten,
        Symbols.symbol_2,   Symbols.symbol_3,   Symbols.king,       Symbols.symbol_1,   Symbols.queen,      Symbols.jack,       Symbols.ten,        Symbols.king,       Symbols.ace,        Symbols.queen,
        Symbols.ten,        Symbols.ten,        Symbols.symbol_1,   Symbols.symbol_1,   Symbols.symbol_3,   Symbols.symbol_1,   Symbols.symbol_3,   Symbols.wild,       Symbols.jack,       Symbols.ace,
        Symbols.ten,        Symbols.jack,       Symbols.queen,      Symbols.symbol_3,   Symbols.king,       Symbols.symbol_1,   Symbols.ten,        Symbols.king,       Symbols.ace,        Symbols.king,
        Symbols.king,       Symbols.symbol_2,   Symbols.king,       Symbols.wild,       Symbols.jack,       Symbols.king,       Symbols.symbol_2,   Symbols.queen,      Symbols.ten,        Symbols.queen,
        Symbols.jack,       Symbols.ace,        Symbols.ace,        Symbols.ace,        Symbols.symbol_1,   Symbols.ten,        Symbols.king,       Symbols.king,       Symbols.king,       Symbols.queen
        },

        // Reel 4
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.ace,        Symbols.king,       Symbols.ace,        Symbols.ten,        Symbols.ace,        Symbols.queen,      Symbols.symbol_2,   Symbols.ten,        Symbols.symbol_3,   Symbols.ten,
        Symbols.symbol_3,   Symbols.king,       Symbols.ace,        Symbols.ten,        Symbols.queen,      Symbols.king,       Symbols.ace,        Symbols.ten,        Symbols.jack,       Symbols.jack,
        Symbols.king,       Symbols.king,       Symbols.symbol_3,   Symbols.ten,        Symbols.ace,        Symbols.queen,      Symbols.ace,        Symbols.symbol_3,   Symbols.wild,       Symbols.ten,
        Symbols.king,       Symbols.king,       Symbols.symbol_1,   Symbols.symbol_1,   Symbols.ten,        Symbols.ten,        Symbols.symbol_1,   Symbols.symbol_2,   Symbols.symbol_1,   Symbols.symbol_2,
        Symbols.wild,       Symbols.symbol_2,   Symbols.symbol_2,   Symbols.symbol_1,   Symbols.ace,        Symbols.ace,        Symbols.king,       Symbols.ten,        Symbols.queen,      Symbols.ten,
        Symbols.jack,       Symbols.jack,       Symbols.queen,      Symbols.symbol_1,   Symbols.ten,        Symbols.symbol_2,   Symbols.king,       Symbols.king,       Symbols.ten,        Symbols.ten,
        Symbols.ten,        Symbols.symbol_1,   Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.wild,       Symbols.scatter,    Symbols.ten,
        Symbols.ace,        Symbols.queen,      Symbols.jack,       Symbols.symbol_2,   Symbols.queen,      Symbols.jack,       Symbols.wild,       Symbols.queen,      Symbols.jack,       Symbols.king,
        Symbols.symbol_2,   Symbols.ten,        Symbols.jack,       Symbols.ten,        Symbols.queen,      Symbols.king,       Symbols.symbol_1,   Symbols.jack,       Symbols.ten,        Symbols.jack,
        Symbols.symbol_3,   Symbols.scatter,    Symbols.queen,      Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.jack,       Symbols.queen,      Symbols.jack,       Symbols.queen
        },

        // Reel 5
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.symbol_2,   Symbols.symbol_2,   Symbols.jack,       Symbols.symbol_2,   Symbols.symbol_3,   Symbols.king,       Symbols.ten,        Symbols.scatter,    Symbols.king,       Symbols.king,
        Symbols.jack,       Symbols.jack,       Symbols.symbol_1,   Symbols.ace,        Symbols.symbol_2,   Symbols.ace,        Symbols.wild,       Symbols.king,       Symbols.ten,        Symbols.queen,
        Symbols.symbol_2,   Symbols.ace,        Symbols.ace,        Symbols.ten,        Symbols.jack,       Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.ten,
        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.symbol_1,   Symbols.jack,       Symbols.ace,        Symbols.symbol_3,   Symbols.ace,        Symbols.queen,      Symbols.queen,
        Symbols.symbol_1,   Symbols.jack,       Symbols.ten,        Symbols.symbol_3,   Symbols.queen,      Symbols.symbol_1,   Symbols.king,       Symbols.king,       Symbols.king,       Symbols.symbol_2,
        Symbols.ten,        Symbols.queen,      Symbols.queen,      Symbols.queen,      Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.jack,
        Symbols.symbol_1,   Symbols.wild,       Symbols.ten,        Symbols.wild,       Symbols.symbol_1,   Symbols.symbol_3,   Symbols.symbol_1,   Symbols.ace,        Symbols.ace,        Symbols.king,
        Symbols.ace,        Symbols.king,       Symbols.wild,       Symbols.ace,        Symbols.queen,      Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.jack,       Symbols.jack,
        Symbols.symbol_1,   Symbols.symbol_2,   Symbols.king,       Symbols.ten,        Symbols.jack,       Symbols.symbol_2,   Symbols.ten,        Symbols.jack,       Symbols.scatter,    Symbols.ten,
        Symbols.queen,      Symbols.ace,        Symbols.queen,      Symbols.ten,        Symbols.symbol_3,   Symbols.ten,        Symbols.queen,      Symbols.ten,        Symbols.jack,       Symbols.queen
        }

    };
}

public class Reel
{
    private Symbols[] squares = new Symbols[Constants.NR_OF_SQUARES];

    private int index;

    
    public Reel(int _index) => index = _index;
    public Symbols[] Get() => squares;
    
    public void Stop()
    {
        int center = Random.Range(0, Constants.NR_OF_STOPS);

        int top = (center == 0) ? Constants.NR_OF_STOPS - 1 : center - 1;
        int bottom = (center == Constants.NR_OF_STOPS - 1) ? 0 : center + 1;

        Set(VirtualReels.reels[index][top], VirtualReels.reels[index][center], VirtualReels.reels[index][bottom]);
    }
    private void Set(Symbols top, Symbols center, Symbols bottom)
    {
        squares[0] = top;
        squares[1] = center;
        squares[2] = bottom;
    }
}
{
    public static int NR_OF_REELS => 5;    
    public static int NR_OF_SQUARES => 3;


    public static LinesAmount MIN_NR_OF_LINES => LinesAmount._5;
    public static LinesAmount MAX_NR_OF_LINES => LinesAmount._10;

    public static BetAmounts MIN_BET => BetAmounts._10;
    public static BetAmounts MAX_BET => BetAmounts._100;
        
};

public static class PayData
{
    public static Dictionary<List<Symbols>, int> payTable = new Dictionary<List<Symbols>, int>
        {
            { new List<Symbols>{ Symbols.ten, Symbols.ten, Symbols.ten                                      }, 10 },
            { new List<Symbols>{ Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten                         }, 20 },
            { new List<Symbols>{ Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten            }, 50 },

            { new List<Symbols>{ Symbols.jack, Symbols.jack, Symbols.jack                                   }, 10 },
            { new List<Symbols>{ Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack                     }, 20 },
            { new List<Symbols>{ Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack       }, 50 },

            { new List<Symbols>{ Symbols.queen, Symbols.queen, Symbols.queen                                }, 10 },
            { new List<Symbols>{ Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen                 }, 20 },
            { new List<Symbols>{ Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen  }, 50 },

            { new List<Symbols>{ Symbols.king, Symbols.king, Symbols.king                                   }, 10 },
            { new List<Symbols>{ Symbols.king, Symbols.king, Symbols.king, Symbols.king                     }, 20 },
            { new List<Symbols>{ Symbols.king, Symbols.king, Symbols.king, Symbols.king, Symbols.king       }, 50 },

            { new List<Symbols>{ Symbols.ace, Symbols.ace, Symbols.ace                                      }, 10 },
            { new List<Symbols>{ Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace                         }, 20 },
            { new List<Symbols>{ Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace            }, 50 },


            { new List<Symbols>{ Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1                                       }, 10 },
            { new List<Symbols>{ Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1                     }, 20 },
            { new List<Symbols>{ Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1   }, 50 },

            { new List<Symbols>{ Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2                                       }, 10 },
            { new List<Symbols>{ Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2                     }, 20 },
            { new List<Symbols>{ Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2   }, 50 },

            { new List<Symbols>{ Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3                                       }, 10 },
            { new List<Symbols>{ Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3                     }, 20 },
            { new List<Symbols>{ Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3   }, 50 },

    };

};
