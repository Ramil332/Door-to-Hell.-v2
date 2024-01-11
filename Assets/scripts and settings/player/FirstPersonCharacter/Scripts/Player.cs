using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public int health = 100;
    public int damage = 5;

    public void AplyDamage()
    {
        health -= damage;

        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    void OnCollisionEnter(Collision enemy)
    {
        if (enemy.gameObject.tag == "Zombie")
            health -= damage;
    }

    void OnCollisionExit(Collision enemy)
    {
        if (enemy.gameObject.tag == "Zombie")
            health += 1;
            
    }

    
}
