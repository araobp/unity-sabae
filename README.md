# unity-smartcity

(Work in progress)

<img src="/doc/screenshot_pixel4.jpg" width=500px>

## Goal of this project

- Stream 3D digital twin of Sabae city to my smartphone via RTP media with help from WebRTC.
- Support remote control to control the robot "Kyle".
- Virtual tour in the city.

## 3D model of Sabae city in Japan (distributed under CC-BY license)

Its 3D model is provided in SketchUp format (skp) on the following web site (Japanese): https://www.city.sabae.fukui.jp/about_city/opendata/data_list/3d-shotengai.html

The 3D model is not included in this repo. Just down load it, inport it into Assets folder and extract tectures and materials in the folder.

## Signalling server for Unity Render Streaming

I use this signalling server for this project: https://github.com/araobp/signalling-server

## Requirements

All the following assets must be installed in the Assets folder properly:

- /[Aa]ssets/Standard Assets/
- /[Aa]ssets/Robot Kyle/
- /[Aa]ssets/SabaeCity/
