using UnityEngine;



public class Door : MonoBehaviour
{
    [SerializeField] GameObject ui;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") )
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player.haveKey == true )
            {

                ui.GetComponent<UI>().EndGame("You Win!");              
            }
        }
    }
}
