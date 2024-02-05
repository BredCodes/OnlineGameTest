using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootBullets1 : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);
        if (hit.collider == true && hit.transform.gameObject.GetComponent<Renderer>().material.color != Color.red)
        {
            Debug.Log(hit.transform.name);

            hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if(hit.collider == true && hit.transform.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            Debug.Log(hit.transform.name);

            hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
