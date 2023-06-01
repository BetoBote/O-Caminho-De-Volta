using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public bool GameLigado = false;
    void Start()
    {
        GameLigado = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool EstadoDoJogo()
    {
        return GameLigado;
    }

    public void LigarJogo()
    {
        GameLigado = true;
        Time.timeScale = 1;

    }
}
