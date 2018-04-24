using UnityEngine;

public class CameraController : MonoBehaviour {
    //  Variables
    public GameObject player;   //  reference to the player
    private Vector3 offset; //  offset value of the camera

    //  Initialization
    void Start() {
        //  Set offset
        offset = transform.position - player.transform.position;
    }   //  Start()

    //  Guaranteed to run after all items were processed in update
    void LateUpdate() {
        //  Transform position of the camera to the position of the player + offset
        transform.position = player.transform.position + offset;
    }   //  LateUpdate()
}   //  CameraController