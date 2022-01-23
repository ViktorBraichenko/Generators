using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BuildingGenerator
{
    public class BuildingGeneratorInstantiating : MonoBehaviour
    {
        public BuildingGeneratorMain _generatorMain;
        public BuildingPiece[] _baseParts;
        public BuildingPiece[] _baseBottomParts;
        public BuildingPiece[] _midParts;
        public BuildingPiece[] _topFrontRoofParts;
        public BuildingPiece[] _midRoofParts;
        private BuildingPiece[,,] _pieces;
        
        public void BuildConst()
        {
            Vector3Int size = default;
            size.x = (int)_generatorMain.ySlider.value;
            size.y = (int)_generatorMain.zSlider.value;
            size.z = (int)_generatorMain.xSlider.value;
            _pieces = new BuildingPiece[size.x,size.y,size.z];
            InstantiatePieces(size);
            _pieces[0, 0, 0].transform.position = transform.position;
            for (int i = 0; i < size.x; i++)
            {
                if (i != 0)
                    _pieces[i, 0, 0].transform.position = _pieces[i - 1, 0, 0].Front.position;
                
                for (int j = 0; j < size.y; j++)
                {
                    if (j != 0) 
                        _pieces[i, j, 0].transform.position = _pieces[i, j - 1, 0].Right.position;
                    
                    for (int k = 0; k < size.z; k++)
                    {
                        BuildingPiece piece = _pieces[i,j,k];
                        if (k != 0)
                            piece.transform.position = _pieces[i, j, k - 1].Top.position;
                    }
                }
            }
        }
        private void InstantiatePieces(Vector3Int size)
        {
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    for (int k = 0; k < size.z; k++)
                    {
                        _pieces[i,j,k] = SpawnPieceLayer(GetPieces(size,i,j,k));
                    }
                    
                }
            }
        }
        private BuildingPiece[] GetPieces(Vector3Int size, int i, int j, int k)
        {
            if (k == 0)
            {
                if (j > 0)
                {
                    return _baseBottomParts;
                }
                return _baseParts;
            }
            if (k == size.z-1)
            {
                if (j > 0)
                {
                    return _midRoofParts;
                }
                return _topFrontRoofParts;
            }
            return _midParts;
        }
        BuildingPiece SpawnPieceLayer(BuildingPiece[] pieceArray)
        {
            BuildingPiece piecePrefab = pieceArray[Random.Range(0, pieceArray.Length)];
            BuildingPiece clone = Instantiate(piecePrefab, transform);
            return clone;
        }
    }
}

