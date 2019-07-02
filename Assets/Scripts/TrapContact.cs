using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrapContact : MonoBehaviour
{
    public float speed;
    public float multiplier = 1f;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Trap")
        {
            multiplier = 0.1f;
            gameObject.GetComponent<NavMeshAgent>().speed = 1;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Trap")
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(3f);
            multiplier = 1f;
        }
    }
}
