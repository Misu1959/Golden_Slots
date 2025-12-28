using System.Collections.Generic;
using UnityEngine;


public class M_Reels : MonoBehaviour
{
    public static M_Reels singleton { get; private set; }

    public Reel[] reels { get; private set; } = new Reel[Constants.NR_OF_REELS] 
    { new Reel(0), new Reel(1), new Reel(2), new Reel(3), new Reel(4) };


    private void Start() => Setup();

    private void Awake() => Initialize();
    private void Initialize()
    {
        if (singleton == null)
            singleton = this;
        else
            Destroy(this);
        
    }
    private void Setup()
    {
        M_Controls.singleton.onSpin += SetReels;
    }

    private void SetReels()
    {
        foreach (Reel reel in reels)
            reel.Spin();

    }
}