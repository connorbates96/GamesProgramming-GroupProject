using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector3 playerPosition;
    private Vector3 cameraPosition;
    public float speed = 400f;
    private Rigidbody rb;
    private Camera mainCamera;
    public Light fogOfWarLight;
    private int counter = 300;
    private float intensity = 20f;
    public GameObject startLight;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        StartCoroutine(TrackPlayer());
        fogOfWarLight.spotAngle = 200;
        fogOfWarLight.intensity = 10;
    }

    IEnumerator TrackPlayer() //while true always check players position
    {
        while(true)
        {
            playerPosition = gameObject.transform.position;
            yield return null; //return back
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter > 180)
        {
            mainCamera.transform.Rotate(0, 0.65f, -0.375f, Space.Self);
            counter--;
        }
        else if (counter > 150)
        {
            mainCamera.transform.Rotate(2, 0, 0, Space.Self);
            counter--;
        }
        else if (counter == 150)
        {
            Destroy(startLight);
            fogOfWarLight.spotAngle = counter;

            fogOfWarLight.intensity = intensity;
            intensity -= 0.15f;

            counter--;
        }
        else if (counter > 30)
        {
            fogOfWarLight.spotAngle = counter;

            fogOfWarLight.intensity = intensity;
            intensity -= 0.15f;

            counter--;
        }
        
    
        //begin movement
        float moveH = Input.GetAxisRaw("Horiztonal");
        float moveV = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
       rb.AddForce(movement * speed);

        //player faces mouse position
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));

        }
    }
}
