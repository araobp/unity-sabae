# Sabae city （福井県鯖江市）

[The location on the Google map](https://www.google.com/maps/place/Sabae,+Fukui/@35.9463339,136.1851007,19z).

(Work in progress)

<img src="/doc/screenshot_bus_driving.jpg" width=500px>

The image above is a screenshot of bus driving in the city.

## Demo

[YouTube]
https://youtu.be/NR9jN1WamqI

## Requirements

### 3D model of Sabae city in Japan (distributed under CC-BY license)

Its 3D model is provided in SketchUp format (skp) on the following web site (Japanese): https://www.city.sabae.fukui.jp/about_city/opendata/data_list/3d-shotengai.html

A modified version of the 3D model is included in this repo.

### Logicool F310 Gamepad

https://gaming.logicool.co.jp/products/gamepads/f310-gamepad.940-000137.html

## Code

[code](./SabaeCity)

## Sightseeing spots in the digital twin

<img src="/doc/spot1.jpg" width=400px>

<img src="/doc/spot2.jpg" width=400px>

<img src="/doc/spot3.jpg" width=400px>

<img src="/doc/spot4.jpg" width=400px>

<img src="/doc/spot5.jpg" width=400px>

## Render Streaming and WebGL

In the beginning of this project, I tested WebGL and Render Streaming to run this game on smartphones. But I gave up to use them for some reasons.

<img src="/doc/screenshot_pixel4.jpg" width=500px>

The image above is a screenshot of video streaming from Unity Render Steraming to Google Pixel4. My PC is not equipped with NVIDIA's GPU (software video encoding), but the latency of its streaming is very small.

[code](./SabaeCity_RenderStreamingTest) <= I leave it intact for a while. I use this signalling server for this: https://github.com/araobp/signalling-server.

Maybe, I will try out Furioos in future for mobile.

## Reference

- Unity Render Streaming: https://docs.unity3d.com/Packages/com.unity.renderstreaming@2.0/manual/index.html
- Mixamo: https://www.mixamo.com/#/
- Construction Simulator: https://www.bau-simulator.de/en
