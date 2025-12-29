using System;
using System.Collections.Generic;
using System.Linq;
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
    wild,
    none

}

[Serializable]
public enum PayLineType
{
    BasicLine,
    ScatterLine
}


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
    public const int NR_OF_STOPS = 96;

    public const int NR_OF_REELS    = 5;    
    public const int NR_OF_SQUARES  = 3;

    public const AutoSpinAmounts MIN_NR_OF_AUTO_SPINS = AutoSpinAmounts._5; 
    public const AutoSpinAmounts MAX_NR_OF_AUTO_SPINS = AutoSpinAmounts._100; 

    public const LineAmounts MIN_NR_OF_LINES = LineAmounts._3;
    public const LineAmounts MAX_NR_OF_LINES = LineAmounts._20;

    public const BetAmounts MIN_BET = BetAmounts._10;
    public const BetAmounts MAX_BET = BetAmounts._100;


    public const float ANIM_TIME_SPIN           = 3;
    public const float ANIM_TIME_PER_PAYLINE    = 1;
    
    public const float TIME_AUTO_SPINS          = .5f;
};



// This Reel contains all elements and can't be moddified
public class VirtualReels
{
    public static List<Symbols[]> reels => new List<Symbols[]>()
    {
        // Reel 1
        new Symbols[Constants.NR_OF_STOPS]
        {
            Symbols.jack,
            Symbols.wild,
            Symbols.ten,
            Symbols.ace,
            Symbols.ten,
            Symbols.jack,
            Symbols.diamond,
            Symbols.coin,
            Symbols.ten,
            Symbols.queen,
            Symbols.wild,
            Symbols.jack,
            Symbols.jack,
            Symbols.coin,
            Symbols.ten,
            Symbols.jack,
            Symbols.nine,
            Symbols.king,
            Symbols.ace,
            Symbols.ace,
            Symbols.diamond,
            Symbols.king,
            Symbols.nine,
            Symbols.horseshoe,
            Symbols.king,
            Symbols.diamond,
            Symbols.horseshoe,
            Symbols.jack,
            Symbols.nine,
            Symbols.queen,
            Symbols.queen,
            Symbols.seven,
            Symbols.ten,
            Symbols.queen,
            Symbols.crown,
            Symbols.scatter,
            Symbols.nine,
            Symbols.ace,
            Symbols.ace,
            Symbols.ace,
            Symbols.nine,
            Symbols.scatter,
            Symbols.nine,
            Symbols.queen,
            Symbols.coin,
            Symbols.scatter,
            Symbols.nine,
            Symbols.jack,
            Symbols.nine,
            Symbols.nine,
            Symbols.crown,
            Symbols.ten,
            Symbols.ten,
            Symbols.coin,
            Symbols.queen,
            Symbols.wild,
            Symbols.nine,
            Symbols.ten,
            Symbols.king,
            Symbols.nine,
            Symbols.nine,
            Symbols.king,
            Symbols.scatter,
            Symbols.queen,
            Symbols.horseshoe,
            Symbols.ten,
            Symbols.nine,
            Symbols.ten,
            Symbols.coin,
            Symbols.king,
            Symbols.seven,
            Symbols.crown,
            Symbols.ace,
            Symbols.nine,
            Symbols.queen,
            Symbols.queen,
            Symbols.horseshoe,
            Symbols.king,
            Symbols.ten,
            Symbols.king,
            Symbols.queen,
            Symbols.king,
            Symbols.jack,
            Symbols.ten,
            Symbols.ten,
            Symbols.horseshoe,
            Symbols.ace,
            Symbols.coin,
            Symbols.scatter,
            Symbols.king,
            Symbols.ten,
            Symbols.jack,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.ace,
            Symbols.jack
        },

        // Reel2
        new Symbols[Constants.NR_OF_STOPS]
        {
            Symbols.ten,
            Symbols.ace,
            Symbols.ace,
            Symbols.king,
            Symbols.jack,
            Symbols.jack,
            Symbols.jack,
            Symbols.nine,
            Symbols.wild,
            Symbols.diamond,
            Symbols.ace,
            Symbols.ace,
            Symbols.nine,
            Symbols.queen,
            Symbols.diamond,
            Symbols.crown,
            Symbols.scatter,
            Symbols.ten,
            Symbols.nine,
            Symbols.wild,
            Symbols.coin,
            Symbols.crown,
            Symbols.scatter,
            Symbols.seven,
            Symbols.diamond,
            Symbols.ten,
            Symbols.nine,
            Symbols.nine,
            Symbols.king,
            Symbols.seven,
            Symbols.nine,
            Symbols.ten,
            Symbols.scatter,
            Symbols.king,
            Symbols.jack,
            Symbols.ten,
            Symbols.ten,
            Symbols.ten,
            Symbols.coin,
            Symbols.nine,
            Symbols.horseshoe,
            Symbols.ace,
            Symbols.ace,
            Symbols.nine,
            Symbols.ten,
            Symbols.ten,
            Symbols.king,
            Symbols.queen,
            Symbols.horseshoe,
            Symbols.king,
            Symbols.king,
            Symbols.scatter,
            Symbols.coin,
            Symbols.ace,
            Symbols.jack,
            Symbols.horseshoe,
            Symbols.queen,
            Symbols.ace,
            Symbols.king,
            Symbols.nine,
            Symbols.nine,
            Symbols.horseshoe,
            Symbols.jack,
            Symbols.jack,
            Symbols.nine,
            Symbols.ten,
            Symbols.ten,
            Symbols.king,
            Symbols.nine,
            Symbols.ten,
            Symbols.nine,
            Symbols.coin,
            Symbols.coin,
            Symbols.queen,
            Symbols.crown,
            Symbols.queen,
            Symbols.ten,
            Symbols.queen,
            Symbols.scatter,
            Symbols.queen,
            Symbols.jack,
            Symbols.nine,
            Symbols.queen,
            Symbols.ace,
            Symbols.ten,
            Symbols.horseshoe,
            Symbols.king,
            Symbols.king,
            Symbols.jack,
            Symbols.coin,
            Symbols.queen,
            Symbols.wild,
            Symbols.queen,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.jack
        },

        // Reel 3
        new Symbols[Constants.NR_OF_STOPS]
        {
            Symbols.nine,
            Symbols.jack,
            Symbols.ten,
            Symbols.ace,
            Symbols.coin,
            Symbols.ten,
            Symbols.ten,
            Symbols.seven,
            Symbols.scatter,
            Symbols.ace,
            Symbols.coin,
            Symbols.coin,
            Symbols.nine,
            Symbols.wild,
            Symbols.ten,
            Symbols.seven,
            Symbols.king,
            Symbols.jack,
            Symbols.scatter,
            Symbols.king,
            Symbols.nine,
            Symbols.jack,
            Symbols.nine,
            Symbols.diamond,
            Symbols.coin,
            Symbols.jack,
            Symbols.jack,
            Symbols.ace,
            Symbols.crown,
            Symbols.nine,
            Symbols.crown,
            Symbols.ace,
            Symbols.ten,
            Symbols.jack,
            Symbols.ten,
            Symbols.wild,
            Symbols.king,
            Symbols.ten,
            Symbols.nine,
            Symbols.king,
            Symbols.nine,
            Symbols.scatter,
            Symbols.nine,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.queen,
            Symbols.king,
            Symbols.horseshoe,
            Symbols.crown,
            Symbols.nine,
            Symbols.queen,
            Symbols.king,
            Symbols.ten,
            Symbols.ten,
            Symbols.queen,
            Symbols.queen,
            Symbols.coin,
            Symbols.ten,
            Symbols.nine,
            Symbols.horseshoe,
            Symbols.scatter,
            Symbols.ace,
            Symbols.diamond,
            Symbols.queen,
            Symbols.king,
            Symbols.nine,
            Symbols.jack,
            Symbols.nine,
            Symbols.queen,
            Symbols.ace,
            Symbols.jack,
            Symbols.nine,
            Symbols.king,
            Symbols.queen,
            Symbols.queen,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.scatter,
            Symbols.ace,
            Symbols.diamond,
            Symbols.ten,
            Symbols.ten,
            Symbols.ten,
            Symbols.king,
            Symbols.ten,
            Symbols.jack,
            Symbols.wild,
            Symbols.king,
            Symbols.queen,
            Symbols.horseshoe,
            Symbols.ace,
            Symbols.queen,
            Symbols.jack,
            Symbols.horseshoe,
            Symbols.coin,
            Symbols.nine
        },

        // Reel 4
        new Symbols[Constants.NR_OF_STOPS]
        {
            Symbols.nine,
            Symbols.crown,
            Symbols.jack,
            Symbols.seven,
            Symbols.coin,
            Symbols.ten,
            Symbols.ace,
            Symbols.ten,
            Symbols.jack,
            Symbols.horseshoe,
            Symbols.queen,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.king,
            Symbols.nine,
            Symbols.ten,
            Symbols.coin,
            Symbols.wild,
            Symbols.jack,
            Symbols.nine,
            Symbols.scatter,
            Symbols.jack,
            Symbols.ace,
            Symbols.ten,
            Symbols.nine,
            Symbols.coin,
            Symbols.diamond,
            Symbols.seven,
            Symbols.jack,
            Symbols.queen,
            Symbols.diamond,
            Symbols.ten,
            Symbols.horseshoe,
            Symbols.coin,
            Symbols.jack,
            Symbols.ten,
            Symbols.horseshoe,
            Symbols.ten,
            Symbols.nine,
            Symbols.diamond,
            Symbols.nine,
            Symbols.scatter,
            Symbols.ace,
            Symbols.jack,
            Symbols.queen,
            Symbols.nine,
            Symbols.nine,
            Symbols.ten,
            Symbols.queen,
            Symbols.ten,
            Symbols.ten,
            Symbols.ace,
            Symbols.king,
            Symbols.ten,
            Symbols.scatter,
            Symbols.king,
            Symbols.crown,
            Symbols.wild,
            Symbols.king,
            Symbols.nine,
            Symbols.king,
            Symbols.coin,
            Symbols.nine,
            Symbols.ace,
            Symbols.ten,
            Symbols.horseshoe,
            Symbols.queen,
            Symbols.king,
            Symbols.queen,
            Symbols.queen,
            Symbols.ace,
            Symbols.coin,
            Symbols.king,
            Symbols.king,
            Symbols.queen,
            Symbols.ten,
            Symbols.king,
            Symbols.jack,
            Symbols.wild,
            Symbols.scatter,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.nine,
            Symbols.queen,
            Symbols.nine,
            Symbols.king,
            Symbols.ace,
            Symbols.nine,
            Symbols.ten,
            Symbols.jack,
            Symbols.jack,
            Symbols.queen,
            Symbols.nine,
            Symbols.ace,
            Symbols.scatter,
            Symbols.crown
        },

        // Reel 5
        new Symbols[Constants.NR_OF_STOPS]
        {
            Symbols.ten,
            Symbols.queen,
            Symbols.scatter,
            Symbols.nine,
            Symbols.wild,
            Symbols.diamond,
            Symbols.ten,
            Symbols.nine,
            Symbols.coin,
            Symbols.queen,
            Symbols.horseshoe,
            Symbols.nine,
            Symbols.king,
            Symbols.ten,
            Symbols.ten,
            Symbols.queen,
            Symbols.ten,
            Symbols.ten,
            Symbols.coin,
            Symbols.diamond,
            Symbols.king,
            Symbols.seven,
            Symbols.ace,
            Symbols.nine,
            Symbols.jack,
            Symbols.coin,
            Symbols.ten,
            Symbols.scatter,
            Symbols.ace,
            Symbols.nine,
            Symbols.ten,
            Symbols.king,
            Symbols.horseshoe,
            Symbols.king,
            Symbols.queen,
            Symbols.nine,
            Symbols.nine,
            Symbols.coin,
            Symbols.king,
            Symbols.crown,
            Symbols.jack,
            Symbols.jack,
            Symbols.scatter,
            Symbols.nine,
            Symbols.ten,
            Symbols.ace,
            Symbols.jack,
            Symbols.nine,
            Symbols.ace,
            Symbols.ten,
            Symbols.queen,
            Symbols.ten,
            Symbols.ace,
            Symbols.king,
            Symbols.nine,
            Symbols.horseshoe,
            Symbols.nine,
            Symbols.king,
            Symbols.scatter,
            Symbols.horseshoe,
            Symbols.nine,
            Symbols.queen,
            Symbols.wild,
            Symbols.ace,
            Symbols.nine,
            Symbols.queen,
            Symbols.ace,
            Symbols.ten,
            Symbols.ace,
            Symbols.horseshoe,
            Symbols.diamond,
            Symbols.crown,
            Symbols.nine,
            Symbols.jack,
            Symbols.queen,
            Symbols.ten,
            Symbols.jack,
            Symbols.jack,
            Symbols.ace,
            Symbols.jack,
            Symbols.coin,
            Symbols.crown,
            Symbols.jack,
            Symbols.jack,
            Symbols.wild,
            Symbols.coin,
            Symbols.king,
            Symbols.horseshoe,
            Symbols.ace,
            Symbols.king,
            Symbols.scatter,
            Symbols.queen,
            Symbols.queen,
            Symbols.ten,
            Symbols.king,
            Symbols.seven
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




public class PayLine : IEquatable<PayLine>
{
    public int index { get; private set; }

    public PayLineType type { get; private set; }


    private Symbols symbolType = Symbols.none;

    public List<Symbols> symbols { get; private set; } = new List<Symbols>();
    public List<(int, int)> squares { get; private set; } = new List<(int, int)>(); // item1 = reelIndex, item2 = squareIndex



    public PayLine(int paylineIndex)
    {
        index = paylineIndex;

        if (index == (int)Constants.MAX_NR_OF_LINES)
            type = PayLineType.ScatterLine;

    } // Used for creating the actual paylines

    public PayLine(List<Symbols> _symbols) => symbols = _symbols; // Used for creating the pay table


    public int payout {  get; private set; }

    public void AddSquare(int reelIndex, int squareIndex) => squares.Add((reelIndex, squareIndex));
    private void ClearSquares() => squares.Clear();


    public void Update()
    {
        if(type == PayLineType.BasicLine)
        {
            ClearSymbols();

            foreach ((int, int) square in squares)
            {
                Symbols symbol = M_Reels.singleton.reels[square.Item1].squares[square.Item2];
                AddSymbol(symbol); // Add new symbol to payline

            }
        }
        else if(type == PayLineType.ScatterLine)
        {
            ClearSquares();
            ClearSymbols();

            for (int reelIndex = 0; reelIndex < Constants.NR_OF_REELS; reelIndex++)
                for (int squareIndex = 0; squareIndex < Constants.NR_OF_SQUARES; squareIndex++)
                {
                    Symbols symbol = M_Reels.singleton.reels[reelIndex].squares[squareIndex];

                    if (symbol == Symbols.scatter)
                    {
                        AddSquare(reelIndex, squareIndex);
                        symbols.Add(symbol);
                    }
                }
        }

        payout = CalculatePayout();
    }
    private void AddSymbol(Symbols symbol)
    {

        if (type == PayLineType.BasicLine)
        {
            if (symbol == Symbols.wild)
            {
                if(symbols.Count == 0)
                    symbolType = Symbols.wild;
    
                symbols.Add(symbolType);

            }
            else if (symbol == Symbols.scatter)
            {
                if (symbols.Count == 0)
                    symbolType = Symbols.none;


                if (symbolType == Symbols.wild)
                    symbolType = Symbols.none;

                symbols.Add(Symbols.none);
            }
            else
            {
                if (symbols.Count == 0)
                    symbolType = symbol;


                if (symbolType == Symbols.wild)
                {
                    symbolType = symbol;

                    for (int i = 0; i < symbols.Count; i++)
                        symbols[i] = symbolType;
                } // Modify existing wilds to the symbol



                symbols.Add(symbol);
            }
        }

    }


    private void ClearSymbols() => symbols.Clear();
    private void RemoveSymbol() => symbols.RemoveAt(symbols.Count - 1);
    private int CalculatePayout()
    {
        while (symbols.Count >= 2)
        {

            if (PayData.payTable.ContainsKey(this))
                return PayData.payTable[this] * (int)M_Controls.singleton.bet;
            
            RemoveSymbol();
        }

        return 0;
    }


    public override bool Equals(object obj)
        => obj is PayLine other && Equals(other);

    public bool Equals(PayLine other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return symbols.SequenceEqual(other.symbols);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var symbol in symbols)
                hash = hash * 31 + (int)symbol;
            return hash;
        }
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
    

            { new PayLine(new List<Symbols> { Symbols.wild, Symbols.wild                                                                    }), 15  },
            { new PayLine(new List<Symbols> { Symbols.wild, Symbols.wild, Symbols.wild                                                      }), 200 },
            { new PayLine(new List<Symbols> { Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild                                        }), 1000 },
            { new PayLine(new List<Symbols> { Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild, Symbols.wild                          }), 5000 }
    };

};
