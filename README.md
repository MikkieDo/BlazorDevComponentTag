# Blazor Dev Component Tag  
A tiny, zero‑overhead developer helper that shows the name of the currently rendered component in the top‑right corner — **only in DEBUG mode**.  
Perfect for large Blazor apps where it’s easy to lose track of which component is rendering what.

---

## Features

- Shows the component name during development  
- Automatically disappears in Release/Production  
- No JavaScript  
- No configuration  
- No performance impact  
- Works in Blazor Server and WebAssembly  
- Drop‑in, copy‑paste friendly

---

## Installation

You can add this feature to any Blazor project in a few minutes.

---

## 1. Add the base class

Create a file named `DevComponentBase.cs`:

```csharp
using Microsoft.AspNetCore.Components;

namespace YourProjectName.SystemFileHelpers
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
```

---

## 2. Add the tag component

Create a file named `DevComponentTag.razor`:

```razor
#if DEBUG
<div class="dev-component-tag">@Name</div>
#endif

@code {
    [Parameter] public string Name { get; set; } = string.Empty;
}
```

---

## 3. Add the component‑scoped CSS

Create a file named:

```
DevComponentTag.razor.css
```

Place it **in the same folder** as `DevComponentTag.razor`.

```css
.dev-component-tag {
    position: absolute;
    top: 0;
    right: 0;
    opacity: 0.25;
    font-size: 0.7rem;
    pointer-events: none;
    z-index: 9999;
}
```

Blazor will automatically load this file — no `<link>` tag needed.

---

## 4. Add the tag to your layout or wrapper

In your layout or page wrapper (e.g., `ThePage.razor`):

```razor
#if DEBUG
<DevComponentTag Name="@DevComponentName" />
#endif
```

---

## 5. Inherit the base class in any component you want labeled

At the top of your component:

```razor
@using YourProjectName.SystemFileHelpers
@inherits DevComponentBase
```

---

## Done!

Every component that inherits `DevComponentBase` will now display its name in the corner during development — and never in production.

---

## License

MIT License. Free to use, modify, and share.


