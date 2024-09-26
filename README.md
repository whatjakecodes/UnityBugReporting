# Bug Reporting

## Light `renderLayerMask` not editable at runtime

### Reproduction steps

1. Open scene `LightRenderLayerMaskBugScene`
2. Press play
3. Press Spacebar to toggle the `renderLayerMask` of the scene's Directional Light

### Expected

In the scene, `Cube.RL0` and `Cube.RL1` should alternate being lit on Spacebar press 
as the Directional Light `renderLayerMask` is toggled between `RL0` and `RL1` via the script in `Assets\Scripts\DemonstrateLightRenderLayerBug.cs`.

### Actual:

The Directional Light `renderLayerMask` is NOT changed at all during runtime.
