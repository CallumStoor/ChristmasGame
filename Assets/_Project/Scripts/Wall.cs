using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] float speed = 2;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Vector3.right * Time.deltaTime;
    }

}
