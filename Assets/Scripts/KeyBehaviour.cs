using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    GameManagerScript GMS;
    public float rotateSpeed = 10f;
    // Start is called before the first frame update
    private void Awake()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        GMS.cur_keys++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up *rotateSpeed);

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GMS.cur_keys--;
            //add score n stuff here
            GMS.UpdateUI();
        }
    }
}
