# Quick Start Guide - 2 Hour Timeline

## ⏰ Time Breakdown
- Unity Installation: 20-30 mins
- Project Setup: 30-40 mins  
- Testing: 10 mins
- Building: 10 mins
- Video Recording: 5 mins
- **Total: ~90-105 mins** (leaving buffer time)

---

## 🚀 START HERE - Step by Step

### Phase 1: Installation (Start NOW - 25 mins)

#### Step 1.1: Download Unity Hub (5 mins)
```
1. Open browser: https://unity.com/download
2. Click "Download Unity Hub" (macOS)
3. Open the downloaded file
4. Drag Unity Hub to Applications folder
5. Open Unity Hub from Applications
```

#### Step 1.2: Create Unity Account (2 mins)
```
1. In Unity Hub, click "Sign in"
2. Create account (or sign in if you have one)
3. Choose "Personal" license (FREE)
```

#### Step 1.3: Install Unity Editor (20 mins - runs in background)
```
1. Click "Installs" tab in Unity Hub
2. Click "Install Editor"
3. Choose "2022.3 LTS" (recommended)
4. Select these modules:
   ✅ Mac Build Support (Mono)
   ✅ WebGL Build Support
5. Click "Install" 
6. LET THIS RUN IN BACKGROUND - Continue to Phase 2
```

---

### Phase 2: While Unity Installs - Prepare Assets (During installation)

#### Step 2.1: Set Up OpenAI API Key
```
1. Go to: https://platform.openai.com/api-keys
2. Log in (or create account)
3. Click "Create new secret key"
4. Copy the key (you'll need this later)
5. Keep it in a text file temporarily
```

#### Step 2.2: Review Scripts
```
1. Open Visual Studio Code
2. Review the scripts in UnityScripts folder:
   - FurniturePlacement.cs
   - WallColorChanger.cs
   - AIDecorSuggestions.cs
   - UIManager.cs
   - CameraController.cs
```

---

### Phase 3: Create Unity Project (5 mins - after installation completes)

```
1. In Unity Hub, go to "Projects" tab
2. Click "New Project"
3. Select "3D Core" template
4. Name: HomeDecorDesigner
5. Location: /Users/vivek4/Documents/Game/HomeDecorDesigner
6. Click "Create Project"
7. Wait for Unity to open (2-3 mins)
```

---

### Phase 4: Import Scripts (2 mins)

```
1. In Unity Project window (bottom):
   - Right-click in Assets
   - Create → Folder → "Scripts"
   
2. Open Finder, navigate to:
   /Users/vivek4/Documents/Game/UnityScripts/
   
3. Select all 5 .cs files
4. Drag into Unity Scripts folder
5. Wait for compilation (30 seconds)
```

---

### Phase 5: Get Free Assets (10 mins)

#### Option A: Simple Furniture (RECOMMENDED for speed)
```
1. Window → Asset Store
2. Search: "Simple Furniture"
3. Download "Furniture Free Pack" or similar
4. Import into project
```

#### Option B: Create Basic Furniture (if Asset Store is slow)
```
1. GameObject → 3D Object → Cube
2. Scale to furniture size
3. Rename (Chair, Table, etc.)
4. Create 4-5 basic shapes
5. Drag to Prefabs folder
```

---

### Phase 6: Build the Room (15 mins)

#### 6.1 Create Floor (2 mins)
```
1. GameObject → 3D Object → Plane
2. Name: "Floor"
3. Position: (0, 0, 0)
4. Scale: (2, 1, 2)
5. Inspector → Tag → Add Tag → "Floor"
6. Layer → Add Layer → "Floor"
7. Set tag AND layer to "Floor"
```

#### 6.2 Create Walls (3 mins)
```
1. GameObject → 3D Object → Cube
2. Name: "Wall_North"
3. Position: (0, 2.5, 10), Scale: (20, 5, 0.1)
4. Tag: "Wall"
5. Duplicate (Cmd+D) 3 times for other walls:
   - Wall_South: (0, 2.5, -10), Scale: (20, 5, 0.1)
   - Wall_East: (10, 2.5, 0), Scale: (0.1, 5, 20)
   - Wall_West: (-10, 2.5, 0), Scale: (0.1, 5, 20)
```

#### 6.3 Setup Camera (2 mins)
```
1. Select "Main Camera"
2. Add Component → CameraController
3. Position: (0, 10, -15)
4. Rotation: (30, 0, 0)
```

#### 6.4 Add Lighting (1 min)
```
1. GameObject → Light → Directional Light
2. Position: (0, 10, 0)
3. Rotation: (50, -30, 0)
```

#### 6.5 Create Game Manager (3 mins)
```
1. GameObject → Create Empty
2. Name: "GameManager"
3. Add Component → FurniturePlacement
4. Add Component → WallColorChanger
5. Add Component → AIDecorSuggestions
6. In AIDecorSuggestions:
   - Paste your OpenAI API key
```

