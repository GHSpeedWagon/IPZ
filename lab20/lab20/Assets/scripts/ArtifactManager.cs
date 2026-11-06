using UnityEngine;

[CreateAssetMenu(fileName = "New Artifact", menuName = "Prototypes/Artifact")]
public class ArtifactPrototype : ScriptableObject {
    public string artifactName;
    public string artifactType;
    public int power;
}

public class ArtifactManager : MonoBehaviour {
    public ArtifactPrototype baseSword;
    public ArtifactPrototype baseShield;

    void Start() {
        if (baseSword != null) {
            ArtifactPrototype clonedSword = Instantiate(baseSword);
            clonedSword.artifactName = "Палаючий " + baseSword.artifactName;
            clonedSword.power += 50;
            Debug.Log($"Створено артефакт: {clonedSword.artifactName}, Тип: {clonedSword.artifactType}, Сила: {clonedSword.power}");
        }

        if (baseShield != null) {
            ArtifactPrototype clonedShield = Instantiate(baseShield);
            clonedShield.artifactName = "Непробивний " + baseShield.artifactName;
            clonedShield.power += 100;
            Debug.Log($"Створено артефакт: {clonedShield.artifactName}, Тип: {clonedShield.artifactType}, Сила: {clonedShield.power}");
        }
    }
}