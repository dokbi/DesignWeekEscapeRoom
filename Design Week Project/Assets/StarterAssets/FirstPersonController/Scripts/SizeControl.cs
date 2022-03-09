using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SizeControl : MonoBehaviour
{
    public float changeSpeed;
    public PlayerSizeData minSize;
    public PlayerSizeData nomSize;
    public PlayerSizeData maxSize;
    public CinemachineVirtualCamera _cameraControl;

    private StarterAssetsInputs _input;
    private FirstPersonController _controller;
    private CharacterController _controllerActual;
    private PlayerSizeData[] Sizes;
    private float currentScale;
    private int targetSizeIndex;

    // Start is called before the first frame update
    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _controller = GetComponent<FirstPersonController>();
        _controllerActual = GetComponent<CharacterController>();
        Sizes = new PlayerSizeData[3];
    }

    void Start()
    {
        Sizes[0] = minSize;
        Sizes[1] = nomSize;
        Sizes[2] = maxSize;
        targetSizeIndex = 1;
        currentScale = Sizes[targetSizeIndex].scale;

        _cameraControl.m_Lens.FieldOfView = Sizes[targetSizeIndex].FOV;

        _controller.MoveSpeed = Sizes[targetSizeIndex].speed;
        _controller.SprintSpeed = Sizes[targetSizeIndex].sprintSpeed;
        _controller.JumpHeight = Sizes[targetSizeIndex].jumpHeight;
        _controller.GroundedOffset = Sizes[targetSizeIndex].groundedOffSet;
        _controller.GroundedRadius = Sizes[targetSizeIndex].groundedRadius;

        _controllerActual.slopeLimit = Sizes[targetSizeIndex].slopeLimit;
        _controllerActual.stepOffset = Sizes[targetSizeIndex].stepOffset;

        
    }

    // Update is called once per frame
    void Update()
    {
        switch (_input.scale)
        {
            case StarterAssetsInputs.Scale.ScaleUp:
                targetSizeIndex++;
                _input.scale = StarterAssetsInputs.Scale.NOP;
                break;
            case StarterAssetsInputs.Scale.ScaleDown:
                targetSizeIndex--;
                _input.scale = StarterAssetsInputs.Scale.NOP;
                break;
            case StarterAssetsInputs.Scale.NOP:
                break;
        }
        targetSizeIndex = Mathf.Clamp(targetSizeIndex, 0, 2);
        ChangeSize();
    }

    void ChangeSize()
    {
        if (currentScale != Sizes[targetSizeIndex].scale)
        {
            currentScale = Mathf.Lerp(currentScale, Sizes[targetSizeIndex].scale, changeSpeed * Time.deltaTime);
            transform.localScale = Vector3.one * currentScale;

            _cameraControl.m_Lens.FieldOfView = Mathf.Lerp(_cameraControl.m_Lens.FieldOfView, Sizes[targetSizeIndex].FOV, changeSpeed * Time.deltaTime);

            _controller.MoveSpeed = Mathf.Lerp(_controller.MoveSpeed, Sizes[targetSizeIndex].speed, changeSpeed * Time.deltaTime);
            _controller.SprintSpeed = Mathf.Lerp(_controller.SprintSpeed, Sizes[targetSizeIndex].sprintSpeed, changeSpeed * Time.deltaTime);
            _controller.JumpHeight = Mathf.Lerp(_controller.JumpHeight, Sizes[targetSizeIndex].jumpHeight, changeSpeed * Time.deltaTime);
            _controller.GroundedOffset = Mathf.Lerp(_controller.GroundedOffset, Sizes[targetSizeIndex].groundedOffSet, changeSpeed * Time.deltaTime);
            _controller.GroundedRadius = Mathf.Lerp(_controller.GroundedRadius, Sizes[targetSizeIndex].groundedRadius, changeSpeed * Time.deltaTime);

            _controllerActual.slopeLimit = Mathf.Lerp(_controllerActual.slopeLimit, Sizes[targetSizeIndex].slopeLimit, changeSpeed * Time.deltaTime);
            _controllerActual.stepOffset = Mathf.Lerp(_controllerActual.stepOffset,Sizes[targetSizeIndex].stepOffset, changeSpeed* Time.deltaTime);
        }
    }
}
