# Unity smart city （福井県鯖江市）

[The location on the Google map](https://www.google.com/maps/place/Sabae,+Fukui/@35.9463339,136.1851007,19z).

(Work in progress)

<img src="/doc/screenshot_bus_driving.jpg" width=500px>

The image above is a screenshot of bus driving in the city.

<img src="/doc/screenshot_pixel4.jpg" width=500px>

The image above is a screenshot of video streaming from Unity Render Steraming to Google Pixel4. My PC is not equipped with NVIDIA's GPU (software video encoding), but the latency of its streaming is very small.

## Demo

[YouTube]
- https://youtu.be/NR9jN1WamqI
- https://youtu.be/mACBBLufDp0

## Motivation

- I expect that digital twin will become a killer-app for remote sales and remote marketing in the era of 5G.
- I want to show what DX really means to those who are not familiar with 3D.

## Goal of this project

- Virtual tour in the city of 鯖江.
- Smart city simulation: surveillance cameras, traffic signals, bus driving, platform door operation in the station etc. 
- Remote tourist information services.

## 3D model of Sabae city in Japan (distributed under CC-BY license)

Its 3D model is provided in SketchUp format (skp) on the following web site (Japanese): https://www.city.sabae.fukui.jp/about_city/opendata/data_list/3d-shotengai.html

The 3D model is not included in this repo. Just download it, inport it into Assets folder and extract tectures and materials in the folder.

```
/Assets/SabaeCity/
```
## Code

- [Without RenderStreaming](./SabaeCity2) <= I am currently working on this.
- [With RenderStreaming](./SabaeCity) <= I leave it intact for a while. I use this signalling server for this: https://github.com/araobp/signalling-server.

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
