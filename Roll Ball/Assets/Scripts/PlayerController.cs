using UnityEngine;
using UnityEngine.UI;

//  Responsible for player movement
public class PlayerController : MonoBehaviour {
    //  Variables
    public float speed; //  movement speed of the player
    public Text countText;  //  on screen counter of the score
    public Text winText;    //  message to the user

    private Rigidbody rb;
    private int count;  //  score count

    //  Initialization
    void Start() {
        rb = GetComponent<Rigidbody>(); //  reference to the player rigidbody
        count = 0;  //  set default value
        winText.text = "";  //  set default value
        SetCountText(); //  update text
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

    //  Is called when the collider other enters the trigger
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up")) {   //  check if collision that was made is of tag Pick Up
            other.gameObject.SetActive(false);  //  disable the gameobject
            ++count;    //  increment count
            SetCountText(); //  update text
        }   //  if
    }   //  OnTriggerEnter()

    //  Update text
    void SetCountText() {
        countText.text = "Count: " + count.ToString();  //  update count

        if (count >= 8)    //  check if score above or equal to
            winText.text = "You Win!";  //  if yes then display win message
    }   //  SetCountText()
}   //  PlayerController