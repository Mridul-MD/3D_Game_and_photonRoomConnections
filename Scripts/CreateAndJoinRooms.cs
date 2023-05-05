using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    public TMP_InputField CreateInput;
    public TMP_InputField JoinInput;
    int numConnected;
    public static CreateAndJoinRooms room;

    private void Awake()
    {
        //set up singleton
        if (CreateAndJoinRooms.room == null)
        {
            CreateAndJoinRooms.room = this;
        }
        else
        {
            if (CreateAndJoinRooms.room != this)
            {
                Destroy(CreateAndJoinRooms.room.gameObject);
                CreateAndJoinRooms.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        
        //string RoomName = JoinInput.text;
        //if (!PhotonNetwork.IsConnected)
        //{
        //    PhotonNetwork.JoinLobby = false;

        //}
    }
    #region Methods
    public void CreateRoom()
    {
        string RoomName = CreateInput.text;
        //if (!string.IsNullOrEmpty(RoomName))
        //{
        //    RoomName = RoomName + Random.Range(1, 30);
        //}
       
        RoomOptions RoomOptions = new RoomOptions();
        RoomOptions.MaxPlayers = 6;
        RoomOptions.PlayerTtl = 120000;
        RoomOptions.EmptyRoomTtl= 0;
        RoomOptions.CleanupCacheOnLeave = false;

        PhotonNetwork.CreateRoom(RoomName, RoomOptions);

    }
  
    public void JoinRoom()
    {
        //if (PhotonNetwork.InRoom == false)
        //{
        //    PhotonNetwork.RejoinRoom(JoinInput.text);
        //}
        //else
        //{
        //    PhotonNetwork.JoinRoom(JoinInput.text);
        //}
    }

    #endregion

    #region Callbacks

    public override void OnConnectedToMaster()
    {
        if(!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnCreatedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.Name + "  is Connected");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("We are in a room");
        numConnected = PhotonNetwork.PlayerList.Length;

        PhotonNetwork.LoadLevel("Playground");
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        
    }

    #endregion

}
