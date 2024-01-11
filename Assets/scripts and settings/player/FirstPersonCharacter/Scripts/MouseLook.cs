using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform body;

    //Параметры мыши
    [Header("Mouse")]
    [SerializeField, Range(0f, 250f)] float _sensitivityX;
    [SerializeField, Range(0f, 250f)] float _sensitivityY;

    float _mouseX;
    float _mouseY;
    float _xRotation;

    //параметры ограничения поворота по оси Y
    [Header("Clamp")]
    [SerializeField, Range(0f, -90f)] float _min;
    [SerializeField, Range(0f, 90f)] float _max;

    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensitivityX * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivityY * Time.deltaTime;

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, _min, _max);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        body.Rotate(new Vector3(0f, _mouseX, 0f));
    }


}

