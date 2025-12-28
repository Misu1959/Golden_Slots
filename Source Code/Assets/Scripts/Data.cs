using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public enum Symbols
{
    nine,
    ten,
    jack,
    queen,
    king,
    ace,
    horseshoe,
    coin,
    diamond,
    crown,
    seven,

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
public enum AutoSpinAmounts
{
    _5      = 5,
    _10     = 10,
    _20     = 20,
    _50     = 50,
    _100    = 100
}

[Serializable]
public enum LineAmounts
{
    _3 = 3,
    _5 = 5,
    _7 = 7,
    _9 = 9,
    _11 = 11,
    _13 = 13,
    _15 = 15,
    _17 = 17,
    _20 = 20,

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





public class Constants
{
    public const int NR_OF_STOPS = 100;

    public const int NR_OF_REELS    = 5;    
    public const int NR_OF_SQUARES  = 3;

    public const AutoSpinAmounts MIN_NR_OF_AUTO_SPINS = AutoSpinAmounts._5; 
    public const AutoSpinAmounts MAX_NR_OF_AUTO_SPINS = AutoSpinAmounts._100; 

    public const LineAmounts MIN_NR_OF_LINES = LineAmounts._3;
    public const LineAmounts MAX_NR_OF_LINES = LineAmounts._20;

    public const BetAmounts MIN_BET = BetAmounts._10;
    public const BetAmounts MAX_BET = BetAmounts._100;
        
};



// This Reel contains all elements and can't be moddified
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
        Symbols.ten,        Symbols.king,       Symbols.queen,      Symbols.horseshoe,   Symbols.jack,       Symbols.ten,        Symbols.queen,      Symbols.scatter,    Symbols.queen,      Symbols.ten,
        Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.king,       Symbols.king,       Symbols.jack,       Symbols.coin,   Symbols.jack,       Symbols.queen,      Symbols.scatter,
        Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.diamond,   Symbols.ten,        Symbols.king,       Symbols.coin,   Symbols.horseshoe,   Symbols.diamond,   Symbols.ten,
        Symbols.ten,        Symbols.ace,        Symbols.ace,        Symbols.coin,   Symbols.king,       Symbols.ten,        Symbols.diamond,   Symbols.horseshoe,   Symbols.ten,        Symbols.queen,
        Symbols.horseshoe,   Symbols.coin,   Symbols.ten,        Symbols.queen,      Symbols.ace,        Symbols.queen,      Symbols.jack,       Symbols.ten,        Symbols.ten,        Symbols.ten,
        Symbols.jack,       Symbols.jack,       Symbols.ten,        Symbols.jack,       Symbols.queen,      Symbols.ten,        Symbols.jack,       Symbols.coin,   Symbols.ten,        Symbols.jack,
        Symbols.coin,   Symbols.ace,        Symbols.king,       Symbols.king,       Symbols.ace,        Symbols.wild,       Symbols.king,       Symbols.horseshoe,   Symbols.ten,        Symbols.ace,
        Symbols.ten,        Symbols.jack,       Symbols.ace,        Symbols.horseshoe,   Symbols.king,       Symbols.ace,        Symbols.wild,       Symbols.wild,       Symbols.ten,        Symbols.diamond,
        Symbols.coin,   Symbols.queen,      Symbols.coin,   Symbols.wild,       Symbols.jack,       Symbols.queen,      Symbols.queen,      Symbols.ten,        Symbols.horseshoe,   Symbols.horseshoe,
        Symbols.ace,        Symbols.ace,        Symbols.ace,        Symbols.king,       Symbols.king,       Symbols.jack,       Symbols.ten,        Symbols.ten,        Symbols.queen,      Symbols.diamond
        },

        // Reel2
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.ten,        Symbols.king,       Symbols.king,       Symbols.horseshoe,   Symbols.diamond,   Symbols.jack,       Symbols.wild,       Symbols.jack,       Symbols.queen,      Symbols.coin,
        Symbols.ace,        Symbols.queen,      Symbols.queen,      Symbols.ten,        Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.wild,       Symbols.ace,
        Symbols.jack,       Symbols.ten,        Symbols.diamond,   Symbols.queen,      Symbols.horseshoe,   Symbols.jack,       Symbols.horseshoe,   Symbols.ten,        Symbols.jack,       Symbols.ten,
        Symbols.wild,       Symbols.king,       Symbols.king,       Symbols.queen,      Symbols.queen,      Symbols.ace,        Symbols.horseshoe,   Symbols.coin,   Symbols.ten,        Symbols.horseshoe,
        Symbols.ten,        Symbols.king,       Symbols.coin,   Symbols.queen,      Symbols.ten,        Symbols.ten,        Symbols.coin,   Symbols.king,       Symbols.jack,       Symbols.ace,
        Symbols.scatter,    Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.ace,        Symbols.king,       Symbols.coin,   Symbols.ace,        Symbols.ace,
        Symbols.ten,        Symbols.queen,      Symbols.coin,   Symbols.ten,        Symbols.queen,      Symbols.jack,       Symbols.ace,        Symbols.jack,       Symbols.diamond,   Symbols.queen,
        Symbols.ten,        Symbols.coin,   Symbols.ten,        Symbols.wild,       Symbols.king,       Symbols.ten,        Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ten,
        Symbols.scatter,    Symbols.horseshoe,   Symbols.queen,      Symbols.diamond,   Symbols.jack,       Symbols.ten,        Symbols.coin,   Symbols.jack,       Symbols.horseshoe,   Symbols.horseshoe,
        Symbols.queen,      Symbols.ten,        Symbols.ace,        Symbols.jack,       Symbols.ace,        Symbols.king,       Symbols.ten,        Symbols.jack,       Symbols.ten,        Symbols.diamond
        },

        // Reel 3
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.ten,        Symbols.queen,      Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.coin,   Symbols.ten,        Symbols.scatter,
        Symbols.horseshoe,   Symbols.ten,        Symbols.jack,       Symbols.ace,        Symbols.jack,       Symbols.coin,   Symbols.jack,       Symbols.ten,        Symbols.horseshoe,   Symbols.jack,
        Symbols.queen,      Symbols.ten,        Symbols.coin,   Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.jack,       Symbols.ace,        Symbols.ten,
        Symbols.ace,        Symbols.queen,      Symbols.wild,       Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.queen,      Symbols.jack,       Symbols.diamond,
        Symbols.coin,   Symbols.wild,       Symbols.ten,        Symbols.ten,        Symbols.scatter,    Symbols.queen,      Symbols.coin,   Symbols.queen,      Symbols.jack,       Symbols.ten,
        Symbols.coin,   Symbols.diamond,   Symbols.king,       Symbols.horseshoe,   Symbols.queen,      Symbols.jack,       Symbols.ten,        Symbols.king,       Symbols.ace,        Symbols.queen,
        Symbols.ten,        Symbols.ten,        Symbols.horseshoe,   Symbols.horseshoe,   Symbols.diamond,   Symbols.horseshoe,   Symbols.diamond,   Symbols.wild,       Symbols.jack,       Symbols.ace,
        Symbols.ten,        Symbols.jack,       Symbols.queen,      Symbols.diamond,   Symbols.king,       Symbols.horseshoe,   Symbols.ten,        Symbols.king,       Symbols.ace,        Symbols.king,
        Symbols.king,       Symbols.coin,   Symbols.king,       Symbols.wild,       Symbols.jack,       Symbols.king,       Symbols.coin,   Symbols.queen,      Symbols.ten,        Symbols.queen,
        Symbols.jack,       Symbols.ace,        Symbols.ace,        Symbols.ace,        Symbols.horseshoe,   Symbols.ten,        Symbols.king,       Symbols.king,       Symbols.king,       Symbols.queen
        },

        // Reel 4
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.ace,        Symbols.king,       Symbols.ace,        Symbols.ten,        Symbols.ace,        Symbols.queen,      Symbols.coin,   Symbols.ten,        Symbols.diamond,   Symbols.ten,
        Symbols.diamond,   Symbols.king,       Symbols.ace,        Symbols.ten,        Symbols.queen,      Symbols.king,       Symbols.ace,        Symbols.ten,        Symbols.jack,       Symbols.jack,
        Symbols.king,       Symbols.king,       Symbols.diamond,   Symbols.ten,        Symbols.ace,        Symbols.queen,      Symbols.ace,        Symbols.diamond,   Symbols.wild,       Symbols.ten,
        Symbols.king,       Symbols.king,       Symbols.horseshoe,   Symbols.horseshoe,   Symbols.ten,        Symbols.ten,        Symbols.horseshoe,   Symbols.coin,   Symbols.horseshoe,   Symbols.coin,
        Symbols.wild,       Symbols.coin,   Symbols.coin,   Symbols.horseshoe,   Symbols.ace,        Symbols.ace,        Symbols.king,       Symbols.ten,        Symbols.queen,      Symbols.ten,
        Symbols.jack,       Symbols.jack,       Symbols.queen,      Symbols.horseshoe,   Symbols.ten,        Symbols.coin,   Symbols.king,       Symbols.king,       Symbols.ten,        Symbols.ten,
        Symbols.ten,        Symbols.horseshoe,   Symbols.ace,        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.wild,       Symbols.scatter,    Symbols.ten,
        Symbols.ace,        Symbols.queen,      Symbols.jack,       Symbols.coin,   Symbols.queen,      Symbols.jack,       Symbols.wild,       Symbols.queen,      Symbols.jack,       Symbols.king,
        Symbols.coin,   Symbols.ten,        Symbols.jack,       Symbols.ten,        Symbols.queen,      Symbols.king,       Symbols.horseshoe,   Symbols.jack,       Symbols.ten,        Symbols.jack,
        Symbols.diamond,   Symbols.scatter,    Symbols.queen,      Symbols.ten,        Symbols.ace,        Symbols.ten,        Symbols.jack,       Symbols.queen,      Symbols.jack,       Symbols.queen
        },

        // Reel 5
        new Symbols[Constants.NR_OF_STOPS]
        {
        Symbols.coin,   Symbols.coin,   Symbols.jack,       Symbols.coin,   Symbols.diamond,   Symbols.king,       Symbols.ten,        Symbols.scatter,    Symbols.king,       Symbols.king,
        Symbols.jack,       Symbols.jack,       Symbols.horseshoe,   Symbols.ace,        Symbols.coin,   Symbols.ace,        Symbols.wild,       Symbols.king,       Symbols.ten,        Symbols.queen,
        Symbols.coin,   Symbols.ace,        Symbols.ace,        Symbols.ten,        Symbols.jack,       Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ace,        Symbols.ten,
        Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.horseshoe,   Symbols.jack,       Symbols.ace,        Symbols.diamond,   Symbols.ace,        Symbols.queen,      Symbols.queen,
        Symbols.horseshoe,   Symbols.jack,       Symbols.ten,        Symbols.diamond,   Symbols.queen,      Symbols.horseshoe,   Symbols.king,       Symbols.king,       Symbols.king,       Symbols.coin,
        Symbols.ten,        Symbols.queen,      Symbols.queen,      Symbols.queen,      Symbols.ten,        Symbols.king,       Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.jack,
        Symbols.horseshoe,   Symbols.wild,       Symbols.ten,        Symbols.wild,       Symbols.horseshoe,   Symbols.diamond,   Symbols.horseshoe,   Symbols.ace,        Symbols.ace,        Symbols.king,
        Symbols.ace,        Symbols.king,       Symbols.wild,       Symbols.ace,        Symbols.queen,      Symbols.ten,        Symbols.ten,        Symbols.ten,        Symbols.jack,       Symbols.jack,
        Symbols.horseshoe,   Symbols.coin,   Symbols.king,       Symbols.ten,        Symbols.jack,       Symbols.coin,   Symbols.ten,        Symbols.jack,       Symbols.scatter,    Symbols.ten,
        Symbols.queen,      Symbols.ace,        Symbols.queen,      Symbols.ten,        Symbols.diamond,   Symbols.ten,        Symbols.queen,      Symbols.ten,        Symbols.jack,       Symbols.queen
        }

    };
}


