using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContact : MonoBehaviour
{


    //public GameObject impactEffect;
    //public float damage = 10f;
    public Light mainLight;
    public GameObject player;


    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        //Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));

        if (collision.gameObject.tag == "Player")
        {
            //Destroy(player);
            SceneManager.LoadScene(Application.loadedLevel);
        }

        //Destroy(gameObject);
    }



}
