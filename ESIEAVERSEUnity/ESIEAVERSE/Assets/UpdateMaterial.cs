
using Photon.Pun;
using UnityEngine;
using static UnityEngine.Random;

public class UpdateMaterial : MonoBehaviour
{
    PhotonView view;
    Texture currentMaterial;
    private void Start()
    {
        Vector3 color = new Vector3(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            view.RPC("setColor", RpcTarget.AllBuffered, color);
        }
    }

    [PunRPC]
    public void setColor(Vector3 randomColor)
    {
        Color bColor = new Color(randomColor.x / 255f, randomColor.y / 255f, randomColor.z / 255f);
        gameObject.GetComponent<Renderer>().material.color = bColor;
    }
}
