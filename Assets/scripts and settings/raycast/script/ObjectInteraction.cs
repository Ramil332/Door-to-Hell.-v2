


// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using Unity.Burst.CompilerServices;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    [SerializeField] private Camera _mainCamera;
    public bool IsButtonActive = false;
    public Animator animator;

    public AudioClip openGenerator; // ���� ��������������
    public AudioClip openElevator; // ���� ��������������
    public AudioClip closeElevator; // ���� ��������������
    private AudioSource audioSource; // ��������� AudioSource

    private void Start()
    {
        // ������� AudioSource �� ���� �� ������� ��� ��������� ���, ���� ��� ���
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        GameObject[] lights = GameObject.FindGameObjectsWithTag("light");
        foreach (GameObject lightObject in lights)
        {
            Light lightComponent = lightObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                Debug.Log("Disabling light: " + lightObject.name);
                lightComponent.enabled = false;
            }
            else
            {
                Debug.LogWarning("No Light component found on object: " + lightObject.name);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, interactionRange))
            {
                if (hit.collider.CompareTag("Panel"))
                {
                    InteractWithObject(hit.collider.gameObject);
                }
                if (hit.collider.CompareTag("Button") && IsButtonActive)
                {
                    Invoke("OpenElevator", 4.4f);
                    PlayInteractionSound(openElevator); // ������������� ���� ��������������
                }
                if (hit.collider.CompareTag("Butto2") && IsButtonActive)
                {
                    Invoke("ClosedElevator", 6f);
                    PlayInteractionSound(closeElevator); // ������������� ���� ��������������
                }
            }
        }
    }

    void InteractWithObject(GameObject obj)
    {
        Debug.Log("Interacted : " + obj.name);
        GameObject[] lights = GameObject.FindGameObjectsWithTag("light");
        foreach (GameObject lightObject in lights)
        {
            Light lightComponent = lightObject.GetComponent<Light>();
            if (lightComponent != null)
            {
                Debug.Log("Enabling light: " + lightObject.name);
                lightComponent.enabled = true;
            }
        }

        IsButtonActive = true;
        PlayInteractionSound(openGenerator); // ������������� ���� ��������������
    }

    void PlayInteractionSound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    void OpenElevator()
    {
        animator.SetBool("IsOpen", true);
    }

    void ClosedElevator()
    {
        animator.SetBool("IsOpen", false);
    }
}