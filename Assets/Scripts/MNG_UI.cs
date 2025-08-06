using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MNG_UI : MonoBehaviour
{
    public static MNG_UI singleton;

[Header("Settings")]
    [SerializeField] private GameObject panelSettings;

    [SerializeField] private Button buttonOpenSettings;
    [SerializeField] private Button buttonCloseSettings;

    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSounds;

[Header("Credits")]
    [SerializeField] private TextMeshProUGUI textCredits;
    [SerializeField] private TextMeshProUGUI textPayout;
    [SerializeField] private TextMeshProUGUI textFreeSpins;

[Header("Controls")]
    [Header("\tBet")]
    [SerializeField] private TextMeshProUGUI textTotalBet;
    
    [SerializeField] private TextMeshProUGUI textBet;
    [SerializeField] private Button buttonIncreaseBet;
    [SerializeField] private Button buttonDecreaseBet;
    [SerializeField] private Button buttonMaxBet;

    [Header("\tLines")]
    [SerializeField] private TextMeshProUGUI textLines;
    [SerializeField] private Button buttonIncreaseLines;
    [SerializeField] private Button buttonDecreaseLines;

    [Header("\tSpin")]
    [SerializeField] private Button buttonSpin;
    [SerializeField] private Button buttonTakePayout;
    [SerializeField] private Button buttonDoubleDown;


    [Header("Double Down")]

    [SerializeField] private GameObject panelDoubleDown;
    [Header("\tButtons")]
    [SerializeField] private Button buttonTakeDoublePayout;
    [SerializeField] private Button buttonRed;
    [SerializeField] private Button buttonBlack;

    [Header("\tTexts")]
    [SerializeField] private TextMeshProUGUI textDoublePayout;
    [SerializeField] private TextMeshProUGUI textNextDoublePayout;
    [SerializeField] private TextMeshProUGUI textDoublesLeft;

    private void Awake() => Initialize();

    private void Start()
    {
        SetSettingsPanel();
        SetCreditsPanel();
        SetControlsPanel();
        SetSpinControls();

        SetDoubleDownPanel();
    }


    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }


    #region Settings Panel

    private void SetSettingsPanel()
    {
        buttonOpenSettings.onClick.AddListener(() => panelSettings.gameObject.SetActive(true));
        buttonCloseSettings.onClick.AddListener(() => panelSettings.gameObject.SetActive(false));
    }


    #endregion

    #region Texts Panel

    private void SetCreditsPanel()
    {
        DisplayCreditAmount();
        DisplayPayoutAmount();

        MNG_Credits.singleton.onCreditsChange += DisplayCreditAmount;
        MNG_Credits.singleton.onPayoutChange += DisplayPayoutAmount;
    }

    private void DisplayCreditAmount() => textCredits.text = "Credits: " + MNG_Credits.singleton.creditAmount;
    private void DisplayPayoutAmount() => textPayout.text = "Win: " + MNG_Credits.singleton.payout;
    
    
    private void ActivateFreeSpinsText(bool mode) => textFreeSpins.gameObject.SetActive(mode);


    #endregion

    #region Controls Panel

    private void SetControlsPanel()
    {
        DisplayTotalBetAmount();
        DisplayBetAmount();
        DisplayNrOfLines();


        MNG_Controls.singleton.onTotalBetChange += DisplayTotalBetAmount;
        MNG_Controls.singleton.onBetChange += DisplayBetAmount;
        MNG_Controls.singleton.onLinesChange += DisplayNrOfLines;
    
        SetIncreaseBetButton();
        SetDecreaseBetButton();


        SetIncreaseLinesButton();
        SetDecreaseLinesButton();
        SetMaxBetButton();
    }

    private void DisplayTotalBetAmount() => textTotalBet.text = "Total Bet: " + MNG_Controls.singleton.totalBet;
    private void DisplayBetAmount() => textBet.text = "Bet: " + (int)MNG_Controls.singleton.bet;



    private void SetIncreaseBetButton()
    {
        buttonIncreaseBet.onClick.AddListener(MNG_Controls.singleton.IncreaseBet);

        buttonIncreaseBet.onClick.AddListener(EnableIncreaseBetButton);
        buttonIncreaseBet.onClick.AddListener(EnableDecreaseBetButton);
    }
    private void SetDecreaseBetButton()
    {
        buttonDecreaseBet.onClick.AddListener(MNG_Controls.singleton.DecreaseBet);

        buttonDecreaseBet.onClick.AddListener(EnableIncreaseBetButton);
        buttonDecreaseBet.onClick.AddListener(EnableDecreaseBetButton);
    }
    private void SetMaxBetButton()
    {
        buttonMaxBet.onClick.AddListener(MNG_Controls.singleton.SetBetToMaxBet);

        buttonMaxBet.onClick.AddListener(EnableIncreaseBetButton);
        buttonMaxBet.onClick.AddListener(EnableDecreaseBetButton);
    }

    
    private void EnableIncreaseBetButton() => buttonIncreaseBet.interactable = MNG_Controls.singleton.bet != Constants.MAX_BET;
    private void EnableDecreaseBetButton() => buttonDecreaseBet.interactable = MNG_Controls.singleton.bet != Constants.MIN_BET;





    private void DisplayNrOfLines() => textLines.text = "Lines: " + (int)MNG_Controls.singleton.lines;
    

    private void SetIncreaseLinesButton()
    { 
        buttonIncreaseLines.onClick.AddListener(MNG_Controls.singleton.IncreaseLines);

        buttonIncreaseLines.onClick.AddListener(EnableIncreaseLinesButton);
        buttonIncreaseLines.onClick.AddListener(EnableDecreaseLinesButton);
    }
    private void SetDecreaseLinesButton()
    {
        buttonDecreaseLines.onClick.AddListener(MNG_Controls.singleton.DecreaseLines);

        buttonDecreaseLines.onClick.AddListener(EnableIncreaseLinesButton);
        buttonDecreaseLines.onClick.AddListener(EnableDecreaseLinesButton);
    }
    

    private void EnableIncreaseLinesButton() => buttonIncreaseLines.interactable = MNG_Controls.singleton.lines != Constants.MAX_NR_OF_LINES;
    private void EnableDecreaseLinesButton() => buttonDecreaseLines.interactable = MNG_Controls.singleton.lines != Constants.MIN_NR_OF_LINES;
    #endregion

    #region Spin Panel

    private void SetSpinControls()
    {
        SetSpinButton();
        SetTakePayoutButton();
        SetDoubleDownButton();
    }

    private void SetSpinButton()
    {
        MNG_Controls.singleton.onTotalBetChange += EnableSpinButton;
        MNG_Credits.singleton.onCreditsChange += EnableSpinButton;

        buttonSpin.onClick.AddListener(MNG_Base.singleton.Spin);
    }

    private void SetTakePayoutButton()
    {
        MNG_Credits.singleton.onPayoutChange += () => ActivateTakePayoutButton(true);
        MNG_Credits.singleton.onPayoutReset += () => ActivateTakePayoutButton(false);
        
        buttonTakePayout.onClick.AddListener(MNG_Base.singleton.TakeWin);
    }

    private void SetDoubleDownButton()
    {
        MNG_Credits.singleton.onPayoutChange += () => ActivateDoubleDownButton(true);
        MNG_Credits.singleton.onPayoutReset += () => ActivateDoubleDownButton(false);

        buttonDoubleDown.onClick.AddListener(MNG_DoubleDown.singleton.EnterDD);
    }


    private void EnableSpinButton() => buttonSpin.interactable = MNG_Credits.singleton.creditAmount >= MNG_Controls.singleton.totalBet;
    private void ActivateTakePayoutButton(bool mode) => buttonTakePayout.gameObject.SetActive(mode);
    private void ActivateDoubleDownButton(bool mode) => buttonDoubleDown.gameObject.SetActive(mode);


    #endregion

    #region Panel DoubleDown

    private void SetDoubleDownPanel()
    {
        MNG_DoubleDown.singleton.onEnterDD += () => ActivateDoubleDownPanel(true);
        MNG_DoubleDown.singleton.onExitDD  += () => ActivateDoubleDownPanel(false);
        
        SetDoubleDownButtons();
        SetDoubleDownTexts();
    }

    private void ActivateDoubleDownPanel(bool mode) => panelDoubleDown.SetActive(mode);
    private void SetDoubleDownButtons()
    {
        SetTakeDoubleDownPayoutButton();
        SetChooseRedButton();
        SetChooseBlackButton();
    }
    private void SetDoubleDownTexts()
    {
        MNG_Credits.singleton.onPayoutChange += DisplayDoublePayoutAmount;
        MNG_Credits.singleton.onPayoutChange += DisplayNextDoublePayoutAmount;
        MNG_Credits.singleton.onPayoutChange += DisplayNrDoublesLeft;
    }




    private void SetTakeDoubleDownPayoutButton()    => buttonTakeDoublePayout.onClick.AddListener(MNG_DoubleDown.singleton.TakeWin); 
    private void SetChooseRedButton()               => buttonRed.onClick.AddListener(() => MNG_DoubleDown.singleton.PickCard(DoubleDownCards.red));
    private void SetChooseBlackButton()             => buttonBlack.onClick.AddListener(() => MNG_DoubleDown.singleton.PickCard(DoubleDownCards.black));



    private void DisplayDoublePayoutAmount()        => textDoublePayout.text = "Win: " + MNG_Credits.singleton.payout;
    private void DisplayNextDoublePayoutAmount()    => textNextDoublePayout.text = "Double for: " + MNG_Credits.singleton.payout * 2;
    private void DisplayNrDoublesLeft()             => textDoublesLeft.text = "Doubles left: " + 5;

    #endregion
}
