
# Readme

Hi! I've create my realisation of procedural generation. It's include 2 different variant of it: weapon generation like in Borderlands and Fallout and building generation. 

## Building Generator

The main idea of this generator is to create dependency system of building "pieces".

        BuildingPiece SpawnPieceLayer(BuildingPiece[] pieceArray)
        {
            BuildingPiece piecePrefab = pieceArray[Random.Range(0, pieceArray.Length)];
            BuildingPiece clone = Instantiate(piecePrefab, transform);
            return clone;
        }
Also added code for more "logic" construction of building. As example, we can't have doors on lvl > 2. Building piece include 3 empty transforms - it's created to have posibility to reuse this system with different meshes. Thanks Yevheniy Raievskyi that help me with part of logic. 
![1](https://user-images.githubusercontent.com/44576306/150690658-81c945df-0d78-4b3f-a9e7-a0b576e34508.PNG)
![2](https://user-images.githubusercontent.com/44576306/150690662-3856feaa-67aa-4827-9bf9-3f5990c0c9f0.PNG)

## Weapon Generator
The main idea is to create main object - and instantiate other parts on empty transform to create generation of pieces. 
![3](https://user-images.githubusercontent.com/44576306/150690666-33f064ac-14f9-4bd2-a48d-334319c8daa7.PNG)
![4](https://user-images.githubusercontent.com/44576306/150690669-c402b23e-1de3-4776-821b-662c7f7924ab.PNG)
## Tech Stack

**Client:** Unity, C#