// This reels only contains the elements selected for each spin and will modify at every spin
public class Reel
{
    public Symbols[] squares { get; private set; } = new Symbols[Constants.NR_OF_SQUARES];

    public int index {  get; private set; }

    public Reel(int _index) => index = _index;

    public void Spin()
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




public class PayLine
{
    private List<Symbols> symbols   = new List<Symbols>();
    private Symbols symbolType      = Symbols.wild;

    public int size => symbols.Count;

    public PayLine() { } // Used for creating the actual paylines
    public PayLine(List<Symbols> _symbols) => symbols = _symbols; // Used for creating the pay table


    
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
            { new PayLine(new List<Symbols> { Symbols.nine, Symbols.nine, Symbols.nine                                      }), 5  },
            { new PayLine(new List<Symbols> { Symbols.nine, Symbols.nine, Symbols.nine, Symbols.nine                        }), 20 },
            { new PayLine(new List<Symbols> { Symbols.nine, Symbols.nine, Symbols.nine, Symbols.nine, Symbols.nine          }), 100 },
            
            { new PayLine(new List<Symbols> { Symbols.ten, Symbols.ten, Symbols.ten                                         }), 5   },
            { new PayLine(new List<Symbols> { Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten                            }), 20  },
            { new PayLine(new List<Symbols> { Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten, Symbols.ten               }), 100 },


