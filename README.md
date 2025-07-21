# PictureEditor 🎨🖼️

> **Refactoring a legacy WinForms picture editor with TDD**
> C# · .NET 6 · Windows Forms

---

## 1 · Context

This repository is a **fork** of an old WinForms image‑editing demo.
**Goal of the assignment (HES‑SO course *************************************************Test‑Driven Development*************************************************, Spring 2025)**:

1. *Start* from legacy, tightly‑coupled code.
2. *Refactor* step‑by‑step toward SOLID & layered architecture.
3. *Drive* every change with **unit tests**.

The branch history therefore shows many small commits such as *“Add IImageManager interface”*, *“Extract EdgeDetection to BL”*, *“Green test: Save() writes png”*…

---

## 2 · Functions (current state)

| ✔️ Status | Feature                                  | Layer                                                      |
| --------- | ---------------------------------------- | ---------------------------------------------------------- |
| ✅         | Load / Save JPG·PNG·BMP                  | `BusinessLayer.ImageManager` → `DAL.OutputInputFilesystem` |
| ✅         | Edge detection (Sobel, Prewitt …)        | `BusinessLayer.EdgeDetectionManager`                       |
| ✅         | Basic filters (B\&W, Swap, Magic Mosaic) | `BusinessLayer.FiltersManager`                             |
| ☑️        | Undo / Redo                              | *planned*                                                  |
| ☑️        | Integration tests (UI automation)        | *todo*                                                     |

> **Tip :** run the GUI via `dotnet run --project PictureEditor` and tests with `dotnet test`.

---

## 3 · Project structure

```
PictureEditor.sln
│
├── PictureEditor/          # WinForms GUI + presentation layer
│   ├── EditorGUI.cs        # Main form (controller)
│   └── BusinessLayer/      # BL interfaces & managers
│       ├── Interfaces/
│       └── Managers/
│
├── PictureEditor_Test/     # xUnit test project
│   └── …                   # Unit tests, fakes & fixtures
└── README.md (this file)
```

---

---

## 4 · Refactor log

| Commit   | Refactor                              | Tests added                      |
| -------- | ------------------------------------- | -------------------------------- |
| `08b93c` | Extract `IOutputInput` interface      | none                             |
| `1f4a1d` | Move file I/O to DAL                  | ✅ Save/Load round‑trip           |
| `27c5e8` | Extract `IEdgeDetection` & strategies | ✅ Sobel detects horizontal edges |
| `34fa77` | Replace static helpers with DI        | all tests green                  |

---

## 5 · AI assistance

* **GitHub Copilot** → quick XML‑doc, small refactors.
* **ChatGPT** → brainstorming safe edge‑cases & dependency inversion.
  *See original convos*: [1](https://chat.openai.com/share/eb8a620f-45d8-4e42-8843-c3566397dd10) · [2](https://chat.openai.com/share/21b383d5-c93c-4dd7-b940-e14fd1e3473c) · [3](https://chat.openai.com/share/7f4cdb70-4c38-44d2-8474-ec223f2f0f74) · [4](https://chat.openai.com/share/21b383d5-c93c-4dd7-b940-e14fd1e3473c)

---

## 6 · Authors

* **Elias Borrajo**
* Benjamin Keller
* Arthur Avez
