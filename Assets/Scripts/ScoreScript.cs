using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    private GestorNivel gestor;

    void Start()
    {
        gestor = FindFirstObjectByType<GestorNivel>();
    }

    void Update()
    {
        if (gestor != null && textField != null)
        {
            // Vai buscar os pontos reais do GestorNivel atual
            textField.text = gestor.pontos.ToString();
        }
    }
}