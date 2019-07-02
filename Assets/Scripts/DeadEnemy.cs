using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    private Rigidbody rb;
    public float force;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Random.rotation;
        force = Random.Range(800f, 1600f);

        rb.AddForce(transform.up * force);
    }

}
