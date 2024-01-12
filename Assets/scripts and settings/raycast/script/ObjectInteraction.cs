


// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using Unity.Burst.CompilerServices;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    [SerializeField] private Camera _mainCamera;
    public bool IsButtonActive = false;
    bool isClip = true;
    bool isClipElevOp = true;
    bool isClipElevClosed = true;
    public Animator animator;
    public GameObject note;
    public GameObject interaction;


    public AudioClip openGenerator; // Звук взаимодействия
    public AudioClip openElevator; // Звук взаимодействия
    public AudioClip closeElevator; // Звук взаимодействия
    private AudioSource audioSource; // Компонент AudioSource

    private void Start()
    {
        // Находим AudioSource на этом же объекте или добавляем его, если его нет
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
                if (hit.collider.CompareTag("Panel") && isClip == true)
                {
                    Invoke("InteractWithObject", 1f);
                    PlayInteractionSound(openGenerator); // Воспроизводим звук взаимодействия

                }
                if (hit.collider.CompareTag("Button") && IsButtonActive && isClipElevOp)
                {
                    Invoke("OpenElevator", 4.4f);
                    PlayInteractionSound(openElevator); // Воспроизводим звук взаимодействия
                    isClipElevOp = false;
                }
                if (hit.collider.CompareTag("Butto2") && IsButtonActive && isClipElevClosed)
                {
                    Invoke("ClosedElevator", 6f);
                    PlayInteractionSound(closeElevator); // Воспроизводим звук взаимодействия
                    isClipElevClosed = false;
                }
            }
        }
    }

    void InteractWithObject()
    {
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