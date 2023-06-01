using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private SpriteRenderer ImagemPersonagem;
    public float velocidade = 1f;
    public float distInicial = -0.5f;
    public float distFinal = 2f;

    private Gerenciador GJ;
    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        ImagemPersonagem = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            Andar();
        }
        

    }

    void Andar()
    {
        transform.position = new Vector3(transform.position.x + velocidade, transform.position.y, transform.position.z);

        if(transform.position.x > distFinal)
        {
            velocidade = velocidade * -1;
            ImagemPersonagem.flipX = true;
        }

        if(transform.position.x < distInicial)
        {
            velocidade = velocidade * -1;
            ImagemPersonagem.flipX = false;
        }
    }
}
