using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public BodyTransform body;
    public Button height;
    public Button thicknes;
    public GameObject failPanel;
    public TextMeshProUGUI diamondScoreText;
    [HideInInspector] public static int diamondScore = 0;
    private static int heightPrice = 50;
    private static int thicknesPrice = 50;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        diamondScoreText.text = diamondScore.ToString();
        height.transform.GetChild(1).GetComponent<Text>().text = heightPrice.ToString();
        thicknes.transform.GetChild(1).GetComponent<Text>().text = thicknesPrice.ToString();

        if (diamondScore < heightPrice)
        {
            height.interactable = false;
        }
        if (diamondScore < thicknesPrice)
        {
            thicknes.interactable = false;
        }
    } 

    public void UpdateScore(int value)
    {
        diamondScore += value;
        diamondScoreText.text = diamondScore.ToString();
    }

    public void HeightUpgrade()
    {
        body.Height(0.25f);
        UpdateScore(-heightPrice);
        heightPrice +=10;
        height.transform.GetChild(1).GetComponent<Text>().text = heightPrice.ToString();
        if (diamondScore < heightPrice)
        {
            height.interactable = false;
        }
        if (diamondScore < thicknesPrice)
        {
            thicknes.interactable = false;
        }
    }

    public void ThicknesUpgrade()
    {
        body.Thicknes(0.1f);
        UpdateScore(-thicknesPrice);
        thicknesPrice +=10;
        thicknes.transform.GetChild(1).GetComponent<Text>().text = thicknesPrice.ToString();
        if (diamondScore < thicknesPrice)
        {
            thicknes.interactable = false;
        }
        if (diamondScore < heightPrice)
        {
            height.interactable = false;
        }
    }

    public void FailPanel()
    {
        StartCoroutine(FailPanelDelay());
    }

    IEnumerator FailPanelDelay()
    {
        yield return new WaitForSeconds(2f);
        failPanel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
