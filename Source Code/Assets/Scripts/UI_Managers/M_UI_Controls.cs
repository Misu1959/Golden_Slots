using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class M_UI_Controls : MonoBehaviour
{
    public static M_UI_Controls singleton;

    [Header("Info")]
    [SerializeField] private Button buttonInfo;

    [Header("Auto Spins")]
    [SerializeField] private Button buttonStartAutoSpins;
    [SerializeField] private Button buttonDecreaseAutoSpins;
    [SerializeField] private Button buttonIncreaseAutoSpins;

    [Header("Lines")]
    [SerializeField] private Button buttonMaxLines;
    [SerializeField] private Button buttonDecreaseLines;
    [SerializeField] private Button buttonIncreaseLines;

    [Header("Bet")]
    [SerializeField] private Button buttonMaxBet;
    [SerializeField] private Button buttonDecreaseBet;
    [SerializeField] private Button buttonIncreaseBet;
    
    [SerializeField] private Button buttonTotalMaxBet;

    [Header("Spin")]
    [SerializeField] private Button buttonSpin;
    [SerializeField] private Button buttonTakePayout;
    [SerializeField] private Button buttonSkipAnimations;

    private bool overrideControls;

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
        SetInfoControls();
        SetAutoSpinsControls();
        SetLinesControls();
        SetBetControls();
        SetSpinControls();
    }

    public void OverrideControls(bool _overrideControls)
    {
        overrideControls = _overrideControls;

        EnableAutoSpinsButton();
        EnableDecreaseAutoSpinsButton();
        EnableIncreaseAutoSpinsButton();

        EnableMaxLinesButton();
        EnableDecreaseLinesButton();
        EnableIncreaseLinesButton();

        EnableMaxBetButton();
        EnableDecreaseBetButton();
        EnableIncreaseBetButton();

        EnableTotalMaxBetButton();
    }

    #region Info

    private void SetInfoControls()
    {
        SetInfoButton();
    }
    private void SetInfoButton()
        => buttonInfo.onClick.AddListener(M_UI_Info.singleton.OpenInfoPanel);

    #endregion

    #region Auto Spins

    private void SetAutoSpinsControls()
    {
        M_Controls.singleton.onAutoSpinsChange += EnableDecreaseAutoSpinsButton;
        M_Controls.singleton.onAutoSpinsChange += EnableIncreaseAutoSpinsButton;
        
        SetDecreaseAutoSpinsButton();
        SetIncreaseAutoSpinsButton();
    }
    private void SetDecreaseAutoSpinsButton()
        => buttonDecreaseAutoSpins.onClick.AddListener(M_Controls.singleton.DecreaseAutoSpins);

    private void SetIncreaseAutoSpinsButton()
        => buttonIncreaseAutoSpins.onClick.AddListener(M_Controls.singleton.IncreaseAutoSpins);



    private void EnableAutoSpinsButton()
        => buttonStartAutoSpins.interactable = !overrideControls;

    private void EnableDecreaseAutoSpinsButton()
        => buttonDecreaseAutoSpins.interactable = (overrideControls) ? false : M_Controls.singleton.autoSpins != Constants.MIN_NR_OF_AUTO_SPINS;

    private void EnableIncreaseAutoSpinsButton()
        => buttonIncreaseAutoSpins.interactable = (overrideControls) ? false : M_Controls.singleton.autoSpins != Constants.MAX_NR_OF_AUTO_SPINS;


    #endregion

    #region Lines

    private void SetLinesControls()
    {
        M_Controls.singleton.onLinesChange += EnableDecreaseLinesButton;
        M_Controls.singleton.onLinesChange += EnableIncreaseLinesButton;

        SetMaxLinesButton();
        SetIncreaseLinesButton();
        SetDecreaseLinesButton();
    }

    private void SetMaxLinesButton()
        => buttonMaxLines.onClick.AddListener(M_Controls.singleton.MaxLines);
    private void SetDecreaseLinesButton()
        => buttonDecreaseLines.onClick.AddListener(M_Controls.singleton.DecreaseLines);
    private void SetIncreaseLinesButton()
        => buttonIncreaseLines.onClick.AddListener(M_Controls.singleton.IncreaseLines);


    private void EnableMaxLinesButton()
        => buttonMaxLines.interactable = !overrideControls;

    private void EnableDecreaseLinesButton() 
        => buttonDecreaseLines.interactable = (overrideControls) ? false : M_Controls.singleton.lines != Constants.MIN_NR_OF_LINES;
    private void EnableIncreaseLinesButton() 
        => buttonIncreaseLines.interactable = (overrideControls) ? false : M_Controls.singleton.lines != Constants.MAX_NR_OF_LINES;
    #endregion

    #region Bet 

    private void SetBetControls()
    {
        M_Controls.singleton.onBetChange += EnableDecreaseBetButton;
        M_Controls.singleton.onBetChange += EnableIncreaseBetButton;

        SetMaxBetButton();
        SetIncreaseBetButton();
        SetDecreaseBetButton();

        SetTotalMaxBetButton();
    }

    private void SetMaxBetButton()
        => buttonMaxBet.onClick.AddListener(M_Controls.singleton.MaxBet);
    private void SetDecreaseBetButton()
        => buttonDecreaseBet.onClick.AddListener(M_Controls.singleton.DecreaseBet);
    private void SetIncreaseBetButton()
        => buttonIncreaseBet.onClick.AddListener(M_Controls.singleton.IncreaseBet);
    private void SetTotalMaxBetButton()
        => buttonTotalMaxBet.onClick.AddListener(M_Controls.singleton.TotalMaxBet);


    private void EnableMaxBetButton()
        => buttonMaxBet.interactable = !overrideControls;

    private void EnableDecreaseBetButton() 
        => buttonDecreaseBet.interactable = (overrideControls) ? false : M_Controls.singleton.bet != Constants.MIN_BET;
    private void EnableIncreaseBetButton() 
        => buttonIncreaseBet.interactable = (overrideControls) ? false : M_Controls.singleton.bet != Constants.MAX_BET;

    private void EnableTotalMaxBetButton()
        => buttonTotalMaxBet.interactable = !overrideControls;

    #endregion

    #region Spin

    private void SetSpinControls()
    {
        SetSpinButton();
        SetTakePayoutButton();
        SetSkipAnimationsButton();
    }

    private void SetSpinButton()
    {
        M_Controls.singleton.onTotalBetChange += ToggleSpinButton;
        M_Credits.singleton.onCreditsChange += ToggleSpinButton;

        buttonSpin.onClick.AddListener(M_Controls.singleton.Spin);
    }

    private void SetTakePayoutButton()
    {
        M_Credits.singleton.onPayoutChange += () => ToggleTakePayoutButton();

        buttonTakePayout.onClick.AddListener(M_Credits.singleton.TakeWin);
    }
    private void SetSkipAnimationsButton()
        => buttonSkipAnimations.onClick.AddListener(M_UI_Reels.singleton.SkipAnimations);

    private void ToggleSpinButton() => buttonSpin.interactable = M_Credits.singleton.creditAmount >= M_Controls.singleton.totalBet;
    private void ToggleTakePayoutButton() => buttonTakePayout.gameObject.SetActive(M_Credits.singleton.payout > 0);
    public void ToggleSkipAnimationsButton(bool state) => buttonSkipAnimations.gameObject.SetActive(state);


    #endregion

}
