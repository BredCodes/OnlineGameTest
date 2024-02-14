using Photon.Pun;
using UnityEngine;

public class ShootBullets1 : MonoBehaviourPun
{
    public float damage = 10f;
    public float range = 100f;

    public Color _color1 = Color.red;
    public Color _color2 = Color.white;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if(!photonView.IsMine)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ShootLocally();

            this.photonView.RPC("Shoot", RpcTarget.Others);
        }
    }

    [PunRPC]
    void Shoot()
    {
        ShootLocally();
    }
    void ShootLocally()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.collider != null)
            {
                if (hit.transform.gameObject.GetComponent<Renderer>().material.color == Color.white)
                {
                    Debug.Log("Hit object: " + hit.transform.name);

                    hit.collider.tag = "Tagged";
                }
                else
                {
                    Debug.Log("Hit object: " + hit.transform.name);

                    hit.collider.tag = "Tagged";
                }
            }
        }
    }



}
