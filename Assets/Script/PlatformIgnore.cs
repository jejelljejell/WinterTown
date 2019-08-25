using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformIgnore : MonoBehaviour
{
    public Collider2D platformCollider;
    public Collider2D playerCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Player"))
        {
            //player collider, platform collider
            Physics2D.IgnoreCollision(playerCollider,platformCollider, true); //무시
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
