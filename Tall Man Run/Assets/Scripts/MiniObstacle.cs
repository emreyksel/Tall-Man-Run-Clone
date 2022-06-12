using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniObstacle : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.GetChild(1).transform.localScale.y > 0.5f)
            {
                collision.gameObject.GetComponent<BodyTransform>().Height(-0.15f);
            }
            else
            {
                collision.gameObject.GetComponent<BodyTransform>().Thicknes(-0.1f);
            }

            GetComponent<BoxCollider>().isTrigger = true;
            rb.AddForce(Random.Range(-10,10), Random.Range(8,12), Random.Range(8,12), ForceMode.Impulse);
        }
    }
}
