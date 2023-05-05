using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviourPunCallbacks
{
    public GameObject PauseCanvas;
    public bool paused = false;
    void Start()
    {
        setPaused();
        //if(!PhotonNetwork.IsConnected)
        //{
        //    PhotonNetwork.LoadLevel("Lobby");
        //    return;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            paused = !paused;
            setPaused();
        }
    }

    private void setPaused()
    {
        PauseCanvas.SetActive(paused);
        Cursor.lockState = paused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = paused;
    }

    public void OnClickQuit()
    {
        PhotonNetwork.LeaveRoom();
        
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
       
    }
    
}
