using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour
{

    public bool right;
    public float maxUpRotation = 90f;
    public float maxDownRotation = -90f;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();     //Normaling vector meaning the sum of xyz == 1, whilst keeping proportion

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Find the angle in degreesrotZ += (rotZ < 0) ? 360f : 0f;

        if (rotZ < -90 || rotZ > 90)
        {
            if (!right)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                right = true;
                Debug.Log(right);
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 180);
        }
        else if (rotZ > -90 || rotZ < 90)
        {
            if (right)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                right = false;
                Debug.Log(right);
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        } 
    }
}

/*public class ArmRotation : MonoBehaviour {

	public int rotationOffset = 90;
    public Player player;
    public float maxUpRotation = 80f;
    public float maxDownRotation = -80f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

	// Update is called once per frame
	void Update () {

        if (player.facingRight == false)
        {
            rotationOffset = -180;
        } else if (player.facingRight == true)
        {
            rotationOffset = 0;
        }



		// subtracting the position of the player from the mouse position
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();		// normalizing the vector. Meaning that all the sum of the vector will be equal to 1
        
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;  // find the angle in degrees
        float rotY = Mathf.Atan2(difference.z, difference.x) * Mathf.Rad2Deg;   // find the angle in degrees

        rotZ += (rotZ < 0) ? 360f : 0f;
        if (rotZ + rotationOffset <= maxUpRotation || rotZ + rotationOffset >= maxDownRotation)
        {
            transform.rotation = Quaternion.Euler(0, rotationOffset, rotZ + rotationOffset);
        }
	}
}*/
