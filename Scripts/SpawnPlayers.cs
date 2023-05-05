using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject PlayerPrefeb;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    private void Start()
    {
        Vector2 Position= new Vector2(Random.Range(minX,minY),Random.Range(maxX,maxY));
        PhotonNetwork.Instantiate(PlayerPrefeb.name, Position, Quaternion.identity);
    }
}
