using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public GameObject player;

    private Rigidbody rb;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        direction = (transform.position - player.transform.position);
    }
	
	// Update is called once per frame
	private void FixedUpdate () {
        direction = -1 * (transform.position - player.transform.position);

        rb.AddForce(direction * speed);
    }
}
