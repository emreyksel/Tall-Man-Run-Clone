using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gate : MonoBehaviour
{
    public enum TransformState
    {
        height,
        thicknes
    }
 
    private BodyTransform body;
    public TextMeshProUGUI sizeText;
    public GameObject gateParticle;
    public Image header;
    public Image arrow;
    public Sprite left;
    public Sprite right;
    public Sprite up;
    public Sprite down;
    public Material mavi;
    public Material kýrmýzý;
    public Color headerRedColor;
    public Color headerBlueColor;  
    private float heightMultiplier = 0.005f;
    private float thicknesMultiplier = 0.01f;

    [Header("Portal Settings")]
    [Space(10)]
    public TransformState transformState;
    public int size;

    private void Awake()
    {
        body = GameObject.FindGameObjectWithTag("Player").GetComponent<BodyTransform>();
    }

    private void Start()
    {
        switch (transformState)
        {
            case TransformState.height:
                if (size < 0)
                {
                    header.color = headerRedColor;
                    arrow.sprite = down;
                    GetComponent<MeshRenderer>().material = kýrmýzý;
                    sizeText.text = size.ToString();
                }
                else
                {
                    header.color = headerBlueColor;
                    arrow.sprite = up;
                    GetComponent<MeshRenderer>().material = mavi;
                    sizeText.text = "+" + size.ToString();
                }              
                break;

            case TransformState.thicknes:
                if (size < 0)
                {
                    header.color = headerRedColor;
                    arrow.sprite = left;
                    GetComponent<MeshRenderer>().material = kýrmýzý;
                    sizeText.text = size.ToString();
                }
                else
                {
                    header.color = headerBlueColor;
                    arrow.sprite = right;
                    GetComponent<MeshRenderer>().material = mavi;
                    sizeText.text = "+" + size.ToString();
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (transformState)
        {
            case TransformState.height:
                body.Height(size * heightMultiplier);
                Instantiate(gateParticle, transform.position, Quaternion.identity);
                break;
            case TransformState.thicknes:
                body.Thicknes(size * thicknesMultiplier);
                Instantiate(gateParticle, transform.position, Quaternion.identity);
                break;
        }

        gameObject.SetActive(false);
    }
}
