using UnityEngine;
using System.Collections;

public class SimpleAiFollower : MonoBehaviour {

    public Transform target;
    public float speed = 3f;
    public float targetDistance = 0.1f;

    void Update()
    {
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > targetDistance)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

}
