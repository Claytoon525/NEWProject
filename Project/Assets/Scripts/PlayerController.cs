using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager Manager;
    public float moveSped = 25;
    public float rotateSped = 75f;
    public float jumpForce = 1;
    public Rigidbody rig;
    public int health = 100;

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Vector3 rotation = Vector3.up * x;
        //Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSped;
        dir.y = rig.velocity.y;
        rig.velocity = dir;
        //rig.MoveRotation(rig.rotation * angleRot);
    }
    // Start is called before the first frame update

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 1.5f)) {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    public void takeDamadge(int dmg)
    {
        
        health -= dmg;

        if(health <= 0)
        {
            Manager.endGame();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //if (health <= 0)
    }
}