#### 6.6 Setup Furniture Prefabs (4 mins)
```
1. Create Assets/Prefabs folder
2. Drag furniture models into scene
3. Adjust size/position
4. Drag from Hierarchy to Prefabs folder
5. Delete from scene
6. Repeat for 4-6 furniture items
7. In GameManager → FurniturePlacement:
   - Set array size to number of prefabs
   - Drag each prefab into array
   - Set Floor Layer
```

---

### Phase 7: Create UI (15 mins)

#### 7.1 Canvas Setup (1 min)
```
1. GameObject → UI → Canvas
2. Canvas Scaler → UI Scale Mode: Scale with Screen Size
3. Reference Resolution: 1920 x 1080
```

#### 7.2 Furniture Buttons (5 mins)
```
1. Right-click Canvas → UI → Panel
2. Name: "FurniturePanel"
3. Position: Left side (X: -600, Y: 0)
4. Size: (200, 600)
5. Add 4-6 Buttons (Right-click Panel → UI → Button)
6. Label each: "Chair", "Table", "Sofa", etc.
```

#### 7.3 Color Buttons (4 mins)
```
1. Right-click Canvas → UI → Panel
2. Name: "ColorPanel"
3. Position: Right side (X: 600, Y: 0)
4. Size: (200, 400)
5. Add 7 Buttons
6. Set button colors in Inspector (Image → Color)
```

#### 7.4 AI Panel (3 mins)
```
1. Right-click Canvas → UI → Panel
2. Name: "AIPanel"
3. Position: Top (X: 0, Y: 400)
4. Add Input Field (TMP)
5. Add 2 Buttons: "Get Suggestions", "Clear Room"
```

#### 7.5 Info Text (2 mins)
```
1. Right-click Canvas → UI → Text (TMP)
2. Name: "InfoText"
3. Position: Bottom (X: 0, Y: -450)
4. Font Size: 24
```

---

### Phase 8: Connect UI (5 mins)

```
1. GameObject → Create Empty → "UIManager"
2. Add Component → UIManager
3. Drag UI elements to script fields:
   - All furniture buttons → Furniture Buttons array
   - All color buttons → Color Buttons array
   - Input field → Preference Input
   - Buttons → Get Suggestions, Clear Room
4. Drag GameManager components:
   - FurniturePlacement
   - WallColorChanger
   - AIDecorSuggestions
```

---

### Phase 9: Test (5 mins)

```
1. Click Play button (top center)
2. Test each feature:
   ✅ Furniture placement
   ✅ Wall colors
   ✅ AI suggestions (type "modern", click button)
   ✅ Camera controls
   ✅ Clear room
3. Fix any issues
4. Click Play to stop
```

---

### Phase 10: Build (10 mins)

#### WebGL Build:
```
1. File → Build Settings
2. Select "WebGL"
3. Click "Switch Platform" (wait 2-3 mins)
4. Click "Build"
5. Create folder: /Users/vivek4/Documents/Game/Build
6. Wait for build (5-8 mins)
```

#### Mac Build (Alternative - faster):
```
1. File → Build Settings
2. Select "Mac"
3. Click "Build"
4. Save as: HomeDecorDesigner.app
5. Build completes in 3-5 mins
```

---

### Phase 11: Record Videos (5 mins)

#### Demo Video (2-3 mins):
```
1. Open QuickTime Player
2. File → New Screen Recording
3. Click Record, select area
4. Run your build
5. Demonstrate:
   - Place furniture
   - Change wall colors
   - Get AI suggestions
   - Apply a suggestion
   - Show camera controls
6. Stop recording
7. Save as: HomeDecor_Demo.mov
```

#### Personal Video (2 mins):
```
1. QuickTime → File → New Movie Recording
2. Record your introduction:
   - Name and background
   - Why Metadome
   - Relevant skills
   - Enthusiasm for role
3. Save as: Personal_Introduction.mov
```

---

## 🆘 Emergency Shortcuts

**If Running Out of Time:**

1. **Skip Asset Store** - Use basic cube furniture
2. **Simplified UI** - Just 2-3 buttons each panel
3. **Use Fallback AI** - Don't set API key, uses built-in styles
4. **Mac Build Only** - Skip WebGL (much faster)
5. **Quick Video** - 1 minute demos are acceptable

**Critical Priorities:**
1. ✅ Working furniture placement
2. ✅ Working wall colors  
3. ✅ AI suggestions (even just fallback)
4. ✅ One working build
5. ✅ Both videos

---

## ✅ Final Checklist

Before submitting:
- [ ] Build runs without errors
- [ ] Can place at least 3 furniture types
- [ ] Wall colors change
- [ ] AI suggestions display (fallback OK)
- [ ] Camera moves
- [ ] Demo video recorded (2-3 mins)
- [ ] Personal video recorded (2 mins)
- [ ] README.md included
- [ ] UNITY_SETUP_GUIDE.md included

---

## 🎯 You've Got This!

Follow this guide step by step. The setup is front-loaded (Unity installation), but once that's done, the rest moves quickly. Stay focused, skip perfectionism, and prioritize functionality over polish!

**Current Time Check:** You have approximately 2 hours. Start Unity installation NOW!
