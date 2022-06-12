using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapToStartText : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject market;

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !IsMouseOverUI())
        {
            playerMove.canMove = true;
            market.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
