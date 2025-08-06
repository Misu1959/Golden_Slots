using UnityEngine;

public class MNG_Payment : MonoBehaviour
{
    public static MNG_Payment singleton;

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }



    private void CheckPayTable()
    {

    }
}
