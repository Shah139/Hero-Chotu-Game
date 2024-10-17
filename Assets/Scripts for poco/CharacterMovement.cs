using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : PocoScripts
{
    private float moveX, moveY;
    private Camera mainCam;
    private Vector2 mousePosition;
    private Vector2 direction;
    private Vector3 tempScale;

    private Animator anim;
    private PlayerWeaponManager playerWeaponManager;

    // Initialize components
    protected override void Awake()
    {
        base.Awake();
        mainCam = Camera.main;  // Get the main camera
        anim = GetComponent<Animator>();  // Get the animator for animation handling
        playerWeaponManager = GetComponent<PlayerWeaponManager>();
    }

    // FixedUpdate for physics-based movement
    private void FixedUpdate()
    {
        // Get keyboard input for movement
        moveX = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);  // Horizontal movement (A/D or Left/Right arrow keys)
        moveY = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);    // Vertical movement (W/S or Up/Down arrow keys)

        // Handle movement using the keyboard
        HandleMovement(moveX, moveY);

        // Handle turning based on mouse pointer
        HandlePlayerTurning();
    }

    // Handles character turning based on mouse pointer
    void HandlePlayerTurning()
    {
        // Get the mouse position in world coordinates
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        
        // Calculate the direction vector (from character position to mouse position)
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;

        // Update the animation and sprite flip based on mouse direction (x, y)
        HandlePlayerAnimation(direction.x, direction.y);
    }

    // Updates player animation and flips the sprite accordingly
    void HandlePlayerAnimation(float x, float y)
    {
        // Round the direction values to integers (for simplicity in animation)
        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);
        
        // Get current scale (used for flipping the character)
        tempScale = transform.localScale;

        // Flip the character based on mouse direction (x-axis)
        if (x > 0) 
            tempScale.x = Mathf.Abs(tempScale.x);  // Face right
        else if (x < 0) 
            tempScale.x = -Mathf.Abs(tempScale.x);  // Face left
        
        // Apply the new scale to flip the character
        transform.localScale = tempScale;

        x = Mathf.Abs(x);
        

        // Set animation parameters for movement direction
        anim.SetFloat(TagManager.FACE_X_ANIMATION_PARAMETER, x);
        anim.SetFloat(TagManager.FACE_Y_ANIMATION_PARAMETER, y);
        ActivateWeaponForSide(x,y);
    }
    void ActivateWeaponForSide(float x,float y){
        if(x==1f && y==0f) playerWeaponManager.ActivateGun(0);
        if(x==0f && y==1f) playerWeaponManager.ActivateGun(1);
        if(x==0f && y== -1f) playerWeaponManager.ActivateGun(2);
        if(x==1f && y==1f) playerWeaponManager.ActivateGun(3);
        if(x==1f && y==-1f) playerWeaponManager.ActivateGun(4);

    }
}
