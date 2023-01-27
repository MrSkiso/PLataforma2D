using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed;

    public bool MoveToA = false;
    public bool MoveToB = false;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveToA = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveToA)
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);

            if(transform.position == PointA.position)
            {
                MoveToA = false;
                MoveToB = true;
            }
        }

        if (MoveToB)
        {
            rb.transform.position = Vector2.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);

            if (transform.position == PointB.position)
            {
                MoveToA = true;
                MoveToB = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
