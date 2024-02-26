using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

     public Transform PlayerCamera;
    public Rigidbody PlayerBody;
    [Space]
     public float Speed;
     public float Sensitivity; 
    public float Jumpforce;

    // Start is called before the first frame update
  
  private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); 
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); 

        MoveplayerCamera();
        MovePlayer();
    }
  
  private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

           if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }
    }
    // Update is called once per frame
    private void MoveplayerCamera()
    {
      xRot -= PlayerMouseInput.y * Sensitivity;
      
      transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
      PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

    }
    
    
    void Start()
    {
        
    }

}
