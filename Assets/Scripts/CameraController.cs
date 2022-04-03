using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// Vitesse de mouvement de la camera
    [SerializeField] private float PanningSpeed = 20f;

    /// Taille de la zone d'activation du mouvement a la souris
    [SerializeField] private float PanningBorderThickness = 4f;

    /// Premier point de restriction de la camera
    private GameObject TopLeftLimit;

    /// Deuxieme point de restriction de la camera
    private GameObject BottomRightLimit;

    /// Moment auquel la camera a commence a bouger
    private float MoveStart = 0f;

    void Awake()
    {
        TopLeftLimit = GameObject.FindGameObjectWithTag("TopLeft");
        BottomRightLimit = GameObject.FindGameObjectWithTag("BottomRight");
    }

    void Update()
    {
        if ((Input.mousePosition.y >= Screen.height - PanningBorderThickness ||
            Input.mousePosition.y <= PanningBorderThickness ||
            Input.mousePosition.x <= PanningBorderThickness ||
            Input.mousePosition.x >= Screen.width - PanningBorderThickness ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.LeftArrow)) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D) &&
            MoveStart == 0f)
        {
            MoveStart = Time.time;
        }

        // Gestion de l'acceleration de la camera via une AnimationCurve
        //AccelerationCoeff = MovementSpeedup.Evaluate(Time.time - MoveStart);

        Vector3 pos = transform.position;

        // Gestion des controles clavier et souris, on applique a chaque mouvement le coefficient d'acceleration 
        // ET UN COEFFICIENT POUR CONTRER L'EFFET RALENTISSEMENT EN HAUTEUR 
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - PanningBorderThickness)
        {
            //pos.z += PanningSpeed * Time.deltaTime * AccelerationCoeff * pos.y / 16;
            pos.y += PanningSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.mousePosition.y <= PanningBorderThickness)
        {
            //pos.z -= PanningSpeed * Time.deltaTime * AccelerationCoeff * pos.y / 16;
            pos.y -= PanningSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.mousePosition.x <= PanningBorderThickness)
        {
            //pos.x -= PanningSpeed * Time.deltaTime * AccelerationCoeff * pos.y / 16;
            pos.x -= PanningSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - PanningBorderThickness)
        {
            //pos.x += PanningSpeed * Time.deltaTime * AccelerationCoeff * pos.y / 16;
            pos.x += PanningSpeed * Time.deltaTime;
        }

        // Restrictions de la position camera en fonction des points de limite
        //pos.x = Mathf.Clamp(pos.x, TopLeftLimit.transform.position.x + Screen.width/2f, BottomRightLimit.transform.position.x - Screen.width/2f);
        //pos.y = Mathf.Clamp(pos.y, BottomRightLimit.transform.position.y + Screen.height/2f, TopLeftLimit.transform.position.y - Screen.height/2f);
        pos.x = Mathf.Clamp(pos.x, TopLeftLimit.transform.position.x + 88, BottomRightLimit.transform.position.x - 88);
        pos.y = Mathf.Clamp(pos.y, BottomRightLimit.transform.position.y + 49, TopLeftLimit.transform.position.y - 49);
        //pos.y = Mathf.Clamp(pos.y, MinHeight, MaxHeight);

        if (transform.position == pos)
        {
            MoveStart = 0f;
        }

        // On finit par deplacer la camera
        transform.position = pos;
    }
}
