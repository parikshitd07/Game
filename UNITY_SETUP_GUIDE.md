# Unity Setup Guide - Home Decor Designer

## Quick Setup (Follow in Order)

### Step 1: Install Unity Hub (15-20 mins)
1. Download Unity Hub: https://unity.com/download
2. Install Unity Hub (drag to Applications folder)
3. Open Unity Hub
4. Sign in or create Unity account (free)

### Step 2: Install Unity Editor (20-30 mins)
1. In Unity Hub, go to "Installs" tab
2. Click "Install Editor"
3. Choose **Unity 2022.3 LTS** (recommended) or latest 2021 LTS
4. In modules, select:
   - ✅ Mac Build Support (Mono)
   - ✅ WebGL Build Support
   - ✅ Documentation
5. Click "Install" and wait for download

### Step 3: Create New Unity Project (2 mins)
1. In Unity Hub, go to "Projects" tab
2. Click "New Project"
3. Select **3D Core** template
4. Project name: `HomeDecorDesigner`
5. Location: `/Users/vivek4/Documents/Game/HomeDecorDesigner`
6. Click "Create Project"

### Step 4: Import Scripts (2 mins)
1. In Unity, locate the "Project" window (bottom)
2. Right-click in Assets folder → Create → Folder → Name it "Scripts"
3. Open Finder and navigate to: `/Users/vivek4/Documents/Game/UnityScripts/`
4. Drag all 5 .cs files into Unity's Scripts folder:
   - FurniturePlacement.cs
   - WallColorChanger.cs
   - AIDecorSuggestions.cs
   - UIManager.cs
   - CameraController.cs

### Step 5: Import Free Assets (10 mins)
1. In Unity, go to Window → Asset Store
2. Search and download these FREE asset packs:
   
   **Option A (Recommended - Simple):**
   - "Furniture Free Pack" by Exoa
   - "Simple Furniture - Cartoon Assets" 
   
   **Option B (Detailed):**
   - "FREE Furniture Set" by Vladyslav Horobets
   - "Room Interior Pack" (search free options)

3. Import the downloaded assets into your project

### Step 6: Create the Room (15 mins)

#### 6.1 Create Floor
1. GameObject → 3D Object → Plane
2. Name it "Floor"
3. Position: (0, 0, 0)
4. Scale: (2, 1, 2) - adjust for room size
5. Add tag "Floor": Inspector → Tag → Add Tag → "Floor"
6. Create Layer "Floor": Layers → Add Layer → "Floor"

#### 6.2 Create Walls
1. GameObject → 3D Object → Cube
2. Name it "Wall_North"
3. Position: (0, 2.5, 10)
4. Scale: (20, 5, 0.1)
5. Add tag "Wall"
6. Duplicate (Cmd+D) 3 times for other walls:
   - Wall_South: (0, 2.5, -10)
   - Wall_East: (10, 2.5, 0), Scale: (0.1, 5, 20)
   - Wall_West: (-10, 2.5, 0), Scale: (0.1, 5, 20)

#### 6.3 Add Lighting
1. GameObject → Light → Directional Light
2. Position: (0, 10, 0)
3. Rotation: (50, -30, 0)

### Step 7: Setup Camera (2 mins)
1. Select Main Camera in Hierarchy
2. In Inspector, click "Add Component"
3. Type "CameraController" and add the script
4. Set Distance: 15
5. Position: (0, 10, -15)

### Step 8: Create Furniture Prefabs (10 mins)
1. Drag imported furniture models into the scene
2. Position at (0, 0, 0)
3. Adjust scale if needed
4. Drag from Hierarchy to Assets/Prefabs folder to create prefab
5. Delete from scene
6. Repeat for 4-6 furniture items (chair, table, sofa, lamp, etc.)

### Step 9: Setup Game Manager (5 mins)
1. GameObject → Create Empty
2. Name it "GameManager"
3. Add Components:
   - FurniturePlacement script
   - WallColorChanger script
   - AIDecorSuggestions script
4. In FurniturePlacement:
   - Set Floor Layer to "Floor"
   - Drag furniture prefabs into Furniture Prefabs array
5. In AIDecorSuggestions:
   - Enter your OpenAI API key in the "Api Key" field

### Step 10: Create UI (15 mins)

#### 10.1 Setup Canvas
1. GameObject → UI → Canvas
2. Canvas Scaler → UI Scale Mode: Scale with Screen Size
3. Reference Resolution: 1920 x 1080

#### 10.2 Create Furniture Panel
1. Right-click Canvas → UI → Panel
2. Name: "FurniturePanel"
3. Position: Left side of screen
4. Add buttons for each furniture type
5. Label buttons: "Chair", "Table", "Sofa", etc.

#### 10.3 Create Color Panel
1. Right-click Canvas → UI → Panel
2. Name: "ColorPanel"
3. Position: Right side of screen
4. Add 7 buttons with different colors
5. Set button colors in Inspector

#### 10.4 Create AI Panel
1. Right-click Canvas → UI → Panel
2. Name: "AIPanel"
3. Position: Top center
4. Add:
   - InputField (TMP) for preference
   - Button labeled "Get AI Suggestions"
   - Button labeled "Clear Room"

#### 10.5 Create Info Text
1. Right-click Canvas → UI → Text (TMP)
2. Name: "InfoText"
3. Position: Bottom center
4. Font size: 24

### Step 11: Connect UI to Scripts (5 mins)
1. Create GameObject → Create Empty → Name "UIManager"
2. Add UIManager.cs script
3. Drag all UI elements to corresponding fields in Inspector:
   - Furniture buttons to Furniture Buttons array
   - Color buttons to Color Buttons array
   - Input field to Preference Input
   - Etc.
4. Connect references:
   - FurniturePlacement
   - WallColorChanger
   - AIDecorSuggestions

### Step 12: Test the Game (5 mins)
1. Click Play button (top center)
2. Test:
   - ✅ Click furniture buttons
   - ✅ Click on floor to place furniture
   - ✅ Click color buttons to change walls
   - ✅ Type "modern" in input, click "Get AI Suggestions"
   - ✅ Camera rotation with Q/E or arrow keys
   - ✅ Mouse scroll to zoom

### Step 13: Build the Game (10 mins)

#### For WebGL Build:
1. File → Build Settings
2. Select "WebGL"
3. Click "Switch Platform"
4. Click "Build"
5. Choose folder: `/Users/vivek4/Documents/Game/Build`
6. Wait for build to complete (5-10 mins)

#### For Mac Build:
1. File → Build Settings
2. Select "Mac"
3. Click "Build"
4. Choose folder and name: `HomeDecorDesigner.app`

## Troubleshooting

**Problem: Scripts won't compile**
- Solution: Check Unity version is 2021+ (required for some syntax)

**Problem: Furniture won't place**
- Solution: Make sure Floor has "Floor" tag and Layer set

**Problem: UI buttons don't work**
- Solution: Check EventSystem exists in Hierarchy (auto-created with Canvas)

**Problem: Camera doesn't move**
- Solution: Verify CameraController script is attached to Main Camera

**Problem: AI suggestions don't show**
- Solution: Check API key is entered, or test with fallback (it auto-uses fallback if key is empty)

## Time Estimate
- Total setup time: ~90-100 minutes
- Testing and adjustments: ~15 minutes
- Building: ~10 minutes

## Next Steps
After setup, see README.md for usage instructions and features.
