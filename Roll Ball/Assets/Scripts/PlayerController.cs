using UnityEngine;

//  Responsible for player movement
public class PlayerController : MonoBehaviour {
    //  Variables
    public float speed; //  movement speed of the player
    private Rigidbody rb;

    //  Initialization
    void Start() {
        rb = GetComponent<Rigidbody>(); //  reference to the player rigidbody
    }   //  Start()

    //  Called before physics calculations
    void FixedUpdate() {
        //  Input from the player
        float moveHorizontal = Input.GetAxis("Horizontal"); //  horizontal input
        float moveVertical = Input.GetAxis("Vertical"); //  vertical input

        //  Determine force in which player will move
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //  Add force to the rigidbody
        rb.AddForce(movement * speed);
    }   //  FixedUpdate()
}   //  PlayerController