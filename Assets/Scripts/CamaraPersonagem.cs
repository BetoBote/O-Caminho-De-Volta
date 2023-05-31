using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPersonagem : MonoBehaviour
{
    public GameObject MeuJogador; 
    void Start()
    {
        
    }

    
    void Update()
    {
        Seguir();
    }

    void Seguir()
    {
        Vector3 destino = new Vector3(MeuJogador.transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, destino, 0.1f);
    }
}
