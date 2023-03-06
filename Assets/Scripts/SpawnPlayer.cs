using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        // Instantiate(playerPrefab, transform.position, Quaternion.identity);
        Debug.Log(playerPrefab.name);
        PhotonNetwork.Instantiate(playerPrefab.name, transform.position, Quaternion.identity);
    }
}