# Bullets vs. Beelzebub GDD

## Team Twick
**T**ony Cenaiko - Programmer, writer

**Wi**ll Frame - Programmer, designer

Ni**ck** Brown - Programmer, artist, writer

## Core concept

Play as an angel in hell - kills demons and Satan and escape. Frantic, fast paced combat against dozens of enemies at a time. Wanton carnage, large explosions, massive amounts of gore and viscera.

## Theme

Bullets vs. Beelzebub is a 2D top-down shooter set in hell, inspired by Diablo and John Wick.

## Game Overview

You play as an angel in hell, fighting off waves of demons which are trying to kill you. After each wave you receive an upgrade - the player can select from many perks such as reload speed, movement speed, health points, health regeneration, multishot, damage increase, and firing rate. 

## Fun features

The enjoyment from this game will mostly come from the satisfaction of excessive firepower towards waves of mostly small enemies. The amount of destruction and explosions will make the experience feel stress-relieving and very satisfying to play.

## Unique features

An angel with guns in hell seems quite nonsensical but considering the story at hand it fits perfectly.

## Goals

- Satisfying player feedback and destruction of enemies 
- Dark artwork and atmosphere
- Simple controls and almost minimalist interface
- Very violent but relaxing to play

## Non-goals

- Virtually no learning curve (maximum accessibility)
- Basically no worrying about resources like ammunition (except for explosives)

## Features

- Easy, medium, hard, and hardcore difficulties
- Global Leaderboards
- Alternative arena gamemode
- Controller support
- 5 different types of demons including one boss
- 15 different weapons (Pistol, Submachine Gun, Assault Rifle, Shotgun, Minigun, Flamethrower, Chainsaw, Sword, Grenade Launcher, Mines, Laser Rifle, Disc Gun, and three magic weapons)
- Primary and secondary weapon slots

## Sample users

- Friends of each member
- Other Computer Science students
- People from the Otago University Discord

## Target audience

People who want to relieve stress

People ages 13+ because of the violent themes and visuals of the game

Not much experience with gaming prior is required because of the simple controls and concepts.

## Characters

- Gabriel (the Angel) - A bright armoured angel with wings that allows it to fly throughout the level. The player controls this character.
- The Demons - Red monsters that travel towards the player in order to inflict damage. Various types of demons will have different sizes, movement patterns, abilities, and can take different amounts of abuse from the player.
- Beelzebub - Satan himself - a large boss that is a wave on its own. The toughest challenge the player will face.

## Story

You are the archangel Gabriel, who is on a revenge mission against Beezlebub that will take him through the layers of Hell. In between levels, you learn via snippets of flashbacks that Gabriel had a sick, dying wife, and through desperation made a pact with the Devil in order to save her. This pact required Gabriel to betray God and the Heavens - but after this was done his wife died of her illness, causing Gabriel to take up arms against Beezlebub.

## Aesthetic

The atmosphere is quite dark and gothic as it is set in hell, but the contrast of the angel in this setting should be quite pretty and very easy to spot your character and where your bullets are going. As an angel in hell you radiate quite a bit of light - outside of this radius of light it is a lot darker however you can still see where enemies are far away from you. We are going with a pixel art aesthetic. The world will become plastered with demon bodies and blood throughout each wave.

## Risks

- Possible high resource usage from the mass amounts of entities on the screen
- Might be hard to create challenges and balance the difficulties
- Enemy pathfinding could be quite difficult - with the large amounts of enemies they might get stuck and not be able to move

## Planning

### What questions need answered?

- How will weapons be obtained and managed from the user - should they be allowed to hold one or multiple at a time, which controls will dictate which weapon they are using, etc
- How do we want the enemies to act? 
- How do we want to deliver the story?
- How can we further develop the story?

### 4 week production schedule

## _First week_: Prototyping
- Get the basic mechanics working 
- Player movement
- World basics
- Camera movement
- Make an example weapon (select at main menu) and example enemy
- Flesh out the story
- Decide on specifics of the arena's visuals
At this point the game world should be able to be travelled through by the player. A weapon should also be able to be equipped.

## _Second week_: Alpha
- Start designing story specifics such as dialogue
- Decide on how we want to implement the story into the game
- Add more weapons and enemies with animations
- Detail the map
- Create sprites for the angel, the weapons, the projectiles, and different types of demons
- Add collisions to enemies with bullets
- Add sound effects for the angel, the weapons, and the demons
Now, the map should have more detail, and the user should be able to try out different weapons on the enemies.

