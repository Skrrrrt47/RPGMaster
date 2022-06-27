using UnityEngine;
using System;
using System.Collections;

public abstract class character : MonoBehaviour
{
    [SerializeField]
    private float speed;

    protected Vector2 direction;

    private Rigidbody2D myRigidbody;

    protected virtual void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
    }

    private void FixedUpdate() 
    {
        Move();
    }

    public void Move() {
        myRigidbody.velocity = direction.normalized * speed;
    }

    
}
