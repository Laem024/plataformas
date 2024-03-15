using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaDeSalto=500;
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool saltarFree;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && saltarFree == true)
        {
            saltarFree = false;
            animator.SetBool("estaSaltando", true);
            rigidbody2D.AddForce(new Vector2(0,fuerzaDeSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
            saltarFree = true;
        }

        if(collision.gameObject.tag == "Enemigo")
        {
            gameManager.life--;
            gameManager.gameOver = true;
        }
    }
}
