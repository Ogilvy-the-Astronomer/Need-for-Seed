using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {
    public GameObject sun;
    public GameObject moon;

    public GameObject templeaf;


    public float maxSunlight;
    public float maxNutrients;
    public float currentSunlight;
    public float currentNutrients;
    public float baseSunlightDegen;
    public float basemaxNutrientsDegen;
    public float leafRegen;
    public List<Leaf> leaves = new List<Leaf>();

    public float SunAngle;

    public class Leaf {
        public Leaf(GameObject _leaf, float _maxSize) {
            maxSize = _maxSize;
            leafObj = _leaf;
        }
        public GameObject leafObj;
        public float percentSize = 0.2f;
        public float maxSize;
        public float efficiencyOfLeaf;
    }

    void Awake() {
        CreateLeaf(4.0f);
        CreateLeaf(2.0f);
        Debug.Log("leaves : " + leaves);

        //leaf le = new GameObject();
        //leafs.Add(le);
    }
    void Update() {
        //  Leaf Calculation
        LeavesUpdate();
        //LeafCalculation();
        SunAngleCalculation();



        //  Adjusts to resources
        if (currentSunlight > maxSunlight) {
            currentSunlight = maxSunlight;
        }
        currentSunlight += (leafRegen - baseSunlightDegen) * Time.deltaTime;


        //  Debugging
        Debug.Log("Leaf Regen : " + leafRegen);
        Debug.Log("# of leafs : " + leaves.Count);
        Debug.Log("Leaf 1 size : " + leaves[1].percentSize);
        Debug.Log("Current Sunlight : " + Mathf.Floor(currentSunlight));

    }


    public void LeavesUpdate() {
        for (int i = 0; i < leaves.Count; i++) {
            if (leaves[i].percentSize == 1.0f) {
                leaves[i].percentSize = 1.0f;
            }
            else {
                leaves[i].percentSize += 0.1f * Time.deltaTime;
            }
        }
    }

    public void LeafCalculation() {
        float totalLeafRegen = 0; ;
        for (int i = 0; i < leaves.Count; i++) {
            float diffAngle = Mathf.Abs(leaves[i].leafObj.transform.eulerAngles.z - SunAngle);
            float efactor = 1 / Mathf.Sin(diffAngle);

            totalLeafRegen += leaves[i].maxSize * efactor;


            //Mathf.Acos2(leafangle, sunAngle);



        }
        leafRegen = totalLeafRegen;
    }



    public Leaf CreateLeaf(float _maxSize) {
        Leaf newleaf = new Leaf(templeaf, _maxSize);
        leaves.Add(newleaf);
        return newleaf;
    }


    void SunAngleCalculation() {
        SunAngle = sun.transform.eulerAngles.z;
    }
}
