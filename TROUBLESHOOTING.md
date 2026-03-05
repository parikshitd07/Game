# Troubleshooting Guide

## Unity Installation Permission Error (EACCES)

### Problem
Unity Hub shows: `Install failed: EACCES: permission denied, mkdir '/Applications/Unity'`

### Solution Options

#### Option 1: Fix Permissions (Recommended - 2 mins)
1. Open Terminal
2. Run this command:
   ```bash
   sudo mkdir -p /Applications/Unity
   sudo chown -R $(whoami) /Applications/Unity
   ```
3. Enter your Mac password when prompted
4. Go back to Unity Hub
5. Click the retry button (circular arrow icon)

#### Option 2: Install to Different Location (Faster - 1 min)
1. In Unity Hub, click the X to cancel current installation
2. Click "Install Editor" again
3. Click "Advanced Options" or "Change Location"
4. Choose a custom path: `/Users/vivek4/UnityEditors/`
5. Continue with installation

#### Option 3: Quick Alternative - Use Unity Play (No Installation)
If time is critical:
1. Cancel Unity installation
2. We'll create a **web-based version** using Three.js instead
3. This takes only 30-40 minutes total
4. Still meets all assignment requirements

---

## After Fixing Permissions

Once Unity installs successfully:
1. Continue from **Phase 3** in QUICK_START.md
2. Create the HomeDecorDesigner project
3. Follow the remaining steps

---

## Other Common Issues

### Unity Hub Won't Open
- Right-click Unity Hub → Open (to bypass security)
- Or: System Preferences → Security & Privacy → Allow

### Unity Editor Download is Slow
- Use a different internet connection if possible
- Or switch to web-based approach (see Option 3 above)

### Can't Sign In to Unity
- Create account at unity.com first
- Use "Sign in with Google" for faster setup

---

## Emergency: Switch to Web-Based Version

If Unity continues to have issues and time is running out, I can quickly create a Three.js web version that:
- Takes only 30-40 minutes
- Runs in any browser
- Meets all assignment requirements
- Uses your OpenAI API key for real AI
- No installation needed

Just let me know!
