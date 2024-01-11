// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform targetObject;
    public float speed = 5f;
    public Vector3 targetPosition;

    void OnTriggerEnter(Collider other)
    {
        if (targetObject != null)
        {
            targetObject.position = targetPosition;
        }
        if (targetObject != null)
        {
            Vector3 direction = targetObject.position - transform.position;
            if (direction.magnitude > 0.1f) 
            {
                Vector3 normalizedDirection = direction.normalized;
                transform.position += normalizedDirection * speed * Time.deltaTime;
            }
        }
    }
}
