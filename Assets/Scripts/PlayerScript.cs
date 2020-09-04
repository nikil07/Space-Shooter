using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] Joystick joystick;
    [SerializeField] float horizontalSpeed = 2f;
    [SerializeField] float verticalSpeed = 2f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] float projectileSpeed = 2f;

    [SerializeField] GameObject laser;

    float xMin, xMax, yMin, yMax;
    float horizontalInput, verticalInput;

    Coroutine firingCoRoutine;


    // Start is called before the first frame update
    void Start()
    {
        setupBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        
        handleMovement();
        fire();
    }

    IEnumerator fireContinuosly() {

        while (true) {
        GameObject laserGameObject = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        laserGameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        yield return new WaitForSeconds(0.1f);
        }
        
    }

    private void fire() {
        if (Input.GetButtonDown("Fire1")) {
            firingCoRoutine = StartCoroutine(fireContinuosly());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoRoutine);
        }
    
    }

    private void setupBoundaries() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void handleMovement() {

        // Handling both mobile joystick input and keyboard input
        if (joystick.Horizontal == 0)
            horizontalInput = Input.GetAxis("Horizontal");
        else
            horizontalInput = joystick.Horizontal;

        if (joystick.Vertical == 0)
            verticalInput = Input.GetAxis("Vertical");
        else
            verticalInput = joystick.Vertical;

        float movementX = Mathf.Clamp(transform.position.x + horizontalInput * horizontalSpeed * Time.deltaTime, xMin, xMax);
        float movementY = Mathf.Clamp(transform.position.y + verticalInput * verticalSpeed * Time.deltaTime, yMin,yMax);
        
        transform.position = new Vector2(movementX, movementY);
    }
}
