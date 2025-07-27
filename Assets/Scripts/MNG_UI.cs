using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MNG_UI : MonoBehaviour
{
    public static MNG_UI singleton;

    private TextMeshProUGUI textCredits;
    private TextMeshProUGUI textWinAmmount;



    private void Awake()
    {
        SetInstance();
        InitializeCreditsPanel();
    }


    private void SetInstance()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }

    #region Credits Panel
    
    private void InitializeCreditsPanel()
    {
        MNG_Credits.singleton.onCreditsChange += DisplayCreditAmmount;
        MNG_Credits.singleton.onWinChange += DisplayWinAmmount;
    }

    private void DisplayCreditAmmount()
    {
        textCredits.text = "Credits: "+ MNG_Credits.singleton.creditAmmount;
    }
    private void DisplayWinAmmount()
    {
        textWinAmmount.text = "Win: " + MNG_Credits.singleton.creditAmmount;
    }
    #endregion


    #region Controlls Panel

    #endregion
}
