using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class M_UI_Labels : MonoBehaviour
{
    public static M_UI_Labels singleton;

    [SerializeField] private TextMeshProUGUI labelCredits;
    [SerializeField] private TextMeshProUGUI labelAutoSpins;
    [SerializeField] private TextMeshProUGUI labelLines;
    [SerializeField] private TextMeshProUGUI labelBet;
    [SerializeField] private TextMeshProUGUI labelTotalBet;
    [SerializeField] private TextMeshProUGUI labelPayout;

    [SerializeField] private TextMeshProUGUI labelMultiplier;
    [SerializeField] private TextMeshProUGUI labelFreeSpins;
    [SerializeField] private TextMeshProUGUI labelTreasureBonus;

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
        M_Credits.singleton.onCreditsChange += DisplayCredit;

        M_Credits.singleton.onPayoutChange += DisplayPayout;

        M_Controls.singleton.onAutoSpinsChange += DisplayAutoSpins;
        M_Controls.singleton.onLinesChange += DisplayLines;
        M_Controls.singleton.onBetChange += DisplayBet;
        M_Controls.singleton.onTotalBetChange += DisplayTotalBet;




        DisplayCredit();
        DisplayPayout();
    }

    private void DisplayCredit() => labelCredits.text = M_Credits.singleton.creditAmount.ToString();
    private void DisplayPayout() => labelPayout.text = (M_Credits.singleton.payout == 0) ? string.Empty : M_Credits.singleton.payout.ToString();

    private void DisplayAutoSpins() => labelAutoSpins.text = M_Controls.singleton.autoSpinsLeft.ToString(); 
    private void DisplayLines() => labelLines.text = ((int)M_Controls.singleton.lines).ToString();
    private void DisplayBet() => labelBet.text = ((int)M_Controls.singleton.bet).ToString();
    private void DisplayTotalBet() => labelTotalBet.text = M_Controls.singleton.totalBet.ToString();


    public void DisplayMultiplier() => labelMultiplier.text = ((int)M_Controls.singleton.multiplier).ToString();
    public void DisplayFreeSpins() => labelFreeSpins.text = M_Controls.singleton.freeSpinsLeft.ToString();

    public void DisplayTreasureBonus()
    {
        string mult = M_Controls.singleton.multiplier == MultiplierAmounts._1 ? "??" : ((int)M_Controls.singleton.multiplier).ToString()+"x";
        labelTreasureBonus.text = "You won " + M_Controls.singleton.freeSpinsLeft + " free spins" + "\nwith a " + mult + " multiplier";
    }
}
