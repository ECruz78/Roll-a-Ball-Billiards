using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
	public float speed = 0;
	public TextMeshProUGUI countText;
	
	private Rigidbody rb;
	private int count;
	private float movementX;
	private float movementY;
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		count = 0;
		
		SetCountText();
	}
	
	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		
		//Store the X and Y components of the movement. 
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
	
	void FixedUpdate()
	{
		Vector3 movement = new Vector3( movementX, 0.0f, movementY);
		
		rb.AddForce(movement * speed);
	}
	
	void OnTriggerEnter(Collider other)
	{
			if(other.gameObject.CompareTag("PickUp"))
			{
			other.gameObject.SetActive(false);
			count = count + 1;
			
			SetCountText();
			}
			
			else if(other.gameObject.CompareTag("BlackHole"))
			{
				Destroy(gameObject);
				Debug.Log("Player disappeared into the black hole!");
				
		}
	}
}

