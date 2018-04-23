using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text lossText;

    private Rigidbody rb;
    private int count;
    private Vector3 jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        lossText.text = "";
        jumpForce.x = 0;
        jumpForce.y = 300;
        jumpForce.z = 0;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive (false);
            count++;
            SetCountText();
            if (count >= 11)
            {
                winText.text = "You Win!";
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            lossText.text = "You Lost!";
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/11";
    }
}


//Destroy(other.gameObject);
