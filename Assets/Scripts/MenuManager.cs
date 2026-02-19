using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuManager : MonoBehaviour {

    // Función para el botón Jugar
    public void Jugar() {
        SceneManager.LoadScene("Nivel1");
    }

    // Función para el botón Opciones
    public void IrAOpciones() {
        SceneManager.LoadScene("Opciones");
    }


    public void VolverAlMenu() {
        SceneManager.LoadScene("MenuPrincipal");
    }
}