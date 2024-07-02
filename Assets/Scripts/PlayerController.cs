using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    float xInput;
    [SerializeField] private float speed;
    [SerializeField] private float maxPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) 
        {
            Move();
        }
    }
    private void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*speed*xInput);
        float xPos =  Mathf.Clamp(transform.position.x,-maxPos,maxPos);
        transform.position = new Vector3(xPos,transform.position.y,transform.position.z);
    }
}
