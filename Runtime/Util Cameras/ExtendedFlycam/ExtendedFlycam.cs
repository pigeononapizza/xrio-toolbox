using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExtendedFlycam : MonoBehaviour
{

    /*
	EXTENDED FLYCAM
		Desi Quintans (CowfaceGames.com), 17 August 2012.
		Based on FlyThrough.js by Slin (http://wiki.unity3d.com/index.php/FlyThrough), 17 May 2011.
 
	LICENSE
		Free as in speech, and free as in beer.
 
	FEATURES
		WASD/Arrows:    Movement
		          Q:    Climb
		          E:    Drop
                      Shift:    Move faster
                    Control:    Move slower
                        End:    Toggle cursor locking to screen (you can also press Ctrl+P to toggle play mode on and off).
	*/

    public float cameraSensitivity = 90;
    float cameraSensitivity_Default;

    public float climbSpeed = 4;
    float climbSpeed_Default;

    public bool enableMouseToClimb = true;
    bool enableMouseToClimb_Default;

    public float normalMoveSpeed = 10;
    float normalMoveSpeed_Default;

    public float slowMoveFactor = 0.25f;
    float slowMoveFactor_Default;

    public float fastMoveFactor = 3;
    float fastMoveFactor_Default;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public bool enabledMovement = true;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        #region set default states 
        cameraSensitivity_Default = cameraSensitivity;
        climbSpeed_Default = climbSpeed;
        enableMouseToClimb_Default = enableMouseToClimb;
        normalMoveSpeed_Default = normalMoveSpeed;
        slowMoveFactor_Default = slowMoveFactor;
        fastMoveFactor_Default = fastMoveFactor;
        #endregion
    }

    //ask the saved gamecontrol what the settings should be
    public void LoadCameraSettings()
    {
        Debug.Log("ExtendedFlycam.LoadCameraSettings() being called");
        GameControl.control.Load();
        cameraSensitivity = GameControl.control.cameraSensitivity;
        climbSpeed = GameControl.control.climbSpeed;
        enableMouseToClimb = GameControl.control.enableMouseToClimb;
        normalMoveSpeed = GameControl.control.normalMoveSpeed;
        slowMoveFactor = GameControl.control.slowMoveFactor;
        fastMoveFactor = GameControl.control.fastMoveFactor;
    }

    public void DefaultSettings()
    {
        GameControl.control.cameraSensitivity = cameraSensitivity_Default;
        GameControl.control.climbSpeed = climbSpeed_Default;
        GameControl.control.enableMouseToClimb = enableMouseToClimb_Default;
        GameControl.control.normalMoveSpeed = normalMoveSpeed_Default;
        GameControl.control.slowMoveFactor = slowMoveFactor_Default;
        GameControl.control.fastMoveFactor = fastMoveFactor_Default;
        GameControl.control.Save();

    }

    void Update()
    {
        if (enabledMovement)
        {
            rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
            }
            else
            {
                transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
                transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            }

            if (enableMouseToClimb)
            {
                if (Input.GetMouseButton(0)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
                if (Input.GetMouseButton(1)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }
            }
            if (Input.GetKey(KeyCode.E)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
            if (Input.GetKey(KeyCode.Q)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }
        }


        if (Input.GetKeyDown(KeyCode.End))
        {
            //Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Confined;
        }
    }
}
