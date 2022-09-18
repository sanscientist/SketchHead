using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    //Rigidbody 2D object - stored
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    [Header("Default Down Speed")]
    //downward speed of the object
    public float downSpeed = 20f;
    [Header("Default Movement Speed")]
    //movement speed of the object
    public float movementSpeed = 10f;
    [Header("Default Directional Movement Speed")]
    //movement direction of the object
    public float movement = 0f;
    //front text
    [Header("Score Text")]
    public Text scoreText;
    //score of game
    private float topScore = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //variable equals to component Rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        //movement = horizontal movement
        // times by the movement speed
        movement = Input.GetAxis("Horizontal")*movementSpeed;
        //if direction on x-axis < 0
        if(movement < 0)
        {
            //object faves to the left
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            //else if direction on x-axis > 0
            //object faces to the right
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(rb.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        //text for the score = top score
        scoreText.text = "Score:" + Mathf.Round(topScore).ToString();
    }
    void FixedUpdate()
    {
        //Vector2 is (x,y) velocity
        //equals to the velocity of the rigidbody2D
        Vector2 velocity = rb.velocity;
        //velocity of the x-axis equals to the direction movement on the x-axis
        //of the character
        velocity.x = movement;
        //Rigidbody 2D velocity = velocity of the object
        rb.velocity = velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //velocity with the downspeed
        rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
    }
}
