using UnityEngine;


public class AddSped : MonoBehaviour
{
     [SerializeField] float addSpeed = 2f; // ค่าความเร็วที่ต้องการเพิ่ม
     [SerializeField] float duration = 2f; // ระยะเวลาที่บัพ
     private Player player;



    void OnCollisionEnter2D(Collision2D collision)
    {    
        if (collision.gameObject.CompareTag("Player"))
        { 
            player = collision.gameObject.GetComponent<Player>();
            player.StartCoroutine( player.BuffSped(addSpeed,duration));
            Destroy(this.gameObject);
            
            
        }
      
    }  
}