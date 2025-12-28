using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_UI_Info : MonoBehaviour
{
    public static M_UI_Info singleton;

    [Header("Sprites")]
    [SerializeField] private List<Sprite> pages;
    private int currentPage;

    [Header("In Scene Objects")]
    [SerializeField] private GameObject panelInfo;

    [SerializeField] private Button buttonExitInfo;
    [SerializeField] private Button buttonPrevPage;
    [SerializeField] private Button buttonNextPage;



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
        SetButtonExitInfo();
        SetButtonPrevPage();
        SetButtonNextPage();
    }


    private void SetButtonExitInfo()
        => buttonExitInfo.onClick.AddListener(CloseInfoPanel);

    private void SetButtonPrevPage()
        => buttonPrevPage.onClick.AddListener(() => ChangePage(currentPage - 1));

    private void SetButtonNextPage()
        => buttonNextPage.onClick.AddListener(() => ChangePage(currentPage + 1));
    
    public void OpenInfoPanel()
    {
        panelInfo.SetActive(true);
        ChangePage(0);
    }
    private void CloseInfoPanel()
        => panelInfo.SetActive(false);


    private void ChangePage(int newPage)
    {
        currentPage = newPage;
        panelInfo.GetComponent<Image>().sprite = pages[currentPage];

        TogglePrevPageButton();
        ToggleNextPageButton();
    }


    private void TogglePrevPageButton()
        => buttonPrevPage.interactable = currentPage > 0;

    private void ToggleNextPageButton()
    => buttonNextPage.interactable = currentPage < pages.Count - 1;
}
