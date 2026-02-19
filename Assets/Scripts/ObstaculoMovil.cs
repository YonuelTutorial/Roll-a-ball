using UnityEngine;

public class ObstaculoMovil : MonoBehaviour {
    
    [Header("Configuración de Movimiento")]
    public float velocidad = 4f;       
    public float distancia = 6f;      
    public bool moverEnEjeZ = false;   

    private Vector3 posicionInicial;

    void Start() {
        posicionInicial = transform.position;
    }

    void Update() {
        
        float movimiento = Mathf.PingPong(Time.time * velocidad, distancia);

        if (moverEnEjeZ) {
            transform.position = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z + movimiento);
        } else {
            transform.position = new Vector3(posicionInicial.x + movimiento, posicionInicial.y, posicionInicial.z);
        }
    }
}