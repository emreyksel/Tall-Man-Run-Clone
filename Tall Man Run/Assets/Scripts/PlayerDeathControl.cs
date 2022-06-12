using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathControl : MonoBehaviour
{
    public GameObject head;
    
    private void Update()
    {
        if (transform.GetChild(1).transform.localScale.x <0.05f)
        {
            Death();
        }      
    }

    public void Death()
    {
        GameObject headClone = Instantiate(head, head.transform.position, Quaternion.identity);
        headClone.AddComponent<SphereCollider>();
        Rigidbody headCloneRb = headClone.AddComponent<Rigidbody>();
        headCloneRb.AddForce(0,2,5,ForceMode.Impulse);

        GameManager.instance.FailPanel();

        gameObject.SetActive(false);
    }
}
