using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BuildingGenerator
{
    public class BuildingGeneratorMain : MonoBehaviour
    {
        [SerializeField] private BuildingGeneratorInstantiating _generator;
        
        public Slider xSlider;
        public Slider ySlider;
        public Slider zSlider;
        public TextMeshProUGUI xSliderText;
        public TextMeshProUGUI ySliderText;
        public TextMeshProUGUI zSliderText;
        private void Start()
        {
            xSlider.onValueChanged.AddListener((hv) =>
            {
                xSliderText.text = hv.ToString( "Height: " + "0");
            });
            ySlider.onValueChanged.AddListener((lv) =>
            {
                ySliderText.text = lv.ToString("Width:" + "0");
            }); 
            zSlider.onValueChanged.AddListener((lv) =>
            {
                zSliderText.text = lv.ToString("Bottom:" + "0");
            });
        }

        public void Build()
        {
            if (transform.childCount > 0)
            {
                while (transform.childCount > 0)
                {
                    Transform child = transform.GetChild(0);
                    child.parent = null;
                    Destroy(child.gameObject);
                }
            }
            _generator.BuildConst();
            
        }
    }
}

