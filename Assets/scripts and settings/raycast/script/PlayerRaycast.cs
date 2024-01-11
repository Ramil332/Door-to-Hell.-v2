// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using UnityEngine;
using System.Collections;
using System.Threading;
using Unity.Burst.CompilerServices;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _raycastDistance = 2f;
    [SerializeField] private LayerMask _raycastLayerMask;
    [SerializeField] private DraggableObject _currentlyDraggedObject;
    [SerializeField] private float _draggableObjectDistance = 2f;
    [SerializeField] private GameObject Lkm;

    [SerializeField] private GameObject E;

    private void Start()
    {
        E.SetActive(false);
        Lkm.SetActive(false);
        GameObject[] flashlights = GameObject.FindGameObjectsWithTag("FlashLight");
        foreach (GameObject flashlight in flashlights)
        {
            Light lightComponent = flashlight.GetComponent<Light>();
            if (lightComponent != null)
            {
                lightComponent.enabled = !lightComponent.enabled;

            }
        }
    }

            private void FixedUpdate()
            {
                RaycastHit h;
                Ray ray = new Ray(_mainCamera.transform.position, _mainCamera.transform.forward);
                Physics.Raycast(ray, out h, _draggableObjectDistance);
                if (_currentlyDraggedObject != null)
                {
                    Vector3 targetPosition = _mainCamera.transform.position + _mainCamera.transform.forward * _draggableObjectDistance;
                    _currentlyDraggedObject.SetTargetPosition(targetPosition);
                }
                if (h.collider?.GetComponent<DraggableObject>() is DraggableObject draggableObject)
                {
                    Debug.Log("Hit");
                    Lkm.SetActive(true);
                }

                else
                {
                    Debug.Log("No hit");
                    Lkm.SetActive(false);
                }
                if (h.collider?.CompareTag("Panel") == true || h.collider?.CompareTag("Button") == true || h.collider?.CompareTag("Butto2") == true)
                {
                    E.SetActive(true);
                }
                else
                {
                    E.SetActive(false);
                }
            }

            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
            GameObject[] flashlights = GameObject.FindGameObjectsWithTag("FlashLight");
            foreach (GameObject flashlight in flashlights)
            {
                Light lightComponent = flashlight.GetComponent<Light>();
                if (lightComponent != null)
                {
                    lightComponent.enabled = !lightComponent.enabled;

                }
            }
        }
                RaycastHit hit;
                bool hitDraggableObject = Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _raycastDistance, LayerMask.GetMask("DraggableObject"));
                if (hit.collider?.GetComponent<DraggableObject>() is DraggableObject draggableObject)
                {
                    if (Input.GetMouseButtonDown(0) && hitDraggableObject)
                    {
                        draggableObject.StartFollowingObject();
                        _currentlyDraggedObject = draggableObject;
                    }
                }



                if (Input.GetMouseButtonUp(0))
                {
                    if (_currentlyDraggedObject != null)
                    {
                        _currentlyDraggedObject.StopFollowingObject();
                        _currentlyDraggedObject = null;
                        Lkm.SetActive(false);
                    }
                }
            }
        }