using System;
using UnityEngine;

public class MNG_Credits : MonoBehaviour
{
    public static MNG_Credits singleton;

    public Action onCreditsChange;
    public Action onWinChange;


    public int creditAmmount { get; private set; }
    public int winAmmount { get; private set; }


    private void Awake() => SetInstance();
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void SetInstance()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }

    public bool CheckCreditAmmount(int creditAmountToCheck) => creditAmmount >= creditAmountToCheck;


    public void AddCredit(int creditAmountToAdd)
    {
        creditAmmount += creditAmountToAdd;
        onCreditsChange?.Invoke();
    }
    public void RemoveCredit(int creditAmountToRemove)
    {
        creditAmmount -= creditAmountToRemove;
        onCreditsChange?.Invoke();
    }
}
