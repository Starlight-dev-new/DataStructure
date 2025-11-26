using UnityEngine;

public class BuffStar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     [SerializeField] float duration = 2f;
     private Player player;
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.gameObject.CompareTag("Player"))
        { 
            player = collision.gameObject.GetComponent<Player>();
           player.StartCoroutine(player.BuffStar(duration)) ;
            Destroy(this.gameObject);
        }
    }
      
    
}
