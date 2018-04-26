using UnityEngine;

//  Class responsible for rotation of a gameobject
public class Rotate : MonoBehaviour {

    //  Update gets called each frame
    void Update() {
        //  Use transform to rotate object this script is attached to
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }   //  Update()
}   //  Rotate