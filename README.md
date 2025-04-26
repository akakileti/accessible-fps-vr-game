# Accessible VR FPS Controller Project (XR Access REU)

This project was developed as part of the XR Access Research Experience for Undergraduates (REU) hosted jointly by Columbia University and Cornell Tech during Summer 2023 under the supervision of Dr. Steven Feiner of Columbia University. Our goal was to create a more accessible virtual reality (VR) experience for Stewart, a quadriplegic gamer who uses a wheelchair and does not have motor control of his fingers.

## Project Overview

We created a custom first-person shooter (FPS) game in VR that allows Stewart to play using controls from a stylus-controlled Android phone, instead of standard VR controllers.

The game was based on [@moreharsh's open-source Unity FPS project](https://github.com/moreharsh/VR-FPS) and was modified to accommodate our custom input system.

## User Feedback Video

You can [watch a 1-minute video here](https://youtu.be/ETV7-_j2fmM) where Stewart describes his experience with the game and shares his thoughts on the adapted controller.

<p align="center">
  <a href="https://www.youtube.com/watch?v=ETV7-_j2fmM">
    <img src="https://img.youtube.com/vi/ETV7-_j2fmM/hqdefault.jpg" alt="Watch Stewart's Video" width="480">
  </a>
</p>

## Collaboration Notes

This project was developed collaboratively by Brennon Treadwell (@BTreadwell) and myself (@akakileti). Development was done entirely on Brennon’s machine, as his Windows system was compatible with the Oculus Quest 2 and Android phone we used for testing.

## Controller Design

- We built a custom controller interface on an Android phone.
- Stewart uses a stylus strapped to his hand, which he normally uses for gaming on an iPad.
- The controller interface maps stylus touches and gestures to movement and actions in the game.
- The goal was to match Stewart’s existing muscle memory and comfort with touchscreen interaction.

## Platform & Tools

- Oculus Quest 2
- Unity (based on [@moreharsh/VR-FPS](https://github.com/moreharsh/VR-FPS))
- Android (custom touch controller)
- Unity XR Plugin Management
