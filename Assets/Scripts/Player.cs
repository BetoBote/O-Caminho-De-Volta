using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D Corpo;
    public float Velocidade;
    public SpriteRenderer ImagemPersonagem;
    public int qtd_Pulo = 0;
    private float meuTempoPulo = 0;
    public bool pode_pular = true;
    public int vida = 3;
    private bool pode_dano = true;
    private float meuTempoDano = 0;
    public int bolinhas = 0;
    public int vagalumes = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        Pular();
        Apontar();
        Dano();
    }

    void Mover()
    {
        Velocidade = Input.GetAxis("Horizontal") * 4;
        Corpo.velocity = new Vector2(Velocidade, Corpo.velocity.y);
    }

    void Apontar()
    {
        if(Velocidade > 0)
        {
            ImagemPersonagem.flipX = false;
        }
        
        else if(Velocidade < 0)
        {
            ImagemPersonagem.flipX = true;
        }
    }
    void Pular()
    {
        if (Input.GetKeyDown(KeyCode.Space) && pode_pular == true)
        {
            pode_pular = false;
            qtd_Pulo++;
            if(qtd_Pulo <= 1)
            {
                AcaoPulo();
            }
            
        }
        if(pode_pular == false)
        {
            TemporizadorPulo();
        }
        
    }
    void AcaoPulo()
    {
        Corpo.velocity = new Vector2(Velocidade, 0);
        Corpo.AddForce(transform.up * 300f);
    }

    private void OnTriggerEnter2D(Collider2D gatilho)
    {
        if(gatilho.gameObject.tag == "Pisavel")
        {
            qtd_Pulo = 0;
            pode_pular = true;
            meuTempoPulo = 0;
        }

        if(gatilho.gameObject.tag == "BolinhaDGude")
        {
            Destroy(gatilho.gameObject);
            bolinhas++;
        }

        if (gatilho.gameObject.tag == "Vagalume")
        {
            Destroy(gatilho.gameObject);
            vagalumes++;
        }
    }
    void TemporizadorPulo()
    {
        meuTempoPulo += Time.deltaTime;
        if(meuTempoPulo > 0.5f)
        {
            pode_pular = true;
            meuTempoPulo = 0;
        }
    }

    void Dano()
    {
        if(pode_dano == false)
        {
            TemporizadorDano();
        }
    }
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Inimigo")
        {
            if(pode_dano == true)
            {
                ImagemPersonagem.color = UnityEngine.Color.red;
                pode_dano = false;
                vida--;
            }
            
        }
    }
    void TemporizadorDano()
    {
        meuTempoDano += Time.deltaTime;
        if (meuTempoDano > 0.5f)
        {
            pode_dano = true;
            ImagemPersonagem.color = UnityEngine.Color.white;
            meuTempoDano = 0;
        }
    }
}
