using System;
using System.Collections.Generic;
using UnityEngine;
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
    _3  = 3,
    _5  = 5,
    _9  = 9
};



public class Constants
{
    public const int NR_OF_STOPS = 100;

    public const int NR_OF_REELS    = 5;    
    public const int NR_OF_SQUARES  = 3;


    public const LinesAmount MIN_NR_OF_LINES = LinesAmount._3;
    public const LinesAmount MAX_NR_OF_LINES = LinesAmount._9;

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
    public Symbols[] squares { get; private set; } = new Symbols[Constants.NR_OF_SQUARES];

    private int index;

    public Reel(int _index) => index = _index;

    public void Stop()
    {
        int center = Random.Range(0, Constants.NR_OF_STOPS);

        int top = (center == 0) ? Constants.NR_OF_STOPS - 1 : center - 1;
        int bottom = (center == Constants.NR_OF_STOPS - 1) ? 0 : center + 1;


        Debug.Log(VirtualReels.reels[index][top]);
        Debug.Log(VirtualReels.reels[index][center]);
        Debug.Log(VirtualReels.reels[index][bottom]);

        Set(VirtualReels.reels[index][top], VirtualReels.reels[index][center], VirtualReels.reels[index][bottom]);
    }
    private void Set(Symbols top, Symbols center, Symbols bottom)
    {
        squares[0] = top;
        squares[1] = center;
        squares[2] = bottom;
    }
}




public class PayLine
{
    private List<Symbols> symbols   = new List<Symbols>();
    private Symbols symbolType      = Symbols.wild;

    public int size => symbols.Count;

    public PayLine() { }
    public PayLine(List<Symbols> _symbols) => symbols = _symbols;


    
    public void Add(Symbols symbol)
    {
        if (symbol == Symbols.wild)
        {
            symbol = symbolType;
            symbols.Add(symbolType);
        }
        else if(symbol != Symbols.wild)
        {
            if (symbolType != Symbols.wild)
                symbols.Add(symbol);
            else
            {
                symbolType = symbol;

                for (int i = 0; i < symbols.Count; i++)
                    symbols[i] = symbol;

                symbols.Add(symbol);
            }

        }         


    }
    public void Remove() => symbols.RemoveAt(size - 1);


    public override bool Equals(object obj) => Equals(obj as PayLine);

    public bool Equals(PayLine other)
    {
        if (other == null || symbols.Count != other.symbols.Count)
            return false;

        for (int i = 0; i < symbols.Count; i++)
        {
            if (symbols[i] != other.symbols[i])
                return false;
        }

        return true;
    }
    public override int GetHashCode()
    {
        int hash = 17;
        foreach (var symbol in symbols)
        {
            hash = hash * 31 + symbol.GetHashCode();
        }
        return hash;
    }
}

public static class PayData
{
    public static Dictionary<PayLine, int> payTable = new Dictionary<PayLine, int>
        {
            { new PayLine(new List<Symbols> { Symbols.ten, Symbols.ten, Symbols.ten                                         }), 5  },
            { new PayLine(new List<Symbols> { Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten                            }), 10 },
            { new PayLine(new List<Symbols> { Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten               }), 25 },

            { new PayLine(new List<Symbols> { Symbols.jack, Symbols.jack, Symbols.jack                                      }), 8  },
            { new PayLine(new List<Symbols> { Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack                        }), 20 },
            { new PayLine(new List<Symbols> { Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack          }), 50 },

            { new PayLine(new List<Symbols> { Symbols.queen, Symbols.queen, Symbols.queen                                   }), 8  },
            { new PayLine(new List<Symbols> { Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen                    }), 20 },
            { new PayLine(new List<Symbols> { Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen     }), 50 },

            { new PayLine(new List<Symbols> { Symbols.king, Symbols.king, Symbols.king                                      }), 8  },
            { new PayLine(new List<Symbols> { Symbols.king, Symbols.king, Symbols.king, Symbols.king                        }), 20 },
            { new PayLine(new List<Symbols> { Symbols.king, Symbols.king, Symbols.king, Symbols.king, Symbols.king          }), 50 },

            { new PayLine(new List<Symbols> { Symbols.ace, Symbols.ace, Symbols.ace                                         }), 8  },
            { new PayLine(new List<Symbols> { Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace                            }), 20 },
            { new PayLine(new List<Symbols> { Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace               }), 50 },


            { new PayLine(new List<Symbols> { Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1                                          }), 15  },
            { new PayLine(new List<Symbols> { Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1                        }), 40  },
            { new PayLine(new List<Symbols> { Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1, Symbols.symbol_1      }), 100 },

            { new PayLine(new List<Symbols> { Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2                                          }), 15  },
            { new PayLine(new List<Symbols> { Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2                        }), 40  },
            { new PayLine(new List<Symbols> { Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2, Symbols.symbol_2      }), 100 },

            { new PayLine(new List<Symbols> { Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3                                          }), 25  },
            { new PayLine(new List<Symbols> { Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3                        }), 100 },
            { new PayLine(new List<Symbols> { Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3, Symbols.symbol_3      }), 250 },

            { new PayLine(new List<Symbols> { Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild }), 1000 },

            { new PayLine(new List<Symbols> { Symbols.scatter, Symbols.scatter, Symbols.scatter,                                            }), 1000 },
            { new PayLine(new List<Symbols> { Symbols.scatter, Symbols.scatter, Symbols.scatter, Symbols.scatter                            }), 1000 },
            { new PayLine(new List<Symbols> { Symbols.scatter, Symbols.scatter, Symbols.scatter, Symbols.scatter, Symbols.scatter           }), 1000 }
    };

};
