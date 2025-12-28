using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_UI_Reels : MonoBehaviour
{
    public static M_UI_Reels singleton;

    [SerializeField] private List<RectTransform> UI_paylines;

    [SerializeField] private List<RectTransform> UI_reels;

    [SerializeField] private List<Sprite> sprites;


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
        M_Controls.singleton.onSpin += () => Invoke(nameof(DisplayReels), Time.deltaTime);

    }

    #region Paylines
    public void ToggleDisplayPayline(int paylineIndex, bool isWinning)
    {
        UI_paylines[paylineIndex].gameObject.SetActive(isWinning);
    }

    #endregion


    #region Reels
    private void DisplayReels()
    {
        foreach (Reel reel in M_Reels.singleton.reels)
            DisplayReel(reel);
    }

    private void DisplayReel(Reel reel)
    {
        for (int squareIndex = 0; squareIndex < Constants.NR_OF_SQUARES; squareIndex++)
            DisplaySymbol(reel.index, squareIndex, sprites[(int)reel.squares[squareIndex]]);
    }


    public void DisplaySymbol(int reelIndex,int squareIndex, Sprite sprite)
    {
        Transform UI_symbol = UI_reels[reelIndex].GetChild(squareIndex).GetChild(1);
        UI_symbol.GetComponent<Image>().sprite = sprite;
    }

    public void TurnSymbolFrameOn(int reelIndex, int squareIndex)
    {
        Transform UI_frame = UI_reels[reelIndex].GetChild(squareIndex).GetChild(0);
        UI_frame.gameObject.SetActive(true);
    }
    public void TurnSymbolFrameOff(int reelIndex, int squareIndex)
    {
        Transform UI_frame = UI_reels[reelIndex].GetChild(squareIndex).GetChild(0);
        UI_frame.gameObject.SetActive(false);
    }


    #endregion

}