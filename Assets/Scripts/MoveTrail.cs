using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {
    
    public int moveSpeed = 150;

    void Update() {
        
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
	}
}
