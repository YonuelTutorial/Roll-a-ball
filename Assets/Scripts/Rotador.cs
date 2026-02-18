using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour {

    void Update () {
        // Rota el elemento una cantidad diferente en cada dirección y en cada intervalo de tiempo
        // Los valores 15, 30, 45 son los grados de rotación en X, Y, Z
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}