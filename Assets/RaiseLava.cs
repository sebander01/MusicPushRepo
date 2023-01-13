using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaiseLava : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed;
    public string LevelName;
    public int secondTillRespawn;
    public GameObject Player;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Respawn();
        }
    }

    private async void Respawn()
    {
        Player.SetActive(false);
        text.SetActive(true);
        await Task.Delay(secondTillRespawn * 60);
        SceneManager.LoadScene(LevelName);
    }
}
