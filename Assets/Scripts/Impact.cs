using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{

    public GameObject impactEffect;
    public float damage = 10f;

   
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyTarget target = collision.transform.gameObject.GetComponent<EnemyTarget>();
            target.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }

}
