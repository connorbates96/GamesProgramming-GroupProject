using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropTrap : MonoBehaviour
{

    public float traps;
    //public GameObject Trap;
    public GameObject TrapLight;

    public GameObject pickuptrap1;
    public GameObject pickuptrap2;
    public GameObject pickuptrap3;
    public GameObject pickuptrap4;
    public GameObject pickuptrap5;
    public Text trapText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickuptrap1 == null)
        {
            traps += 1;
            pickuptrap1 = new GameObject();
        }
        if (pickuptrap2 == null)
        {
            traps += 1;
            pickuptrap2 = new GameObject();
        }
        if (pickuptrap3 == null)
        {
            traps += 1;
            pickuptrap3 = new GameObject();
        }
        if (pickuptrap4 == null)
        {
            traps += 1;
            pickuptrap4 = new GameObject();
        }
        if (pickuptrap5 == null)
        {
            traps += 1;
            pickuptrap5 = new GameObject();
        }

        if (Input.GetButtonDown("Fire2") && traps > 0)
        {
            //GameObject TrapHolder;
            //TrapHolder = Instantiate(Trap, transform.position, transform.rotation) as GameObject;

            GameObject TrapLightHolder;
            Quaternion currRotation = transform.rotation;
            //currRotation.y = 90;
            Vector3 currPosition = transform.position;
            currPosition.y += 1;
            TrapLightHolder = Instantiate(TrapLight, currPosition, currRotation) as GameObject;



            traps--;

        }

        trapText.text = "Traps Left: " + traps.ToString();
    }
}
