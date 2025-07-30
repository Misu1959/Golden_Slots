using TMPro;
using Unity.VisualScripting;
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

    [Header("Spin")]
    [SerializeField] private Button buttonSpin;
    [SerializeField] private Button buttonTakeWin;
    [SerializeField] private Button buttonDoubleDown;


    private void Awake() => Initialize();

    private void Start()
    {
        SetSettingsPanel();
        SetCreditsPanel();
        SetControlsPanel();
        SetSpinControls();
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
        DisplayWinAmount();

        MNG_Credits.singleton.onCreditsChange += DisplayCreditAmount;
        MNG_Credits.singleton.onPayoutChange += DisplayWinAmount;

        MNG_Slot.singleton.onEnterFreeSpinsMode += ActivateFreeSpinsText;
    }

    private void DisplayCreditAmount()
        => textCredits.text = "Credits: "+ MNG_Credits.singleton.creditAmount;
    private void DisplayWinAmount()
        => textPayout.text = "Win: " + MNG_Credits.singleton.payout;
    
    private void ActivateFreeSpinsText()
        => textFreeSpins.gameObject.SetActive(true);

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

    private void DisplayTotalBetAmount()
        => textTotalBet.text = "Total Bet: " + MNG_Controls.singleton.totalBet;
    private void DisplayBetAmount()
        => textBet.text = "Bet: " + (int)MNG_Controls.singleton.bet;


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

    
    private void EnableIncreaseBetButton()
        => buttonIncreaseBet.interactable = MNG_Controls.singleton.bet != Data.MAX_BET;
    private void EnableDecreaseBetButton()
        => buttonDecreaseBet.interactable = MNG_Controls.singleton.bet != Data.MIN_BET;


    private void DisplayNrOfLines()
        => textLines.text = "Lines: " + (int)MNG_Controls.singleton.lines;
    
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

    private void EnableIncreaseLinesButton()
        => buttonIncreaseLines.interactable = MNG_Controls.singleton.lines != Data.MAX_NR_OF_LINES;
    private void EnableDecreaseLinesButton()
        => buttonDecreaseLines.interactable = MNG_Controls.singleton.lines != Data.MIN_NR_OF_LINES;

    #endregion

    #region Spin Panel

    private void SetSpinControls()
    {
        SetSpinButton();
        SetTakeWinButton();
        SetDoubleDownButton();
    }

    private void SetSpinButton()
    {
        MNG_Controls.singleton.onTotalBetChange += EnableSpinButton;

        buttonSpin.onClick.AddListener(MNG_Slot.singleton.Spin);
    }

    private void SetTakeWinButton()
    {
        MNG_Credits.singleton.onPayoutChange += ActivateTakeWinButton;

        buttonTakeWin.onClick.AddListener(MNG_Slot.singleton.TakeWin);
    }

    private void SetDoubleDownButton()
    {
        MNG_Credits.singleton.onPayoutChange += ActivateDoubleDownButton;

        buttonDoubleDown.onClick.AddListener(MNG_Slot.singleton.EnterDoubleDownMode);
    }


    private void EnableSpinButton()
        => buttonSpin.interactable = MNG_Credits.singleton.creditAmount >= MNG_Controls.singleton.totalBet;

    private void ActivateTakeWinButton()
        =>  buttonTakeWin.gameObject.SetActive(MNG_Credits.singleton.payout != 0);

    private void ActivateDoubleDownButton()
        =>  buttonDoubleDown.gameObject.SetActive(MNG_Credits.singleton.payout != 0);


    #endregion
}
