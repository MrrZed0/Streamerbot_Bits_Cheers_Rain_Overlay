# 💎 Streamerbot Bits Cheers Rain Overlay

A **dynamic Twitch Bits (Cheers) rain overlay** for **Streamer.bot** that visually celebrates cheers with animated falling and side-shooting bit icons.

This overlay creates an immersive effect where Twitch Bits:

* 🌧️ Fall from the top of the screen
* 💥 Shoot in from the sides
* 🧱 Land and stack at the bottom like a floor
* ⏱️ Persist for the full animation duration

![Image](https://github.com/MrrZed0/Streamerbot_Bits_Cheers_Rain_Overlay/blob/main/222222222222.gif?raw=true)

---

## ✨ Features

* 💎 Supports all Twitch Bits tiers:

  * 1
  * 100
  * 1000
  * 5000
  * 10000
* 📈 Scales visuals based on bits amount (1 → 1000+)
* 🎯 Automatically includes all lower tier bit icons
* 🌧️ Continuous falling animation for full duration (7000ms)
* 🧱 Floor stacking effect at bottom of screen
* ⚡ Real-time trigger via Streamer.bot WebSocket
* 🎬 Smooth, high-performance animation

---

## 📁 Files

```bash
overlay/
│
├── bits_rain_overlay.html
├── 1.gif
├── 100.gif
├── 1000.gif
├── 5000.gif
├── 10000.gif
```

---

## ⚙️ Requirements

* Streamer.bot (v1.0.4+)
* OBS Studio (or Streamer.bot overlay app)
* WebSocket enabled in Streamer.bot

---

## 🔧 Setup

### 1. Enable WebSocket in Streamer.bot

* Go to:

  ```
  Servers / Clients → WebSocket Server
  ```
* Enable it

Default:

```
ws://127.0.0.1:8080
```

---

### 2. Add Overlay to OBS

Add a **Browser Source**:

```
file:///C:/path/to/bits_rain_overlay.html
```

Recommended settings:

* ✔ Shutdown source when not visible → OFF
* ✔ Refresh browser when scene becomes active → OFF

---

### 3. Add Bit Icons

Place all `.gif` files in the same folder as the HTML:

```
1.gif
100.gif
1000.gif
5000.gif
10000.gif
```

---

## 📡 Streamer.bot C# Integration

### Required Argument

| Argument | Description            |
| -------- | ---------------------- |
| `bits`   | Number of bits cheered |

---

### Example C# Broadcast

```csharp
using System;

public class CPHInline
{
    public bool Execute()
    {
        try
        {
            int bits = 0;
            CPH.TryGetArg("bits", out bits);

            if (bits <= 0)
                bits = 1;

            string json =
                "{"
                + "\"type\":\"custom.bits.rain\","
                + "\"payload\":{"
                + "\"bits\":" + bits
                + "}"
                + "}";

            CPH.WebsocketBroadcastJson(json);

            CPH.LogInfo("[Bits Rain] Triggered with " + bits + " bits");

            return true;
        }
        catch (Exception ex)
        {
            CPH.LogError("[Bits Rain ERROR] " + ex.ToString());
            return false;
        }
    }
}
```

---

## 🎮 Behavior

When triggered:

1. Streamer.bot sends the `bits` value
2. Overlay determines which bit tiers to display:

   * `1000` → shows `1`, `100`, `1000`
   * `5000` → shows `1`, `100`, `1000`, `5000`
   * `10000` → shows all tiers
3. Bits begin:

   * Falling from top
   * Shooting from left/right
4. Bits land and stay at bottom (floor effect)
5. Animation continues for full **7000ms**
6. Overlay clears and waits for next trigger

---

## 🎬 Animation System

* **Top Rain**

  * Randomized spawn positions
  * Gravity-style fall animation

* **Side Burst**

  * Left/right velocity launch
  * Eases into resting position

* **Floor System**

  * Prevents overflow
  * Creates stacking illusion

---

## 🧪 Testing

In browser console:

```javascript
testBitsRain(1000);
```

---

## ⚠️ Notes

* Overlay runs for fixed **7000ms**
* Higher bits = more particles
* Avoid extremely high spam triggers (performance)
* Make sure WebSocket is connected

---

## 🚀 Optional Upgrades

* Screen shake for big bits (1000+)
* Sound effects per tier
* Glow/explosion on impact
* Particle trails
* Bit combo counter
* Queue system for multiple cheers

---

## ❤️ Credits

* Streamer.bot
* OBS Studio
* Twitch Bits assets

---

## 📜 License

Free to use, modify, and share.

- 

#cheeroverlay #twitchcheeroverlay #bitsoverlay #twitchbitsoverlay twitch cheer overlay twitch bits overlay streamer.bot twitch bits overlay streamer.bot twitch cheer overlay
