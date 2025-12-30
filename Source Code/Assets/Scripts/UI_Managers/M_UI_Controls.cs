using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_UI_Controls : MonoBehaviour
{
    public static M_UI_Controls singleton;

    [Header("Sprites")]
    [SerializeField] private Sprite bannerLogo;
    [SerializeField] private Sprite bannerFreeSpins;


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
    [SerializeField] private Button buttonStopAutoSpins;
    [SerializeField] private Button buttonSkipAnimations;

    [Header("Free Spins")]
    [SerializeField] private GameObject banner;
    [SerializeField] private GameObject displayMultiplier;
    [SerializeField] private GameObject displayFreeSpins;

    [SerializeField] private GameObject treasureBonusPanel;
    [SerializeField] private List<Button> buttonsTreasureBonusOption;




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
    
        SetAutoSpinButton();
        SetStopAutoSpinButton();
    }


    private void SetAutoSpinButton()
        => buttonStartAutoSpins.onClick.AddListener(M_Controls.singleton.StartAutoSpinning);

    private void SetStopAutoSpinButton()
    {
        buttonStopAutoSpins.onClick.AddListener(M_Controls.singleton.StopAutoSpinning);
        buttonStopAutoSpins.onClick.AddListener(() => ToggleStopAutoSpinsButton(false));
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
        SetTreasureBonusPanel();

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

    public void ToggleTakePayoutButton() => buttonTakePayout.gameObject.SetActive(M_Credits.singleton.payout > 0 && !M_Controls.singleton.isFreeSpinning);

    public void ToggleStopAutoSpinsButton(bool state) => buttonStopAutoSpins.gameObject.SetActive(state);

    public void ToggleSkipAnimationsButton(bool state) => buttonSkipAnimations.gameObject.SetActive(state);


    #endregion


    #region Free Spins


    private void SetTreasureBonusPanel()
    {
        foreach (Button treasureBonusOption in buttonsTreasureBonusOption)
            treasureBonusOption.onClick.AddListener(() => StartCoroutine(PlayTreasureBonusOptionAnimation(treasureBonusOption.GetComponent<Animator>())));

        treasureBonusPanel.GetComponent<Button>().onClick.AddListener(CloseTreasureBonusPanel);
    }


    public void ToggleBannerFreeSpins(bool status)
        => banner.GetComponent<Image>().sprite = status ? bannerFreeSpins : bannerLogo;
    public void ToggleMultiplierLabel(bool state) => displayMultiplier.SetActive(state);

    public void ToggleFreeSpinsLabel(bool state) => displayFreeSpins.SetActive(state);


    public void OpenTreasureBonusPanel()
    {
        canBeClosed = false;

        treasureBonusPanel.SetActive(true);
        SetTreasureBonusOptions();

        M_UI_Labels.singleton.DisplayTreasureBonus();
    }


    private bool canBeClosed;
    public void CloseTreasureBonusPanel()
    {
        if(!canBeClosed) return;

        treasureBonusPanel.SetActive(false);

        foreach (Button treasureBonusOption in buttonsTreasureBonusOption)
            treasureBonusOption.GetComponent<Animator>().SetBool("Play", false);

    }

    private void SetTreasureBonusOptions()
    {
        List<int> options = new List<int>() { 2, 3, 5 };


        foreach (Button treasureBonusOption in buttonsTreasureBonusOption)
        {
            treasureBonusOption.interactable = true;

            int option = options[Random.Range(0, options.Count)];
            options.Remove(option);

            treasureBonusOption.GetComponent<Animator>().SetInteger("Option", option);
        }
    }

    private IEnumerator PlayTreasureBonusOptionAnimation(Animator animatorOption)
    {
        M_Controls.singleton.multiplier = (MultiplierAmounts)animatorOption.GetComponent<Animator>().GetInteger("Option");
        
        M_UI_Labels.singleton.DisplayTreasureBonus();
        M_UI_Labels.singleton.DisplayMultiplier();


        foreach (Button treasureBonusOption in buttonsTreasureBonusOption)
            treasureBonusOption.interactable = false;


        animatorOption.GetComponent<Animator>().SetBool("Play", true);

        yield return new WaitForSeconds(1);
        canBeClosed = true;
    }


    #endregion
}
