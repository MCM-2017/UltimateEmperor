
using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 20f;
    public float rotateCameraSpeed = 40f;
    public float cameraBorderReaction = 10f;

    private bool rightClicked = false;
    private float x;

    private float currentScrollFOV;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;
    private void Start()
    {
        currentScrollFOV = Camera.main.fieldOfView;
    }
    // Update is called once per frame

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            rightClicked = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            rightClicked = false;
        }
        if (rightClicked)
        {
            Vector3 rotation = transform.eulerAngles;
            rotation.y += Input.GetAxis("Mouse X") * rotateCameraSpeed * 5 * Time.deltaTime;

            transform.eulerAngles = rotation;
        }
        if (!rightClicked)
        {
            Vector3 position = transform.position;
            if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - cameraBorderReaction)
            {
                position.x -= cameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= cameraBorderReaction)
            {
                position.x += cameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - cameraBorderReaction)
            {
                position.z += cameraSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= cameraBorderReaction)
            {
                position.z -= cameraSpeed * Time.deltaTime;
            }
            
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            currentScrollFOV -= scroll *scrollSpeed * 100f * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, 40, 170);
            position.y = Mathf.Clamp(position.y, minY, maxY);
            position.z = Mathf.Clamp(position.z, 3, 33);
            transform.position = position;
            Camera.main.fieldOfView = Mathf.SmoothStep(Camera.main.fieldOfView, currentScrollFOV, 0.1f);
        }

    }
}
