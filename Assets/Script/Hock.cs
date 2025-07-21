using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WheelJoint2D))]
[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Hock : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private SolidObject[] _solidObject;

    private Camera _camera;
    private Vector3 _mousePosition;
    private Vector3 _tempPosition;
    private bool _check = true;
    private WheelJoint2D _joint2D;
    private LineRenderer _renderer;
    private RaycastHit2D _hit2D;

    private void Start()
    {
        _camera = Camera.main;
        _joint2D = GetComponent<WheelJoint2D>();
        _renderer = GetComponent<LineRenderer>();
        _joint2D.enabled = false;
        _renderer.positionCount = 0;
    }

    private void Update()
    {
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _hit2D = Physics2D.Raycast(_camera.transform.position, _mousePosition, Mathf.Infinity, _layerMask.value);

        if (Input.GetMouseButtonDown(0) && _check == true && _hit2D)
        {
            _joint2D.enabled = true;
            _joint2D.connectedAnchor = _hit2D.point;
            _renderer.positionCount = 2;
            _tempPosition = _hit2D.point;
            _check = false;
            _solidObject[0].ONGraund();
            _solidObject[1].ONGraund();
            _solidObject[2].ONGraund();
            _solidObject[3].ONGraund();
            _solidObject[4].ONGraund();
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            _joint2D.enabled = false;
            _check = true;
            _renderer.positionCount = 0;
            _solidObject[0].OFFGraund();
            _solidObject[1].OFFGraund();
            _solidObject[2].OFFGraund();
            _solidObject[3].OFFGraund();
            _solidObject[4].OFFGraund();
        }

        DrawLine();
    }

    private void DrawLine()
    {
        if (_renderer.positionCount > 0)
        {
            _renderer.SetPosition(0, transform.position);
            _renderer.SetPosition(1, _tempPosition);
        }
    }
}