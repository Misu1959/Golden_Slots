using UnityEngine;

public class MNG_Slot : MonoBehaviour
{
    public static MNG_Slot singleton;


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

    private void Spin()
    {

    }

    private void CheckPayTable()
    {

    }

    private void CheckForBonusGames()
    {

    }

}
