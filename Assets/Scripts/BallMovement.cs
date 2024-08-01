using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.2f;
    private Rigidbody rb;
    [Space(30)] public UnityEvent onFinishLevel;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontal, 0, vertical) * speed);
 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Finish"))
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            onFinishLevel.Invoke();
        }
    }


}
