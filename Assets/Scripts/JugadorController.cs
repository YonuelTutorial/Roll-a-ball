using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class JugadorController : MonoBehaviour {
    public float velocidad = 10f;
    private Rigidbody rb;
    private int contador;
    
    // UI
    public Text textoContador;
    public Text textoGanar;
    public Text textoTimer;
    
    // Lógica del juego
    public float tiempoRestante = 120f;
    private bool juegoTerminado = false;
    public int totalColeccionables = 12; 
    public string nombreSiguienteEscena = "MenuPrincipal"; 

    void Start () {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        SetTextoContador();
        textoGanar.text = "";
    }


    void Update() {
        if (!juegoTerminado) {
            tiempoRestante -= Time.deltaTime;
            textoTimer.text = "Tiempo: " + Mathf.RoundToInt(tiempoRestante).ToString();
            
            if (tiempoRestante <= 0) {
                tiempoRestante = 0;
                PerderJuego();
            }
        }
    }

    void FixedUpdate () {
        if (juegoTerminado) return; 

        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coleccionable") && !juegoTerminado) {
            other.gameObject.SetActive(false);
            contador++;
            SetTextoContador();
        }
    }

    void SetTextoContador() {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= totalColeccionables && !juegoTerminado) {
            GanarJuego();
        }
    }

    void GanarJuego() {
        juegoTerminado = true;
        textoGanar.text = "¡Ganaste!";
        textoGanar.color = Color.green;
        StartCoroutine(CambiarEscena(5f)); 
    }

    void PerderJuego() {
        juegoTerminado = true;
        textoGanar.text = "¡Perdiste! Tiempo agotado";
        textoGanar.color = Color.red;
        StartCoroutine(CambiarEscena(5f)); 
    }


    IEnumerator CambiarEscena(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}