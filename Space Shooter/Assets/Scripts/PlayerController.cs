using UnityEngine;

[System.Serializable]   //  make it visible in the inspector
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}   //  Boundary

public class PlayerController : MonoBehaviour {
    //  Variables
    public float speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }   //  Start()

    //  Called before physics step
    void FixedUpdate() {
        //  Input from user
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //  get vector3 for movement
        rb.velocity = movement * speed; //  set velocity

        //  Restrict player movement, so that player doesn't move beyond game area
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        //  Adjust tilt of the ship
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }   //  FixedUpdate()
}   //  PlayerController

