using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotaiton;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotaiton * Time.deltaTime);
    }
}
