using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public Transform cam;
    private string tagOn = "ActiveGun";
    private string tagOff = "InactiveGun";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            for (int i = 0; i < cam.childCount; i++)
            {
                if (cam.GetChild(i).gameObject.CompareTag(tagOn))
                {
                    cam.GetChild(i).gameObject.SetActive(false);
                    cam.GetChild(i).gameObject.tag = tagOff;
                }
                else if (cam.GetChild(i).gameObject.CompareTag(tagOff))
                {
                    cam.GetChild(i).gameObject.SetActive(true);
                    cam.GetChild(i).gameObject.tag = tagOn;
                }
            }
        }
    }
}
