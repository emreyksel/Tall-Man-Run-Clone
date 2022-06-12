using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public GameObject diamondParticle;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.UpdateScore(5);
        Instantiate(diamondParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
