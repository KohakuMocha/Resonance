using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager> {

	public IDictionary<string, GameObject> Prefabs = new Dictionary<string, GameObject>();
    public IDictionary<string, AudioClip> Sounds = new Dictionary<string, AudioClip>();

    void Awake () {
        InitializePrefabs();
        InitializeSounds();
    }

    private void InitializePrefabs()
    {
        Prefabs.Add("Boulder", Resources.Load("Prefabs/Boulder") as GameObject);
        Prefabs.Add("Echo", Resources.Load("Prefabs/Echo") as GameObject);
        Prefabs.Add("Key", Resources.Load("Prefabs/Key") as GameObject);
        Prefabs.Add("Pulse", Resources.Load("Prefabs/Pulse") as GameObject);
    }

    private void InitializeSounds()
    {
        Sounds.Add("CalmForest", Resources.Load("Sounds/CalmForest") as AudioClip);
        Sounds.Add("EchoSound", Resources.Load("Sounds/EchoSound") as AudioClip);
        Sounds.Add("Lake", Resources.Load("Sounds/Lake") as AudioClip);
        Sounds.Add("StepsCave", Resources.Load("Sounds/StepsCave") as AudioClip);
        Sounds.Add("StepsDirt", Resources.Load("Sounds/StepsDirt") as AudioClip);
        Sounds.Add("StepsGrass", Resources.Load("Sounds/StepsGrass") as AudioClip);
        Sounds.Add("SadCave", Resources.Load("Sounds/SadCave") as AudioClip);
        Sounds.Add("Whoosh", Resources.Load("Sounds/Whoosh") as AudioClip);
    }
}
