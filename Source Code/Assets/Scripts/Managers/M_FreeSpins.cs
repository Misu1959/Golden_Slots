using UnityEngine;

public class M_FreeSpins : MonoBehaviour
{
    public static M_FreeSpins singleton;

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
    }
}
