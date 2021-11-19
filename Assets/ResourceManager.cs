using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class ResourceManager : MonoBehaviour {
    public Slider sunlightBar;
    public Slider nutrientsBar;
    public TextMeshProUGUI sunText;
    public TextMeshProUGUI nutrientsText;

    public GameObject sun;
    public GameObject moon;

    public List<GameObject> leavesGO;
    public int LunarLeafCount = 0;
    public int leafCount = 0;
    public int nutUpgrades = 0;
    public int sunUpgrades = 0;
    public int leafSpeed = 0;

    public float maxSunlight;
    public float maxNutrients;
    public float currentSunlight;
    public float currentNutrients;
    public float baseSunlightDegen;
    public float basemaxNutrientsDegen;
    public float leafRegen;
    public List<Leaf> leaves = new List<Leaf>();

    public float SunAngle;

    [SerializeField]
    Sprite[] drills = new Sprite[4];

    [SerializeField]
    int spriteIterator = 0;

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
        //testing

        Debug.Log("leaves : " + leaves);





        //Bars
        sunlightBar.maxValue = maxSunlight;
        nutrientsBar.maxValue = maxNutrients;


    }
    void Update() {
        BarUpdate();
        LeavesUpdate();
        //LeafCalculation();
        //SunAngleCalculation();


        // currentSunlight += (leafRegen - baseSunlightDegen) * Time.deltaTime;
        // //  Adjusts to resources
        // if (currentSunlight > maxSunlight)
        // {
        //   currentSunlight = maxSunlight;
        // }
        //
        //
        // if (currentSunlight < 0)
        // {
        //   currentSunlight = 0;
        // }

        //  Debugging
        //Debug.Log("Leaf Regen : " + leafRegen);
        //Debug.Log("# of leafs : " + leaves.Count);
        //Debug.Log("Leaf 1 size : " + leaves[1].percentSize);
        //Debug.Log("Current Sunlight : " + Mathf.Floor(currentSunlight));
        BarUpdate();
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
            //float diffAngle = Mathf.Abs(leaves[i].leafObj.transform.eulerAngles.z - SunAngle);
            //float efactor = 1 / Mathf.Sin(diffAngle);

            totalLeafRegen += leaves[i].maxSize;// * efactor;


            //Mathf.Acos2(leafangle, sunAngle);



        }
        leafRegen = totalLeafRegen;

    }






    void SunAngleCalculation() {
        SunAngle = sun.transform.eulerAngles.z;
    }

    void BarUpdate() {
        nutrientsBar.value = currentNutrients;
        sunlightBar.value = currentSunlight;
        nutrientsText.text = Mathf.Round(currentNutrients).ToString();
        sunText.text = Mathf.Round(currentSunlight).ToString();

    }








    //  Buying shii...uff

    public void BuyingUpgrade(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;

        }
    }
    public void BuyingLeaf(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;
            if (leafCount < 5) {
                leavesGO[leafCount].SetActive(true);
                //Debug.Log("BSBHSBHSVHVS");
                _tech.cost += 20;
                leafCount++;
                //_tech.NoOfRebuys -= 1;
            }
            else {
                _tech.gameObject.SetActive(false);
            }
        }
        //Max leaves is 5
    }


    public void BuyingLunarLeaf(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;
            leavesGO[LunarLeafCount].GetComponent<LookAtSun>().m_lunar = true;
            _tech.cost += 20;
            if (LunarLeafCount < 4) {
                LunarLeafCount += 1;
            }
            else {
                _tech.gameObject.SetActive(false);
            }
        }
    }
    public void BuyingTechUpgrade(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;
            FindObjectOfType<Roots>().tech += 1;
            _tech.cost += 20;
            if (spriteIterator < drills.Length) {
                _tech.gameObject.GetComponent<Image>().sprite = drills[spriteIterator++];
            }
            else {
                _tech.gameObject.SetActive(false);
            }
        }

    }



    public void BuyingNutUpgrade(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;
            _tech.cost += 20;
            maxNutrients += 100;

            nutrientsBar.maxValue += 100;

            if (nutUpgrades >= 5) {
                _tech.gameObject.SetActive(false);
            }
            nutUpgrades += 1;
        }

    }



    public void BuyingSunUpgrade(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;
            _tech.cost += 20;
            maxSunlight += 100;

            sunlightBar.maxValue += 100;

            if (sunUpgrades >= 5) {
                _tech.gameObject.SetActive(false);
            }
            sunUpgrades += 1;
        }

    }

    public void BuyingRotationUpgrade(TechTreeButton _tech) {
        if (_tech.cost <= currentNutrients) {
            currentNutrients -= _tech.cost;
            _tech.cost += 20;
            for (int i = 0; i < 5; i++) {
                leavesGO[i].GetComponent<LookAtSun>().m_speed += 1.0f;
            }

            if (leafSpeed >= 5) {
                _tech.gameObject.SetActive(false);
            }
            leafSpeed += 1;
        }

    }

}