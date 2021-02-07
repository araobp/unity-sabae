# Unity smart city （福井県鯖江市）

(Work in progress)

<img src="/doc/screenshot_pixel4.jpg" width=500px>

[The location on the Google map](https://www.google.com/maps/place/Sabae,+Fukui/@35.9463339,136.1851007,19z)

The image above is a screenshot of video streaming from Unity Render Steraming to Google Pixel4

My PC is not equipped with NVIDIA's GPU (software video encoding), but the latency of its streaming is very small.

## Demo

[YouTube]
- https://youtu.be/NR9jN1WamqI
- https://youtu.be/mACBBLufDp0

## Motivation

I expect that digital twin will become a killer-app for remote sales and remote marketing in the era of 5G.

## Goal of this project

- Run HTML5/WebGL-based digital twin of Sabae（鯖江）city on Chrome browser.
- Or stream 3D digital twin of the city to my smartphone via RTP media with help from WebRTC.
- Virtual tour in the city of 鯖江.
- Smart city simulation: surveillance cameras, traffic signals, bus driving, platform door operation in the station etc. 
- Remote tourist information services.

```
WebGL build (run it on a local PC)

  [3D digital twin of Sabae city on Unity] ---- download HTML5/WebGL ---> [Chrome/Edge browser on PC]


WebGL build with WebRTC's getDisplayMedia() (screen sharing)

                     Zoom, Teams, Skype or any other services supporting screen sharing
                       +------------------ [Signalling server] ---------------+
                       |                                                      |
  [3D digital twin of Sabae city on a browser] ---- RTP media ---> [Chrome/Safari browser on PC/smartphone]
  

Render Streaming (cloud gaming)

                       +------------------ [Signalling server] ---------------+
                       |                                                      |
  [3D digital twin of Sabae city on Unity] ---- RTP media ---> [Chrome/Safari browser on PC/smartphone]
                                          <-- remote control --
                
```

## 3D model of Sabae city in Japan (distributed under CC-BY license)

Its 3D model is provided in SketchUp format (skp) on the following web site (Japanese): https://www.city.sabae.fukui.jp/about_city/opendata/data_list/3d-shotengai.html

The 3D model is not included in this repo. Just download it, inport it into Assets folder and extract tectures and materials in the folder.

```
/Assets/SabaeCity/
```
## Code

 I am currently prioritizing WebGL-build over Render Streaming.
 
- [WebGL version](./SabaeCity_WebGL)
- [RenderStreaming](./SabaeCity)

## Signalling server for Unity Render Streaming

I use this signalling server for this project: https://github.com/araobp/signalling-server.

Note that WebGL build does not require such a signalling server.

## Sightseeing spots in the digital twin

<img src="/doc/spot1.jpg" width=400px>

<img src="/doc/spot2.jpg" width=400px>

<img src="/doc/spot3.jpg" width=400px>

<img src="/doc/spot4.jpg" width=400px>

<img src="/doc/spot5.jpg" width=400px>

## Reference

- Unity Render Streaming: https://docs.unity3d.com/Packages/com.unity.renderstreaming@2.0/manual/index.html
- Mixamo: https://www.mixamo.com/#/
- Construction Simulator: https://www.bau-simulator.de/en
