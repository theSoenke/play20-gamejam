using UnityEngine;

public class DiscoBall : MonoBehaviour
{
    public float rotationSpeed = -20f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));   
    }
}
