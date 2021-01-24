# Unity smart city

(Work in progress)

<img src="/doc/screenshot_pixel4.jpg" width=500px>

The image above is a screenshot of video streaming from Unity Render Steraming to Google Pixel4

My PC is not equipped with NVIDIA's GPU (software video encoding), but the latency of its streaming is very small.

## Goal of this project

- Stream 3D digital twin of Sabae city to my smartphone via RTP media with help from WebRTC.
- Virtual tour in the city.
- Smart city simulation: surveillance cameras, traffic signals, self-driving buses, platform doors in the station etc. 

```
                       +------------------ [Signalling server] ---------------+
                       |                                                      |
  [3D digital twin of Sabae city on Unity] ---- RTP media ---> [Chrome browser on smartphone]
                                          <-- remote control --
                
```

## Signalling server for Unity Render Streaming

I use this signalling server for this project: https://github.com/araobp/signalling-server

## 3D model of Sabae city in Japan (distributed under CC-BY license)

Its 3D model is provided in SketchUp format (skp) on the following web site (Japanese): https://www.city.sabae.fukui.jp/about_city/opendata/data_list/3d-shotengai.html

The 3D model is not included in this repo. Just download it, inport it into Assets folder and extract tectures and materials in the folder.

```
/Assets/SabaeCity/
```

## Reference

- Unity Render Streaming: https://docs.unity3d.com/Packages/com.unity.renderstreaming@2.0/manual/index.html
