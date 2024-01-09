using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody thisRigidBody;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;

    private float jumpCoolDown = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update CoolDown
        jumpCoolDown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCoolDown <= 0 && isGameActive;

        //Jump!
        if(canJump) {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if(jumpInput) {
                Jump();
            }
        }

        // Toggle gravity
        thisRigidBody.useGravity = isGameActive;
    }

    void OnCollisionEnter(Collision other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other) {
        bool isSensor = other.CompareTag("Sensor");
        if(isSensor) {
            //Score increases in 1
            GameManager.Instance.score ++;
            Debug.Log("Scored: " + GameManager.Instance.score);
        } else {
            //Game Over
            GameManager.Instance.EndGame();

        }
    }

    private void Jump() {
        // REset CoolDown
        jumpCoolDown = jumpInterval;

        //Apply Force
        thisRigidBody.velocity = Vector3.zero;
        thisRigidBody.AddForce(new Vector3(0,10,0), ForceMode.Impulse);

    }
}
