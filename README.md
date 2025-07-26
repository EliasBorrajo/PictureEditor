# PictureEditor **🎨🖼️**

> *Legacy WinForms image editor refactored to a clean, 3‑layer architecture with 100 % business‑layer test coverage.*

---

## 📚 Project Description

PictureEditor breathes new life into an outdated, tightly‑coupled WinForms image editor.
The codebase has been systematically refactored—following **Test‑Driven Development**—to a **Presentation ⇆ Business ⇆ Data** layered model. Users can open common image formats, apply a small set of filters and edge‑detection algorithms, and save the result, while developers benefit from a fully covered and easily extensible codebase.

With the architecture solidified, both **100 % business‑layer unit tests** and **automated UI tests** guarantee end‑to‑end behaviour.

## 🧪 Technologies Used

| Type         | Name                                     | Version / Notes                |
| ------------ | ---------------------------------------- | ------------------------------ |
| Language     | C#                                       | 10 (targeting .NET 6)          |
| Build Tool   | dotnet CLI                               | 6.x                            |
| Framework    | Windows Forms (WinForms)                 | .NET 6                         |
| Testing      | xUnit                                    | Unit & planned UI test harness |
| Mocking      | NSubstitute                              | Business‑layer test doubles    |
| DI Container | Microsoft.Extensions.DependencyInjection |                                |

## 🛠️ Testing Approach

* **Business Layer** – driven by **xUnit** and **NSubstitute** mocks, achieving 100 % line & branch coverage.
* **UI Layer** – validated by **fully automated WinForms UI tests**, ensuring reliable end‑to‑end coverage.

## 🎯 Learning Objectives

* **Understand** the benefits of a layered architecture on legacy code.
* **Apply** Test‑Driven Development to drive safe refactors.
* **Implement** dependency‑inversion via interfaces and DI.
* **Achieve** 100 % unit‑test coverage on the business layer.
* **Develop** automated tests for key WinForms UI elements to ensure end‑to‑end functionality.

## 🔧 Features

* Load / Save images (JPG, PNG, BMP).
* Apply up to three colour filters (Black‑&‑White, Swap, Magic Mosaic).
* Run up to three edge‑detection algorithms (Sobel, Prewitt, …).

## 🧠 Language Paradigm Principles

* ✅ Encapsulation & SOLID principles
* ✅ Dependency Injection
* ✅ Separation of Concerns

### Error Handling

Standard C# `try`/`catch` blocks wrap disk and image operations; failures bubble up to the UI layer through typed exceptions.

## 🏗 Project Structure

### Architecture

```
WinForms UI (Presentation)
      │  IImageManager  IEdgeDetection  IOutputInput
      ▼
+----------------------------------------------+
|   Business Layer – 100 % unit‑test coverage  |
|  · FiltersManager     · EdgeDetectionManager |
|                ImageManager                  |
+----------------------------------------------+
      │
      ▼
OutputInputFilesystem (Data Access Layer)
```

## 📘 Documentation & Diagrams

* User & developer docs in **[`Annexes/UserGuide.pdf`](https://github.com/EliasBorrajo/PictureEditor/blob/master/Annexes/UserGuide.pdf)**.
* Project presentation slides in **[`Annexes/Presentation.pptx`](https://github.com/EliasBorrajo/PictureEditor/blob/master/Annexes/Presentation.pptx)**.

## ✅ Tests & Validation

| Scope              | Tooling / Method                 | Status           |
| ------------------ | -------------------------------- | ---------------- |
| Business Layer     | xUnit + NSubstitute test doubles | ✅ 100 % coverage |
| Presentation Layer | Automated WinForms UI tests      | ✅ 100 % coverage |

## 📌 Success Criteria Table

| Criterion               | Status | Notes                     |
| ----------------------- | ------ | ------------------------- |
| Functional Requirements | ✅ Done | Core features implemented |
| Business‑Layer Coverage | ✅ Done | 100 % line & branch       |
| UI testing              | ✅ Done | 100 % automated UI tests  |

## 👤 Authors

* **Arthur Avez**
* **Elias Borrajo**
* **Benjamin Keller**

---

*Project completed for ****HES‑SO Valais, Module 625‑1 — Test‑Driven Development (Fall 2023)****.*
Professor: Dominique Genoud