            { new PayLine(new List<Symbols> { Symbols.jack, Symbols.jack, Symbols.jack                                      }), 7   },
            { new PayLine(new List<Symbols> { Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack                        }), 25  },
            { new PayLine(new List<Symbols> { Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack, Symbols.jack          }), 510 },

            { new PayLine(new List<Symbols> { Symbols.queen, Symbols.queen, Symbols.queen                                   }), 7   },
            { new PayLine(new List<Symbols> { Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen                    }), 25  },
            { new PayLine(new List<Symbols> { Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen, Symbols.queen     }), 150 },


            { new PayLine(new List<Symbols> { Symbols.king, Symbols.king, Symbols.king                                      }), 10  },
            { new PayLine(new List<Symbols> { Symbols.king, Symbols.king, Symbols.king, Symbols.king                        }), 30  },
            { new PayLine(new List<Symbols> { Symbols.king, Symbols.king, Symbols.king, Symbols.king, Symbols.king          }), 200 },

            { new PayLine(new List<Symbols> { Symbols.ace, Symbols.ace, Symbols.ace                                         }), 10  },
            { new PayLine(new List<Symbols> { Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace                            }), 30  },
            { new PayLine(new List<Symbols> { Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace, Symbols.ace               }), 200 },


            { new PayLine(new List<Symbols> { Symbols.horseshoe, Symbols.horseshoe, Symbols.horseshoe                                       }), 15  },
            { new PayLine(new List<Symbols> { Symbols.horseshoe, Symbols.horseshoe, Symbols.horseshoe, Symbols.horseshoe                    }), 75  },
            { new PayLine(new List<Symbols> { Symbols.horseshoe, Symbols.horseshoe, Symbols.horseshoe, Symbols.horseshoe, Symbols.horseshoe }), 500 },

