using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PointCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        gameObject.transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            FindAnyObjectByType<LevelManager>().colectedPoint++;
            Destroy(gameObject);
        }
    }
}
