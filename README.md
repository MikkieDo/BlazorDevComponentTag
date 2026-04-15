# Blazor Dev-Only Component Name Tag (DEBUG-Only Overlay)

A tiny, automatic way to show component names during development — without ever exposing them to end users.

---

## Why This Exists

If you’ve ever worked on a large Blazor application, you’ve probably asked yourself:

**“What component am I looking at right now?”**

Blazor doesn’t include built-in dev tools like React, Vue, or Angular that show component names in the UI.  
So developers often:

- guess  
- dig through markup  
- sprinkle temporary labels  
- or add debug text manually (and forget to remove it)

This pattern solves that problem **cleanly, automatically, and safely**.

---

## What It Does

This adds a small, faint component name tag to the corner of every page/component — but **only in DEBUG builds**.

- Developers see it  
- End users never see it  
- No hover tricks  
- No login checks  
- No duplication  
- No markup inside components  
- No risk of leaking into production  

It’s a **zero-maintenance**, **zero-risk**, **developer-only** diagnostic tool.

---

## How It Works

### 1. Create a base class

```csharp
using Microsoft.AspNetCore.Components;

namespace YourApp.Components
{
    public class DevComponentBase : ComponentBase
    {
        protected string DevComponentName =>
#if DEBUG
            GetType().Name;
#else
            string.Empty;
#endif
    }
}

