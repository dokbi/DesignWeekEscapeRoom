using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SizeControl : MonoBehaviour
{
    public float changeSpeed;
    public float maximumAllowedScale = 3;
    public float currentScale;
    public PlayerSizeData nomimalSize;
    public PlayerSizeData targetSize;
    public CinemachineVirtualCamera _cameraControl;

    private FirstPersonController _controller;
    private CharacterController _controllerActual;
    

    // Start is called before the first frame update
    private void Awake()
    {
        _controller = GetComponent<FirstPersonController>();
        _controllerActual = GetComponent<CharacterController>();
    }

    void Start()
    {
        currentScale = nomimalSize.scale;

        _cameraControl.m_Lens.FieldOfView = nomimalSize.FOV;

        _controller.MoveSpeed = nomimalSize.speed;
        _controller.SprintSpeed = nomimalSize.sprintSpeed;
        _controller.JumpHeight = nomimalSize.jumpHeight;
        _controller.GroundedOffset = nomimalSize.groundedOffSet;
        _controller.GroundedRadius = nomimalSize.groundedRadius;

        _controllerActual.slopeLimit = nomimalSize.slopeLimit;
        _controllerActual.stepOffset = nomimalSize.stepOffset;


    }

    // Update is called once per frame
    void Update()
    {
        if (currentScale != targetSize.scale)
        {
            ChangeSize();
        }
    }

    void ChangeSize()
    {

        currentScale = Mathf.Lerp(currentScale, targetSize.scale, changeSpeed * Time.deltaTime);
        transform.localScale = Vector3.one  * currentScale;

        _cameraControl.m_Lens.FieldOfView = Mathf.Lerp(_cameraControl.m_Lens.FieldOfView, targetSize.FOV, changeSpeed * Time.deltaTime);

        _controller.MoveSpeed = Mathf.Lerp(_controller.MoveSpeed, targetSize.speed, changeSpeed * Time.deltaTime);
        _controller.SprintSpeed = Mathf.Lerp(_controller.SprintSpeed, targetSize.sprintSpeed, changeSpeed * Time.deltaTime);
        _controller.JumpHeight = Mathf.Lerp(_controller.JumpHeight, targetSize.jumpHeight, changeSpeed * Time.deltaTime);
        _controller.GroundedOffset = Mathf.Lerp(_controller.GroundedOffset, targetSize.groundedOffSet, changeSpeed * Time.deltaTime);
        _controller.GroundedRadius = Mathf.Lerp(_controller.GroundedRadius, targetSize.groundedRadius, changeSpeed * Time.deltaTime);

        _controllerActual.slopeLimit = Mathf.Lerp(_controllerActual.slopeLimit, targetSize.slopeLimit, changeSpeed * Time.deltaTime);
        _controllerActual.stepOffset = Mathf.Lerp(_controllerActual.stepOffset, targetSize.stepOffset, changeSpeed * Time.deltaTime);

    }

    public bool SetTargetSize(PlayerSizeData _targetSize)
    {
        if (_targetSize.scale <= maximumAllowedScale)
        {
            targetSize = _targetSize;
            return true;
        }
        return false;
    }
}
