# Hex To RGB (Unity)
A simple C# script that allows for creating UnityEngine Color32 variables via a hex code string

# Usage
import **ColorRGBExtension.cs**

```csharp
Color gray = "#7C9EA6".HexToRGB(100);   // modify alpha value (0-255)
Color darkGray = "#83A603".HexToRGB();
```
# Additional

You can check the color dark or light.

```csharp
Color gray = "#7C9EA6".HexToRGB(100);
if(gray.IsDarkColor())   // check luminance & YIC value
{

}
```
