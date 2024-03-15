using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Renderer fondo;
    public float velociodad=5;
    public int trayecto = 0;
    public int life = 3;
    
    public GameObject col;
    public GameObject enemigo;
    public GameObject meta;

    public List<GameObject> cols;
    public List<GameObject> enemigos;

    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public bool gameStart=false;
    public bool gameOver=false;

    // Start is called before the first frame update
    void Start()
    {
        //crear mapa
        for(int i = 0; i<21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i,-3), quaternion.identity));
        }

        //crear enemigo
        enemigos.Add(Instantiate(enemigo, new Vector2(-14,-2), quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStart == false)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                gameStart = true;
            }
        }

        if(gameStart == true && gameOver == true)
        {
            menuGameOver.SetActive(true);   
            if(Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(gameStart == true && gameOver == false)
        {
            GenerarMapa();
            
        }

        if(trayecto >= 5)
        {
            Instantiate(meta, new Vector2(-10,-3), quaternion.identity);
        }

        if(life <= 0)
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    private void GenerarMapa()
    {
        menuPrincipal.SetActive(false);
        fondo.material.mainTextureOffset += new Vector2(0.15f,0) * Time.deltaTime; 

        //mover mapa

        for(int i = 0; i<cols.Count; i++)
        {
            trayecto++;
            if(cols[i].transform.position.x <= -10)
            {
                cols[i].transform.position = new Vector3(10,-3,0);
            }
            cols[i].transform.position = cols[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velociodad;
        }

        //mover enemigos
        for(int i = 0; i<enemigos.Count; i++)
        {

            if(enemigos[i].transform.position.x <= -10)
            {
                float random = Random.Range(11, 18);
                enemigos[i].transform.position = new Vector3(random, -1, 0);
            }
            enemigos[i].transform.position = enemigos[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velociodad;
        }
    }
}
