using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Constants;

public class M_UI_Reels : MonoBehaviour
{
    public static M_UI_Reels singleton;

    [Header("Assets")]
    [SerializeField] private List<Sprite> paylineNumbersOn;
    [SerializeField] private List<Sprite> paylineNumbersOff;

    [SerializeField] private List<Sprite> symbolBorders;




    [Header("In scene Objects")]

    [SerializeField] private List<RectTransform> UI_paylinesNumbers;

    [SerializeField] private List<RectTransform> UI_paylines;

    [SerializeField] private List<RectTransform> UI_reels;


    private float animTime_Spin;
    private float animTime_PayLine;

    private bool skipSpinAnimation;
    private bool skipPayoutAnimation;



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
        M_Controls.singleton.onLinesChange += DisplayActivePaylinesNumbers;
        M_Controls.singleton.onSpin += () => StartCoroutine(AnimateScreen());
    }

    public void SkipAnimations()
    {
        if (skipSpinAnimation)
            skipPayoutAnimation = true;
        
        skipSpinAnimation = true;

        foreach (RectTransform uiReel in UI_reels)
            uiReel.GetComponent<UI_Reel>().ForceStop();
    }


    public void DisplayActivePaylinesNumbers()
    {
        foreach(RectTransform paylineNumber in UI_paylinesNumbers)
        {
            int number = int.Parse(paylineNumber.name);
            Sprite sprite;
            
            if (number <= (int)M_Controls.singleton.lines)
                sprite = paylineNumbersOn[number - 1];
            else
                sprite = paylineNumbersOff[number - 1];

            paylineNumber.GetComponent<Image>().sprite = sprite;
        }
    }

    private IEnumerator AnimateScreen()
    {
        M_UI_Controls.singleton.ToggleSkipAnimationsButton(true);
        M_UI_Controls.singleton.OverrideControls(true);

        DisplayReels();

        foreach (RectTransform uiReel in UI_reels)
            uiReel.GetComponent<UI_Reel>().StartSpin();

        animTime_Spin = 0;
        while (animTime_Spin < ANIM_TIME_SPIN)
        {
            if (skipSpinAnimation)
                break;
            
            animTime_Spin += Time.deltaTime;
            yield return null;
        }



        for (int i = 0; i <= (int)MAX_NR_OF_LINES; i++)
        {
            PayLine payLine = M_Payment.singleton.payLines[i];

            if (i > (int)M_Controls.singleton.lines && payLine.type == PayLineType.BasicLine)
            {
                TurnOffPayline(payLine);
                continue;
            }

            if(payLine.payout == 0)
            {
                TurnOffPayline(payLine);
                continue;
            }

            M_Credits.singleton.AddPayout(payLine.payout);
            
            TurnOnPayline(payLine);

            animTime_PayLine = 0;
            while (animTime_PayLine < ANIM_TIME_PER_PAYLINE)
            {
                if (skipPayoutAnimation)
                    break;

                animTime_PayLine += Time.deltaTime;
                yield return null;
            }
                
            TurnOffPayline(payLine);
        }

        skipSpinAnimation = false;
        skipPayoutAnimation = false;

        M_UI_Controls.singleton.ToggleSkipAnimationsButton(false);
        M_UI_Controls.singleton.OverrideControls(false);
    }

    private void TurnOffPayline(PayLine payline)
    {
        if (payline.type == PayLineType.BasicLine) // To avoid Scatter payline
            UI_paylines[payline.index].gameObject.SetActive(false);
    
        for(int i = 0; i < payline.squares.Count; i++)
        {
            int reelIndex   = payline.squares[i].Item1;
            int squareIndex = payline.squares[i].Item2;

            StartCoroutine(TurnSymbolFrameOff(reelIndex, squareIndex));
        }
    }

    private void TurnOnPayline(PayLine payline)
    {
        if (payline.type == PayLineType.BasicLine) // To avoid Scatter payline
            UI_paylines[payline.index].gameObject.SetActive(true);


        for (int i = 0; i < payline.symbols.Count; i++)
        {
            int reelIndex = payline.squares[i].Item1;
            int squareIndex = payline.squares[i].Item2;

            StartCoroutine(TurnSymbolFrameOn(payline.index, reelIndex, squareIndex));
        }
    }


    public IEnumerator TurnSymbolFrameOff(int reelIndex, int squareIndex)
    {
        Transform UI_square = UI_reels[reelIndex].GetChild(0).GetChild(squareIndex + 1);

        Transform UI_frame = UI_square.GetChild(0);
        UI_frame.gameObject.SetActive(false);

        yield return null;

        UI_square.GetComponent<Animator>().SetBool("IsWinning", false);
    }

    public IEnumerator TurnSymbolFrameOn(int paylineIndex, int reelIndex, int squareIndex)
    {
        Transform UI_square = UI_reels[reelIndex].GetChild(0).GetChild(squareIndex + 1);

        if (paylineIndex < (int)MAX_NR_OF_LINES)
        {
            Transform UI_frame = UI_square.GetChild(0);
            UI_frame.gameObject.SetActive(true);

            UI_frame.GetChild(0).GetComponent<Image>().sprite = symbolBorders[paylineIndex];
        }

        yield return null;

        UI_square.GetComponent<Animator>().SetBool("IsWinning", true);
    }


    private void DisplayReels()
    {
        foreach (Reel reel in M_Reels.singleton.reels)
            DisplayReel(reel);

        M_Payment.singleton.UpdatePayLines();
    }

    private void DisplayReel(Reel reel)
    {
        for (int squareIndex = 0; squareIndex < NR_OF_SQUARES; squareIndex++)
            UI_reels[reel.index].GetChild(0).GetChild(squareIndex+1).GetComponent<Animator>().SetInteger("AnimNumber", (int)reel.squares[squareIndex]);
    }
}