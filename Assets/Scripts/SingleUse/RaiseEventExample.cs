using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventExample : MonoBehaviourPun
{
    [SerializeField]
    private Material _material;

    private const byte COlOR_CHANGE_EVENT = 0;

    public Color customColor;

    private Color _1color;
    private Color _2color;

    ShootBullets1 shoot;

    private void Awake()
    {
        shoot = GameObject.Find("Player(Clone)").GetComponentInChildren<ShootBullets1>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(photonView.IsMine && gameObject.tag == "Tagged")
        {
            _1color = shoot._color1;
            _2color = shoot._color2;
            ChangeColor(_1color, _2color);
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == COlOR_CHANGE_EVENT && _material != null)
        {
            object[] data = (object[])obj.CustomData;
            float[] colorData = (float[])data[0];
            Color customColor = new Color(colorData[0], colorData[1], colorData[2], colorData[3]);

            _material.SetColor("_Color", customColor);
        }
    }

    public void ChangeColor(Color color1, Color color2)
    {
        if (_material.color == color1)
        {
            customColor = color2;
        }
        else
        {
            customColor = color1;
        }

        _material.SetColor("_Color", customColor);

        float[] colorData = new float[] { customColor.r, customColor.g, customColor.b, customColor.a };
        object[] datas = new object[] { colorData };

        PhotonNetwork.RaiseEvent(COlOR_CHANGE_EVENT, datas, RaiseEventOptions.Default, SendOptions.SendUnreliable);

        gameObject.tag = "NotTagged";
    }
}
