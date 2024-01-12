using UnityEngine;

public class UseElevator : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip[] clip;

    private void Start()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsOpen", true);
            audioSource.clip = clip[0];
            audioSource.Play();
        }
    }
}
