# Pedestrian Simulation
Crowd simulation is the process of simulating the movement (or dynamics) of a large number of entities or characters. It is commonly used to create virtual scenes for visual media like films and video games, and is also used in crisis training, architecture and urban planning, and evacuation simulation. The goal of this Project is to simulate a crowd of people as realistic as possible; we will simulate a group of people in different scenarios such as more or less crowded scenes, bottlenecks, and people in a hurry, and also have tunable parameters.

For this project we will only implement two models. The first model is a modified version of Reynolds Flocking Algorithm (Boids), Boids is an artificial life program developed by Craig Reynolds in 1986, which simulates the flocking behaviour of birds.

![gif Flocking](https://user-images.githubusercontent.com/26629624/83361230-81b11500-a387-11ea-881e-0686e17aa947.gif)

- Link for the full video: [Link](https://www.youtube.com/watch?v=Uj9R5JN_6x0&t=4s)

The second model is Optimal Reciprocal Collision Avoidance (ORCA) by Jur van den Berg, Stephen J. Guy, Ming Lin, and Dinesh Manocha, where they present a formal approach to reciprocal collision avoidance.

![gif Orca](https://user-images.githubusercontent.com/26629624/83361231-84136f00-a387-11ea-9312-b64b01d43504.gif)

- Link for the full video: [Link](https://www.youtube.com/watch?v=4u3ZhC8rBcU&t=45s)

For achieving a more realistic behavior we have also combined the two models with the A star path finding algorithm. We have compared these two algorithms in two scenarios: where a large crowd wants to exit a building, and where two groups of pedestrians want to pass one another in a hallway.

#
This project is done in Unity 2017.4

For the implementation of the ORCA model, we used the RVO library: [Link](http://gamma.cs.unc.edu/RVO2/)

We acquired the A* algorithm from the A* Pathfinding Project available at: [Link](https://arongranberg.com/astar/download)


