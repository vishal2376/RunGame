using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float enemyDeadZone = -1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * (speed * Time.deltaTime);

        if (transform.position.z <= enemyDeadZone)
        {
            Destroy(gameObject);
        }
    }
}