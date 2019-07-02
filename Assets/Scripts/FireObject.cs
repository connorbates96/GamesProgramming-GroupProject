using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireObject : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject pickupbullet1;
    public GameObject pickupbullet2;
    public GameObject pickupbullet3;
    public GameObject pickupbullet4;
    public GameObject pickupbullet5;
    public GameObject pickupbullet6;
    public GameObject pickupbullet7;
    public GameObject pickupbullet8;
    public GameObject pickupbullet9;
    public GameObject pickupbullet10;
    public GameObject pickupbullet11;
    public float ammo;
    public float Force = 2000f;
    public Transform DropPoint;
    public Text ammoText;

    private void Awake()
    {
        GetComponent<WeaponPickUp>();
    }
    // Update is called once per frame
    void Update()
    {
        if (pickupbullet1 == null )
        {
            ammo += 10;
            pickupbullet1 = new GameObject();
        }
        if (pickupbullet2 == null)
        {
            ammo += 10;
            pickupbullet2 = new GameObject();
        }
        if (pickupbullet3 == null)
        { 
            ammo += 10;
            pickupbullet3 = new GameObject();
        }
        if (pickupbullet4 == null)
        {
            ammo += 10;
            pickupbullet4 = new GameObject();
        }
        if (pickupbullet5 == null)
        {
            ammo += 10;
            pickupbullet5 = new GameObject();
        }
        if (pickupbullet6 == null)
        {
            ammo += 10;
            pickupbullet6 = new GameObject();
        }
        if (pickupbullet7 == null)
        {
            ammo += 10;
            pickupbullet7 = new GameObject();
        }
        if (pickupbullet8 == null)
        {
            ammo += 10;
            pickupbullet8 = new GameObject();
        }
        if (pickupbullet9 == null)
        {
            ammo += 10;
            pickupbullet9 = new GameObject();
        }
        if (pickupbullet10 == null)
        {
            ammo += 10;
            pickupbullet10 = new GameObject();
        }
        if (pickupbullet11 == null)
        {
            ammo += 10;
            pickupbullet11 = new GameObject();
        }

        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {

            GameObject BulletHolder;
            BulletHolder = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;

            BulletHolder.transform.Rotate(Vector3.left * 90);

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = BulletHolder.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Force);

            Destroy(BulletHolder, 2.0f);

            ammo--;

        }

        ammoText.text = "Ammo Left: " + ammo.ToString();

    }
}
