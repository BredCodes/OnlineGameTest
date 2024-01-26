using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoom _createRoomMenu;
    [SerializeField]
    private RoomsListingMenu _roomListingsMenu;

    private RoomsCanvases _roomsCanveses;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanveses = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _roomListingsMenu.FirstInitialize(canvases);
    }
}
