using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventExample : MonoBehaviourPun
{
    [SerializeField]
    private Renderer _renderer;

    private const byte COlOR_CHANGE_EVENT = 0;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(photonView.IsMine && Input.GetKey(KeyCode.Escape))
        {
            ChangeColor();
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if(obj.Code == COlOR_CHANGE_EVENT)
        {
            object[] data = (object[])obj.CustomData;
            float r = (float)data[0];
            float g = (float)data[1];
            float b = (float)data[2];

            Color customColor = new Color(r, g, b, 1f);

            _renderer.material.SetColor("_Color", customColor);
        }
    }

    private void ChangeColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        Color customColor = new Color(r, g, b, 1f);

        _renderer.material.SetColor("_Color", customColor);

        object[] datas = new object[] { r, g, b };

        PhotonNetwork.RaiseEvent(COlOR_CHANGE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }
}
