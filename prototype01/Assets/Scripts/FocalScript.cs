using UnityEngine;

public class FocalScript : MonoBehaviour
{
    Vector3 mousePosition;
    public float speed = 15.0f;
    public float deltaBounds = 10;


    public bool blockCameraOnStart = true;


    private void Start()
    {
        //_mCameraTransform = GetComponent<Transform>();
        if (blockCameraOnStart)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Input.mousePosition;
    }

    private void LateUpdate()
    {
        ////check if on the right edge
        //if(Input.mousePosition.x >= Screen.width - deltaBounds)
        //{
        //    transform.position += transform.right * Time.deltaTime * speed;
        //}

        //// check if on the left edge
        //if(Input.mousePosition.x <= 0 +deltaBounds)
        //{
        //    transform.position -= transform.right * Time.deltaTime *speed;
        //}

        //// check if on the top edge
        //if(Input.mousePosition.y >= Screen.height - deltaBounds)
        //{
        //    transform.position += transform.forward * Time.deltaTime * speed;
        //}

        //// check if on the bottom edge
        //if(Input.mousePosition.y <= 0 + deltaBounds)
        //{
        //    transform.position -= transform.forward * Time.deltaTime * speed;
        //}
        //Debug.Log(transform.position.y);
    }
}
