using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class MatSync : MonoBehaviour, IPunObservable
{
    public int matID;
    public Material[] mats;


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
            this.GetComponent<MeshRenderer>().material = mats[matID];
            Debug.Log("mat set to " + GetComponent<MeshRenderer>().material.name);
        
    }
}
