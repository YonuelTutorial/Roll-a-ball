using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class JugadorController : MonoBehaviour {

    public float velocidad;
    private Rigidbody rb;

    // Variables para los textos y el conteo
    private int contador;
    public Text TextoContador;
    public Text TextoGanar;

    void Start () {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        
        // Inicializamos los textos al arrancar el juego
        SetTextoContador();
        TextoGanar.text = ""; // Lo dejamos vacío al inicio [cite: 509]
    }

    void FixedUpdate () {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coleccionable")) {
            other.gameObject.SetActive(false);
            contador = contador + 1; // Sumamos 1 al contador
            SetTextoContador(); // Actualizamos el texto en pantalla
        }
    }

    // Función personalizada para actualizar la UI
    void SetTextoContador() {
        TextoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12) {
            TextoGanar.text = "¡Ganaste!";
        }
    }
}