# Unity3D-Utility-Classes
Some utility classes that i used for my game "Cloned"

GameInitializer class initialize ScreenUtils and ConfigurationUtils classes.

ScreenUtils class is a static class that defines the values of the screen edges in world coordinates. You can use this class to define boundaries in your screen or write a function to "clamp" your character between the borders of the screen.

ObjectsPool class uses lists to use objects from a pool. When an object is needed, you get the object from the pool (If its not in the list, then it creates a new one and expands the list). If the object is not needed anymore, it returns to the pool.
