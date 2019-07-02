using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrapTrigger : MonoBehaviour
{
    private bool canSlow = true;
    void Update()
    {

    }



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Enemy" /*&& canSlow*/)
        {
            StartCoroutine(Wait());
            collider.GetComponent<NavMeshAgent>().speed = 1;
            //gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
            //canSlow = false;
        }

        IEnumerator Wait()
        {
            yield return new WaitForSecondsRealtime(3f);
            Destroy(gameObject);
            collider.GetComponent<NavMeshAgent>().speed = 8;
        }

    }
}
