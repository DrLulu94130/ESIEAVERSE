using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInteract : MonoBehaviour
{
    public Quaternion localRot1;
    public Quaternion localRot2;
    public bool Open;

    Transform tf;

    private void Awake()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Open )
        {
            tf.rotation = localRot2;
        }
        else
        {
            tf.rotation = localRot1;
        }
    }
}
