using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 100f;
    public GameObject deadBody;
    private bool created = false;
    private Vector3 originalPos;

    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    public void ApplyDamage(float amount)
    {
        health -= Mathf.Abs(amount);

        if (health <= 0)
        {
            if(!created)
            {
                Instantiate(deadBody, transform.position, transform.localRotation);

                created = true;
            }
            Die();
        }
    }

    // Start is called before the first frame update
    void Die()
    {
        //GameObject temp = Instantiate(enemy, enemy.transform.position, enemy.transform.localRotation);
        gameObject.transform.position = originalPos;
        health = 100f;
        created = false;
        
        //Thread.Sleep(1000);
        //respawnFlash();
        //Start timer until respawn
        //Remove dead body
        //Brief flash of light on location
        //Respawn
    }



    void respawnFlash()
    {

        // Make a game object
        GameObject lightGameObject = new GameObject("The Light");

        // Add the light component
        Light lightComp = lightGameObject.AddComponent<Light>();

        // Set color and position
        lightComp.color = Color.blue;

        // Set the position (or any transform property)
        lightGameObject.transform.position = new Vector3(0, 5, 0);


        //Vector3 currentLocation = deadBody.gameObject.transform.position;
        //currentLocation.y += 20;
        //Light temp = new Light();
        //temp.type = LightType.Spot;
        //temp.transform.position = currentLocation;
        //temp.intensity = 2;
        //temp.range = 100;
        //temp.spotAngle = 20;
        //UnityEngine.Quaternion quat = new Quaternion();
        //quat.x = 90;
        //temp.transform.rotation = quat;
        //Destroy(temp);
    }

}
