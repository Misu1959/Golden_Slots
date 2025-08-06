using UnityEngine;

public class MNG_FreeSpins : MonoBehaviour
{
    public static MNG_FreeSpins singleton;

    private void Awake() => Initialize();

    private void Initialize()
    {
        if (singleton != null)
            Destroy(this);

        singleton = this;
    }
}
