using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public Rigidbody rb;
    public float moveSpeed;
    private Vector2 beginPos;
    private Vector2 endPos;
    public Vector2 resultPos;
    public float coloredTiles;

    void Start()
    {
        coloredTiles = 0;
    }

    // Update is called once per frame
    void Update()
    {
        BallMovementControl();
        if(gm.tileNumber == coloredTiles) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

    }

    void BallMovementControl() {
        if(Input.GetMouseButtonDown(0)) {
            beginPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        } else if(Input.GetMouseButtonUp(0)) {
            endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            resultPos = new Vector2(
                endPos.x - beginPos.x,
                endPos.y - beginPos.y
            );
            resultPos.Normalize();
            BallMove();
        }
    }

    void BallMove() {
        if(resultPos.y > 0 && resultPos.x > -0.5f && resultPos.x < 0.5f) {
            rb.velocity = Vector3.right * moveSpeed;
        } else if(resultPos.y < 0 && resultPos.x > -0.5f && resultPos.x < 0.5f) {
            rb.velocity = Vector3.left * moveSpeed;
        } else if(resultPos.x < 0 && resultPos.y > -0.5f && resultPos.y < 0.5f) {
            rb.velocity = Vector3.forward * moveSpeed;
        } else if(resultPos.x > 0 && resultPos.y > -0.5f && resultPos.y < 0.5f) {
            rb.velocity = Vector3.back * moveSpeed;            
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.GetComponent<MeshRenderer>().material.color != Color.red) {
            if(other.gameObject.tag == "Ground") {
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                coloredTiles++;
            }
        }
    }
}
