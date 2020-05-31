# Pedestrian-Simulation
Crowd simulation is the process of simulating the movement (or dynamics) of a large number of entities or characters. It is commonly used to create virtual scenes for visual media like films and video games, and is also used in crisis training, architecture and urban planning, and evacuation simulation. The goal of this Project is to simulate a crowd of people as realistic as possible; we will simulate a group of people in different scenarios such as more or less crowded scenes, bottlenecks, and people in a hurry, and also have tunable parameters.

For this project we will only implement two models. The first model is a modified version of Reynolds Flocking Algorithm (Boids), Boids is an artificial life program developed by Craig Reynolds in 1986, which simulates the flocking behaviour of birds.

The second model is Optimal Reciprocal Collision Avoidance (ORCA) by Jur van den Berg, Stephen J. Guy, Ming Lin, and Dinesh Manocha, where they present a formal approach to reciprocal collision avoidance.

For achieving a more realistic behavior we have also combined the two models with the A star path finding algorithm. We will compare these two algorithms in two scenarios: where a large crowd wants to exit a building, and where two groups of pedestrians want to pass one another in a hallway.

