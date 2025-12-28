using UnityEngine;
using UnityEngine.UI;

public class M_UI_Settings : MonoBehaviour
{
    public static M_UI_Settings singleton;


    [SerializeField] private GameObject panelSettings;

    [SerializeField] private Button buttonOpenSettings;

    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSounds;


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
        panelSettings.GetComponent<UI_ClickBlocker>().action = () => panelSettings.SetActive(false);

        //buttonOpenSettings.onClick.AddListener(() => panelSettings.SetActive(true));
    }



}
