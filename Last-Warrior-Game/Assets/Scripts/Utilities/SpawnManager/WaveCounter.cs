using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private Text waveText;
    private SpawnManager spawnManager;
    
    void Start()
    {
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaveText();
    }
    void UpdateWaveText()
    {
        waveText.text = "Wave " + spawnManager.currentWave.ToString();
    }
}
