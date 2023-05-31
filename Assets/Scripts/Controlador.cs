using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{

    public bool gameON = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void IniciarJogo()
    {
        gameON = true;
    }

    public bool EstadoJogo()
    {
        return gameON;
    }

}
