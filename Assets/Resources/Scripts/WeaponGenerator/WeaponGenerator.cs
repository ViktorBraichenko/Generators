using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace WeaponGeneratorTool
{
    public class WeaponGenerator : MonoBehaviour
    {
        public List<GameObject> _bodyParts;
        public List<GameObject> _barrelParts;
        public List<GameObject> _gripParts;
        public List<GameObject> _magazineParts;
        public List<GameObject> _scopeParts;
        public List<GameObject> _stockParts;
    
        public void Create()
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
            GenerateWeapon();
        }

        void GenerateWeapon()
        {
            //get a random base body from the list
            GameObject randomBody = GetRandomPart(_bodyParts);
            //instantiate it
            GameObject insBody =  Instantiate(randomBody, transform.position, Quaternion.Euler(-90,90,0), transform);
            WeaponBody wpnBody = insBody.GetComponent<WeaponBody>();
        
            GameObject randomBarrel = GetRandomPart(_barrelParts);
            Instantiate(randomBarrel, wpnBody._barrelTransform.position, Quaternion.Euler(-90,90,0), wpnBody._barrelTransform);        
        
            GameObject randomGrip = GetRandomPart(_gripParts);
            Instantiate(randomGrip, wpnBody._gripTransform.position, Quaternion.Euler(-90,90,0), wpnBody._gripTransform);        
        
            GameObject randomMagazine = GetRandomPart(_magazineParts);
            Instantiate(randomMagazine, wpnBody._magazineTransform.position, Quaternion.Euler(-90,90,0), wpnBody._magazineTransform);
        
            GameObject randomScope = GetRandomPart(_scopeParts);
            Instantiate(randomScope, wpnBody._scopeTransform.position, Quaternion.Euler(-90,90,0), wpnBody._scopeTransform);
        
            GameObject randomStock = GetRandomPart(_stockParts);
            Instantiate(randomStock, wpnBody._stockPart.position, Quaternion.Euler(-90,90,0),wpnBody._stockPart);
        
        
        }

        GameObject GetRandomPart(List<GameObject> partList)
        {
            int randomNumber = Random.Range(0, partList.Count);
            return partList[randomNumber];
        }
    }
}

