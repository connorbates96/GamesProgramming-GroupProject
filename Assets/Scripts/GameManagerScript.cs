using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public Text keysLeft;
    public int cur_keys = 0;
    public int max_keys = 0;
    public GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive(false);
        max_keys = cur_keys;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUI()
    {
        if (cur_keys > 0)
        {
            keysLeft.text = "Keys Left: " + cur_keys.ToString();
        }
        else if (cur_keys <= 0)
        {
            Door.SetActive(true);
            keysLeft.text = "Keys Left: " + cur_keys.ToString() + "/" + max_keys.ToString();
        }
        
    }
}
