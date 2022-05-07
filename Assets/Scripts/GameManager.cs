using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tiles;
    public float tileNumber;
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Ground");
        tileNumber = tiles.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
