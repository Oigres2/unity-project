using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    public Transform player;
    public float zombieSpeed = 3.0f;
    public float attackRange = 1.0f;
    private NavMeshAgent agent;

    void Start()
    {
        // Encontra o jogador usando a tag "PlayerModel"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        // Se o objeto playerObject foi encontrado, pegue seu componente Transform
        if (playerObject != null)
        {
            player = playerObject.transform;
            Debug.Log("Player found");
        }
        else
        {
            Debug.LogError("Player object not found");
            return;
        }

        // Obtém o componente NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent not found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Verifique se o player e o agent estão devidamente instanciados
        if (player == null || agent == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if(distance < attackRange)
        {
            // Aqui adiciona o que o zumbi deve fazer quando estiver no range de ataque
            // Como exemplo, este código faz o zumbi parar.
            agent.isStopped = true;
            Debug.Log("Zombie atacando o jogador!");
        }
        else
        {
            // Siga o jogador
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
    }
}
