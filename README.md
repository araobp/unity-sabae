# Unity smart city （福井県鯖江市）

(Work in progress -- I am currently prioritizing WebGL-build over Render Streaming, because the time for downloading the game is not so long.)

<img src="/doc/screenshot_pixel4.jpg" width=500px>

[The location on the Google map](https://www.google.com/maps/place/Sabae,+Fukui/@35.9463339,136.1851007,19z)

The image above is a screenshot of video streaming from Unity Render Steraming to Google Pixel4

My PC is not equipped with NVIDIA's GPU (software video encoding), but the latency of its streaming is very small.

## Demo

[HTML5/WebGL]
- https://araobp.github.io/unity-smartcity/

[YouTube]
- https://youtu.be/NR9jN1WamqI
- https://youtu.be/mACBBLufDp0

## Motivation

I expect that digital twin with WebRTC will become a killer-app for remote sales and remote marketing in the era of 5G.

It will be something like a call center with digital twin.

This project is to prove that my expectaion on digital twin is right.

## Goal of this project

- Run HTML5/WebGL-based digital twin of Sabae（鯖江）city on Chrome browser.
- Or stream 3D digital twin of the city to my smartphone via RTP media with help from WebRTC.
- Virtual tour in the city of 鯖江.
- Smart city simulation: surveillance cameras, traffic signals, bus driving, platform door operation in the station etc. 
- Remote tourist information services.

```
WebGL build

  [3D digital twin of Sabae city on Unity] ---- HTML5/WebGL ---> [Chrome browser on PC]


Render Streaming
                       +------------------ [Signalling server] ---------------+
                       |                                                      |
  [3D digital twin of Sabae city on Unity] ---- RTP media ---> [Chrome browser on smartphone]
                                          <-- remote control --
                
```

## 3D model of Sabae city in Japan (distributed under CC-BY license)

Its 3D model is provided in SketchUp format (skp) on the following web site (Japanese): https://www.city.sabae.fukui.jp/about_city/opendata/data_list/3d-shotengai.html

The 3D model is not included in this repo. Just download it, inport it into Assets folder and extract tectures and materials in the folder.

```
/Assets/SabaeCity/
```

## Signalling server for Unity Render Streaming

I use this signalling server for this project: https://github.com/araobp/signalling-server

## Sightseeing spots in the digital twin

<img src="/doc/spot1.jpg" width=400px>

<img src="/doc/spot2.jpg" width=400px>

<img src="/doc/spot3.jpg" width=400px>

<img src="/doc/spot4.jpg" width=400px>

<img src="/doc/spot5.jpg" width=400px>

## Thoughts on realtime 3D

There are four ways I can come up with:

- WebGL build.
- Run a native build on a PC with WebRTC's screen sharing feature: navigator.mediaDevices.getDisplayMedia({video: true})
- Embed Unity Render Streaming in a game.
- Build a game for mobile: iOS and Android.

In my environment,
- WebGL build running on Chrome browser has been achiving good quality of 3D rendering, without a NVIDA GPU.
- Unity Render Streaming has been achiving better quality than WebRTC's screen sharing.

I am not a sales person of luxurious cars, so the 3D rendering quality of WebGL saffices for my goal.

And my conclusion:
- WebGL build for PC users.
- Unity Render Streaming for mobile users.

## Reference

- Unity Render Streaming: https://docs.unity3d.com/Packages/com.unity.renderstreaming@2.0/manual/index.html
- Mixamo: https://www.mixamo.com/#/
- Construction Simulator: https://www.bau-simulator.de/en
