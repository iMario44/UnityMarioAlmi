using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform miTransform;
    public Transform posJugador;
    public float difJugador;
    // Start is called before the first frame update
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        miTransform.position = new Vector3(posJugador.position.x + difJugador,
                                            posJugador.position.y+6, -10);
    }
}
