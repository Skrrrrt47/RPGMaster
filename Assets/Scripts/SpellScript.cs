using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour
{
    private Rigidbody2D myrigidBody;

    [SerializeField]
    private float speed;

    public Transform MyTarget {get; set; }

    // Start is called before the first frame update
    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if (MyTarget != null)
        {
            Vector2 direction = MyTarget.position - transform.position;

            myrigidBody.velocity = direction.normalized * speed;

            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  {
        if (collision.tag == "Ennemy")
        {
            GetComponent<Animator>().SetTrigger("impact");
            myrigidBody.velocity = Vector2.zero;
            MyTarget = null;
        }
    }
}

