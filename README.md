
# GalaxSphere

GalaxSphere is a game about collecting stars while testing your reaction and timing. 

### Gameplay 
In GalaxSphere, you play as a ball that is jumping higher and higher, and the occasional obstacle might try to stop you. Do not fret however, as color switchers around the stage changes your color that can help you pass obstacles of the same color! Once you collected 10 stars, you have beat the game!
### Controls
Press the mouse to make the ball bounce.
### Features
The game features a rough obstacle spawner ensuring only some stages are the same! This spawner also makes sure that you get a color switch in between each obstacle to shake up the gameplay!
### Game Modes
There is only one game mode, which is the one you will be launched into automatically.
## Features I would add

- Object Pooling: I meant to implement this, but an issue with the tags that that affected the hit detection took FOREVER to hunt down. The object pooling would have been a matter of creating a secondary array for the poolable objects. Once an obstacle or color switcher moves far enough out from the player, they would be added back to the poolable array. When it would be time to "spawn" another object, the game would check first from the poolable array and see if there is a matching object to spawn into the game, moving it's transform ahead of the player at the fixed points of the spawner object.This would enable smooth sailing with an endless mode.
- Cueball Physics: I love physics based games, and I would implement a feature where the player stops time to aim the ball and release to jump. This would slingshot the ball along the map, and would require the player to predict the trajectory to avoid obstacles. I would have to rework the movement and add a RigidBody2D to the sphere. Using the InputSystem I could then trigger an event that pauses the physics on the RigidBody2D and creates a targeting reticule using the forward vector of the sphere. Once the player would press the button again, the sphere would be sent flying along the trajectory and perform collision checks against the walls to see if it bounces or dies. 


## Installation & Requirements

### Requirements
I am almost guaranteed if you have a computer, it meets the requirements. Built for Windows.

### Installation
You can either download Unity and match the Unity version (version 2022.3.21f1), or download the build from itch.io which you need to unzip (Link to the itch.io page found in the links section).

## Development 

### Tech Stack
The game was built using Unity Engine and C#. 

### Architecture
The components of the game are built around prefabs that try to mainly do only one thing. If the Player has a score value, it is found in the Player script. This is to ensure that when someone else is working with the code, they can pretty easily guess where the needed components are.

### Coding Conventions
I am using what I assume is the C# standard, but it is affected by my coding practices in C++ by quite a bit. Class members are named with underscore(_var) so they are easily identifiable as the classes own data members.
## 🔗 Links
[GalaxSphere Executable](https://rushmaverick.itch.io/galaxsphere)

[Brackey's Audio Manager](https://youtu.be/6OT43pvUyfY)

[My LinkedIn](www.linkedin.com/in/rasmus-rask)

