using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text _roomName;

    private RoomsCanvases _roomsCanveses;
        
    public void FirstInitialize(RoomsCanvases canveses)
    {
        _roomsCanveses = canveses;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, roomOptions, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room succesfully", this);
        _roomsCanveses.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message, this);
    }
}