            { new PayLine(new List<Symbols> { Symbols.coin, Symbols.coin, Symbols.coin                                                      }), 15  },
            { new PayLine(new List<Symbols> { Symbols.coin, Symbols.coin, Symbols.coin, Symbols.coin                                        }), 75  },
            { new PayLine(new List<Symbols> { Symbols.coin, Symbols.coin, Symbols.coin, Symbols.coin, Symbols.coin                          }), 500 },


            { new PayLine(new List<Symbols> { Symbols.diamond, Symbols.diamond                                                              }), 5   },
            { new PayLine(new List<Symbols> { Symbols.diamond, Symbols.diamond, Symbols.diamond                                             }), 50  },
            { new PayLine(new List<Symbols> { Symbols.diamond, Symbols.diamond, Symbols.diamond, Symbols.diamond                            }), 100 },
            { new PayLine(new List<Symbols> { Symbols.diamond, Symbols.diamond, Symbols.diamond, Symbols.diamond, Symbols.diamond           }), 10000},


            { new PayLine(new List<Symbols> { Symbols.crown, Symbols.crown                                                                  }), 5   },
            { new PayLine(new List<Symbols> { Symbols.crown, Symbols.crown, Symbols.crown                                                   }), 100 },
            { new PayLine(new List<Symbols> { Symbols.crown, Symbols.crown, Symbols.crown, Symbols.crown                                    }), 250 },
            { new PayLine(new List<Symbols> { Symbols.crown, Symbols.crown, Symbols.crown, Symbols.crown, Symbols.crown                     }), 2500},

            
            { new PayLine(new List<Symbols> { Symbols.seven, Symbols.seven,                                                                 }), 10  },
            { new PayLine(new List<Symbols> { Symbols.seven, Symbols.seven, Symbols.seven,                                                  }), 150 },
            { new PayLine(new List<Symbols> { Symbols.seven, Symbols.seven, Symbols.seven, Symbols.seven                                    }), 500 },
            { new PayLine(new List<Symbols> { Symbols.seven, Symbols.seven, Symbols.seven, Symbols.seven, Symbols.seven                     }), 5000},



            { new PayLine(new List<Symbols> { Symbols.scatter, Symbols.scatter, Symbols.scatter,                                            }), 3   },
            { new PayLine(new List<Symbols> { Symbols.scatter, Symbols.scatter, Symbols.scatter, Symbols.scatter                            }), 10  },
            { new PayLine(new List<Symbols> { Symbols.scatter, Symbols.scatter, Symbols.scatter, Symbols.scatter, Symbols.scatter           }), 100 },
    

            { new PayLine(new List<Symbols> { Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild }), 1000 },
    };

};
