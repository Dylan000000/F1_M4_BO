using UnityEngine;
public class Rotatep1 : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public float rotationAmount = 180.0f;
    public bool turnleft = true;
    public bool turnright = true;
    void Update()
    {
        // Check for left or right key input
        if (Input.GetKeyDown(KeyCode.LeftArrow) && turnleft == true )
        {
            transform.Rotate(0, -rotationAmount, 0);
            turnleft= false;
            turnright = true; 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && turnright == true )
        {
            transform.Rotate(0, rotationAmount, 0);
            turnright= false;
            turnleft= true;
        }
    }
}