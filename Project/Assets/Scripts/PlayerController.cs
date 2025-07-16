using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class PlayerController : MonoBehaviour
{
    public GameManager Manager;
    public float moveSped = 25;
    public float rotateSped = 75f;
    public float jumpForce = 1;
    public Rigidbody rig;
    public int health = 100;

    //public Animator anim;

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Vector3 rotation = Vector3.up * x;
        //Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSped;
        dir.y = rig.velocity.y;
        rig.velocity = dir;
        //if(Mathf.Abs(x) > 0.1f || Math.Abs(z) > 0.1)
        //{
        //    anim.setBool("isRunning", true);
        //}
        //else{
        //    anim.SetBool("isRunning", false);
        //}
        //rig.MoveRotation(rig.rotation * angleRot);
    }
    // Start is called before the first frame update

    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 1.5f)) {
            //anim.SetTrigger("isJumping");
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //enabled = false;
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
      0  
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject,name = "MovingSpike")
        {
            health -= 10;
        }
    }
}
