
using Photon.Pun;
using UnityEngine;
using static UnityEngine.Random;

public class UpdateMaterial : MonoBehaviour
{
    public Material M;
    PhotonView view;
    void Update()
    {
        view = GetComponent<PhotonView>();
        if ((view.IsMine))
        {
            M = gameObject.GetComponent<Renderer>().material;
            view.RPC("setTexture", RpcTarget.All);
        }
    }

    [PunRPC]
    public void setTexture()
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = M.mainTexture;
    }
}


/* 
 * 
 * using Photon.Pun;
using UnityEngine;
using static UnityEngine.Random;

public class UpdateMaterial : MonoBehaviour
{
    public Texture t;
    PhotonView view;
    void Update()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            view.RPC("setColor", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    public void setColor()
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = t;
    }
} */