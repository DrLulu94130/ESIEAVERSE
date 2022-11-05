
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float FallSpeed;

    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x,0,z);

        Walk(dir);

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector3 ( body.velocity.x , JumpHeight , body.velocity.z);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            body.velocity = new Vector3 ( body.velocity.x , 0 , body.velocity.z);
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            transform.position = new Vector3(0,2,0) ;
            body.velocity = Vector3.zero ;
            body.angularVelocity = Vector3.zero ;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            body.velocity = new Vector3 ( body.velocity.x , FallSpeed , body.velocity.z);
        }
    }

    private void Walk(Vector3 dir)
    {
        body.velocity = (new Vector3(body.velocity.x + dir.x * Speed , body.velocity.y , body.velocity.z + dir.z * Speed));
    }
}
