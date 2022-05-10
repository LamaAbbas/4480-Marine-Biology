------------------------
Marine Biology VR Game
CS4480Y
Professor Katchabaw and Professor Mensink
May 3rd 2021

Jack Maxwell
Daniel Wakefield
Kevin Gao
Lama Abbas

Music: 
Dylan Tomiharu Wright

SFX:
Luc Oskar Purcell Randmaa
------------------------

This project showcases the essence of marine life, and allows students to experience underwater diving and data collection using a VR headset.

Features include:
- Walking and teleporting along the Lagoon or Kelp Forest floor
- Activating fish sampling areas to count and record fish
	- Fish highlights assist player
- Gauging coral bleach percentages for record-keeping
- Useful UI's attached to player's arms
	- Buttons to log data, switch between scenes, and exit game
	- Data is displayed on scenes interface
- Schools of a variety of marine life implemented using Boids
- Beautiful scenery complete with environmental design
	- Lighting, corals, sand, terrain, and caustics
	- Serene title screen
	- Fantastic music by Dylan

Controls: 
Right Hand Controller Features: 
    - Pull Trigger when Ray appears to teleport to a location
    - Move Joystick left and right to snap-turn player

Left Hand Controller Features:
    - Use JoyStick to move forwards, backwards, left, and right
    - Pull Trigger and angle controller up and down (while using the JoyStick) to swim upwards or downwards
    - Press Menu Button Or Y to open an in-game menu (select menu option using the right hand to touch the boxes)
    - Pull left trigger to select button on the pop-up menu. 
    - Press the menu button a second time or the X button to close the menu boxes. 

Wishlist Items:
- Animating player diving into the water from title screen
- Loading screens between scenes
- More environments such as Tropical Coral Reef
- A guidebook that contains information on all species of fish and marine life
- Picture tool to capture images
- Scuba diver experience with oxygen tank and compass

Obstacles to Overcome:
- Performance drops with boids and high-res models
- Fish clipping through terrain
- Caustics not working, random instances of shiny sand (When setting the graphics encoding to ASTC)
- Git repository fetch/clone/pull issues

The project files are built with Unity 2020.3.19f1 and use the Unity XR Package (among others).
