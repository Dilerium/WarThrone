using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))] ///// REQUIRE

public class FirstPersonController : MonoBehaviour {

    public float movementspeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float verticalAngleLimit = 60.0f;
    public float jumpSpeed = 5f;

    float verticalRotation = 0;
    float verticalVelocity = 0;

    Camera firstPersonCamera;
    Inventory inventoryScript; //instantiate ///// REQUIRE
    GameObject inventory; ///// REQUIRE
    bool showInventory = false; ///// REQUIRE


    CharacterController characterController;
    // Use this for initialization
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Canvas");///// REQUIRE
        inventoryScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>(); ///// REQUIRE
        inventory.SetActive(false);///// REQUIRE
        
        
        firstPersonCamera = Camera.main.GetComponent<Camera>();
        characterController = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i")) // activate inventory
        {
            showInventory = !showInventory;
            inventory.SetActive(showInventory);

        }

        //important for project part, when i click to item
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                float distance = Vector3.Distance(hit.transform.position, this.transform.position);
                //Debug.Log(distance);

                if(hit.transform.tag == "Item" && distance <= 3)
                {
                    //Debug.Log("hit");
                    inventoryScript.addExistingItem(hit.transform.GetComponent<DroppedItem>().item);
                    Destroy(hit.transform.gameObject);

                }///// REQUIRE
            }///// REQUIRE
        }///// REQUIRE

        


















        //Rotation
        float rotationLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotationLeftRight, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalAngleLimit, verticalAngleLimit);
        firstPersonCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementspeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementspeed;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            verticalVelocity = jumpSpeed;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

        characterController.Move(speed * Time.deltaTime);




	}
}
