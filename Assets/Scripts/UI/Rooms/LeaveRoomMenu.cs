using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomsCanvases _roomCanveses;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomCanveses = canvases;
    }

    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomCanveses.CurrentRoomCanvas.Hide();
    }
}
