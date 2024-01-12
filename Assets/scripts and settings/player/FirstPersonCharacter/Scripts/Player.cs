using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public int health = 100;
    public int damage = 15;

    public GameObject damageEffect;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZombieHand"))
        {
            AplyDamage();
            damageEffect.SetActive(true);
        }

        Debug.Log("Тронула меня");

        
    }

    private void OnTriggerExit(Collider other)
    {
        health += 1;

        Invoke("desableDamageEffect", 1f);
    }

    public void AplyDamage()
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }


    }

    void desableDamageEffect()
    {
        damageEffect.SetActive(false);
    }

}
