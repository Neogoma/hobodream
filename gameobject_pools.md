## Overview
Sometimes we have cases where we have to instanciate/remove lot of objects. In order to reduce the complexity and the memory allocations we created a class called **AbstractGameobjectPoolManager**. This class contains a basic logic to maintain a pool of gameobject of a model class.

## How to use the AbstractGameObjectPoolManager?
In order to use the gameobjectpool you just have to extend the **AbstractGameobjectPoolManager**, the expected generic argument is a class that contains the data to display (for example a class that contains the position and rotation of a gameobject).

In order to work the object pool needs a transform to use in scene to act as a __root__ of all the newly created objects as well as a GameObject __prefab__.

## Implementations
Once your extension has been setup it will need to implement the following things:
- A constructor
- The **UpdateGameObject** method called when an instance has been reused
- The **InitializeGameobject** method called when a new instance has been created

## Usage
There are many ways to interact with the object pool manager, you can:
- Add a single object via **AddItem**
- Add a list of objects via **AddItems**
- Cleanup the object pool (will reset all the object to inactive) via **Clean**
- Change the root transform of the pool via **UpdateRoot**