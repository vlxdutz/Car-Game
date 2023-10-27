using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float forwardInput;
    private float horizontalInput;
    public int speed = 15;
    public int rotSpeed; 

    public static Player playerScript;
    // Referinta la componenta Rigidbody
    Rigidbody RB;

    public float carCurrentSpeed;
    public float carMaxSpeed;

    // Referinte pentru WheelCollider
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider rearLeft;
    public WheelCollider rearRight;

    // Referinte pentru Wheel Transform
    public Transform frontLeftT;
    public Transform frontRightT;
    public Transform rearLeftT;
    public Transform rearRightT;

    private bool brake;

    // Start is called before the first frame update
    void Start() {
        playerScript = this;

        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        getInput();
        Accelerate();
        Steer();
        WheelsUpdate();
    }

    void getInput() {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        brake = Input.GetButton("Jump");

        if(Input.GetKey(KeyCode.R)) {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        // transform.Translate(Vector3.forward * forwardInput * speed * Time.deltaTime);
        // transform.Rotate(Vector3.up * horizontalInput * rotSpeed * Time.deltaTime);
    }

    void Accelerate() {
        rearLeft.motorTorque = forwardInput  * speed;
        rearRight.motorTorque = forwardInput  * speed;

        if(brake) {
          rearLeft.brakeTorque = 1000;
          rearRight.brakeTorque = 1000;
        } else {
          rearLeft.brakeTorque = 0;
          rearRight.brakeTorque = 0;
        }
        
        // Calculam viteza reala a masinii
        carCurrentSpeed = RB.velocity.magnitude * 10f / carMaxSpeed;
    }

    void Steer() {
        frontLeft.steerAngle = horizontalInput * rotSpeed;
        frontRight.steerAngle = horizontalInput * rotSpeed;
    }

    void WheelsUpdate() {
        getSingleWheel(frontLeft, frontLeftT);
        getSingleWheel(frontRight, frontRightT);
        getSingleWheel(rearLeft, rearLeftT);
        getSingleWheel(rearRight, rearRightT);
    }

    void getSingleWheel(WheelCollider wheel, Transform wheelPos) {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        wheel.GetWorldPose(out pos, out rot);

        wheelPos.position = pos;
        wheelPos.rotation = rot;
    }
}
