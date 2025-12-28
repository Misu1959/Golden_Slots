using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Reel : MonoBehaviour
{
    private RectTransform content;

    private RectTransform symbolTop;
    private RectTransform symbolCenter;
    private RectTransform symbolBottom;


    private float symbolHeight = 250;

    [SerializeField] private float maxSpinTime;
    [SerializeField] private float spinSpeed;

    private float spinTime;
    private bool isSpinning;



    private void Start() => Setup();
    private void Update() => Spin();

    private void Setup()
    {
        content = transform.GetChild(0) as RectTransform;

        symbolTop       = content.GetChild(1) as RectTransform;
        symbolCenter    = content.GetChild(2) as RectTransform;
        symbolBottom    = content.GetChild(3) as RectTransform;
    
    }

    private void RecycleBottomToTop()
    {
        RectTransform top = content.GetChild(content.childCount - 1) as RectTransform;
        top.SetAsFirstSibling();


        if(top != symbolTop && top != symbolCenter && top != symbolBottom)
            top.GetComponent<Animator>().SetInteger("AnimNumber", Random.Range(0, 13));
    }


    private void Spin()
    {
        if (!isSpinning) return;

        content.anchoredPosition -= new Vector2(0, spinSpeed * Time.deltaTime);

        while (content.anchoredPosition.y <= -symbolHeight)
        {
            content.anchoredPosition += new Vector2(0, symbolHeight);
            RecycleBottomToTop();
        }

    }


    public void StartSpin()
    {
        isSpinning = true;
        StartCoroutine(StopSpin());
    }

    public void ForceStop() 
        => isSpinning = false;

    private IEnumerator StopSpin()
    {
        spinTime = 0;

        while (spinTime < maxSpinTime)
        {
            if (!isSpinning)
                break;

            spinTime += Time.deltaTime;
            yield return null;
        }

        isSpinning = false;

        content.anchoredPosition = Vector2.zero;

        symbolBottom.SetAsFirstSibling();
        symbolCenter.SetAsFirstSibling();
        symbolTop.SetAsFirstSibling();
        content.GetChild(content.childCount-1).SetAsFirstSibling(); // Set as top buffer
    }
}