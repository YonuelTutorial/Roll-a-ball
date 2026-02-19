using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuPausa : MonoBehaviour {
    
    public GameObject panelPausa; 
    private bool estaPausado = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if (estaPausado) {
                ReanudarJuego();
            } else {
                PausarJuego();
            }
        }
    }

    public void PausarJuego() {
        panelPausa.SetActive(true); 
        Time.timeScale = 0f;        
        estaPausado = true;
    }

    public void ReanudarJuego() {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void ReiniciarNivel() {
        Time.timeScale = 1f; 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void VolverAlMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}