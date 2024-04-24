using UnityEngine;

public class Element : MonoBehaviour
{

    [SerializeField]
    private Elementality m_elementality;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetType() == typeof(UnityEngine.CharacterController))
        {
            Debug.Log("Collision with player");
            // Send element types to player object
            PlayerElementality player_elementality = other.GetComponent<PlayerElementality>();
            if(player_elementality != null)
            {
                player_elementality.AddElementality(ref m_elementality);
            }
        }
        else
        {
            Debug.Log("Collision with something else");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetType() == typeof(UnityEngine.CharacterController))
        {
            // Subtract elementality from player object
            PlayerElementality player_elementality = other.GetComponent<PlayerElementality>();
            if (player_elementality != null)
            {
                player_elementality.RemoveElementality(ref m_elementality);
            }
        }
    }
}