## _Third week_: Beta
- Add main menu and GUI
- Start adding enemies to waves and balancing them
- Add weapon drops and picking up capabilities
- Add perks to select from after each wave
- Start balancing weapons and making them more fun to use
- Add score + combo tracking
- Finish soundtrack
Now the game should be playable as intended - the player should be able to load up the game and play against enemies with different weapons. All core game mechanics should be finished.

## _Fourth week_: Buffer/polishing week 
- Fix bugs
- Add finishing touches to visuals
- Polish the game as much as possible
If everything has gone smoothly; 
- Add endless arena gamemode
- Add scoreboards
- Add any other improvements
- Two player support if we have spare time.
This week will be used to refine the game, and if we have extra time, add features that aren't totally necessary but would be cool to add.

## Control Scheme

### _Keyboard_
WASD or arrow keys for movement

Move mouse to aim

Left click to shoot

Right click to change between primary and secondary weapon

Spacebar to pick up weapon

Escape to pause

### _Controller_

Left joystick to move

Right joystick to aim

Right trigger to fire

Left trigger to change weapon

Any D-pad direction to pick up weapon

Menu/Start button to pause

## Game Mechanics

### Basic game logic
The character moves around the level with the WASD keys. Enemies come from holes in each wall on each side of the arena. When the player runs out of health, they lose the game. When the player defeats all of the enemies in the wave, the game is over. The player can progress to the next wave when all of the enemies have been cleared from the wave. Weapons can be dropped from enemies as a reward. The final wave has one boss, and if killed, the player wins the game.

### Balancing
The enemies will start as being very easy to kill however they will get progressively harder throughout the game - however the game is meant to not be too challenging. Different difficulties can be selected if the player wants a challenge.

## Tech Overview
### Graphics
The graphics will be 2D pixel art with a dark, gothic art style that slowly descends into biblical horror as the game progresses.
### AI
Most enemies will simply rush the player and attempt to get into melee range, but some enemy types may keep their distance and use ranged attacks. Larger enemies will be slower and stronger than small enemies.
### Loading / saving (levels, game state etc)
When you die, all progress is lost and you restart the game from scratch.
### Anything unusual / pivotal in terms of technology used
Nothing really, we will have to make sure not to add too many enemies to the screen as it could have an impact on performance.

## Content overview - provide detail of how many, and what type things will be
### Levels
The level is a large island in the middle of a lava pool. The camera cannot encompass the whole level but it follows the player as they travel around the level. Bridges allows demons to travel onto the island from each edge of the screen - these lead off screen. The level is quite dark and gothic as it is set in hell, but the contrast of the angel in this setting should be quite pretty and very easy to spot your character and where your bullets are going.
### Powerups
The player can select from the following perks after each wave:
- Increased reload speed
- Increased movement speed
- Increased damage
- Increased resistance to enemy damage
- Increased health regeneration
- Multishot (increase amount of bullets)
- Increased firing rate
### Models/sprites
The angel will radiate light around it enabling clearer vision around the angel.
The demons will be red to contrast against the dark level.
All models and sprites will be pixel art.
### Sound/music
The main game music will be fast paced music - much like the Doom OST.
We will have demon screaming sounds.
The gunfire and explosions will be loud but not too jarring as it will be constant and we still want the players to hear the soundtrack.
### GUI
The GUI will be quite minimal - a small section of the bottom left corner which contains the face of the character (which will change depending on health), health points, score + combo, and two slots for weapons. The main menu will have buttons for new game, controls, credits, leaderboard, and a button to play the infinite arena gamemode.

## Pictures
Need to add screen layout, screen flow, aesthetic demonstration

![Gabriel (the Angel)](https://cdn.discordapp.com/attachments/1064303364906680320/1065776207376957530/20230120_122952.jpg)

![Beelzebub](https://cdn.discordapp.com/attachments/1064303364906680320/1065776206336770149/20230120_122926.jpg)

![Main menu](https://cdn.discordapp.com/attachments/1064303364906680320/1065835357876256858/menu.png)

(not final background art)

![Gameplay UI](https://cdn.discordapp.com/attachments/1064303364906680320/1065834762561933342/image.png)

![Level over screen](https://cdn.discordapp.com/attachments/1064303364906680320/1065821396724351036/image.png)

![Upgrades screen](https://cdn.discordapp.com/attachments/1064303364906680320/1065821396430766113/image.png)
