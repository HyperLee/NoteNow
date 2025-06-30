# GitHub Copilot 指示

本專案是一個 .NET 8.0 控制台應用程式，主要用於 LeetCode 演算法題目練習和測試。

## 核心命令

### 建構與執行
- **建構專案**: `dotnet build` 或使用 VS Code 任務 "build"
- **執行專案**: `dotnet run --project NoteNow/NoteNow.csproj` 或使用 VS Code 任務 "run"
- **偵錯**: 按 F5 或使用 VS Code 偵錯設定 "Launch .NET Core App"

### 開發工具
- **還原相依套件**: `dotnet restore`
- **清理**: `dotnet clean`
- **測試**: `dotnet test` (目前專案未包含測試專案)

## 專案架構

### 技術棧
- **.NET 8.0**: 目標框架
- **C#**: 主要程式語言
- **控制台應用程式**: 應用程式類型

### 專案結構
```
NoteNow/
├── NoteNow.sln              # 解決方案檔案
├── NoteNow/
│   ├── NoteNow.csproj       # 專案檔案
│   └── Program.cs           # 主程式進入點
├── .vscode/                 # VS Code 設定
│   ├── launch.json          # 偵錯設定
│   └── tasks.json           # 任務設定
└── .github/
    └── workflows/
        └── dotnet.yml       # CI/CD 管道
```

### 程式碼組織
- **主程式類別**: `Program` 類別包含 `Main` 方法和演算法實作
- **演算法實作**: 每個 LeetCode 題目實作為獨立方法
- **測試案例**: 在 `Main` 方法中包含多組測試資料驗證

## 程式碼風格規範

### 命名慣例
- **類別名稱**: PascalCase (如 `Program`)
- **方法名稱**: PascalCase (如 `FindLHS`, `TwoSum`)
- **變數名稱**: camelCase (如 `nums`, `target`, `maxLength`)
- **常數**: PascalCase 或 UPPER_CASE

### 註解規範
- **XML 文件註解**: 所有公開方法必須包含 `<summary>` 標籤
- **題目資訊**: 包含 LeetCode 題目編號、標題和連結
- **解題思路**: 詳細說明演算法概念和步驟
- **複雜度分析**: 標註時間和空間複雜度
- **中文註解**: 使用繁體中文進行註解和說明

### 程式碼組織
- **方法分離**: 不同解法實作為獨立方法 (如 `FindLHS`, `FindLHS2`)
- **測試案例**: 使用多組測試資料驗證演算法正確性
- **結果驗證**: 比較不同解法的結果一致性
- **清晰輸出**: 測試結果包含案例編號和說明

## 專案特定規則

### LeetCode 題目實作
- 每個題目包含詳細的中文解題說明
- 提供多種解法比較 (如雜湊表法 vs 暴力法)
- 包含時間和空間複雜度分析
- 使用實際測試案例驗證

### 測試資料格式
- 標示測試案例組別 (如 "測試案例 1", "測試案例 2")
- 提供預期結果說明
- 比較不同解法的結果一致性

### 除錯支援
- VS Code 偵錯設定已配置完成
- 支援中斷點除錯
- 包含建構前置任務

## CI/CD

- **GitHub Actions**: 自動化建構和測試
- **目標平台**: Ubuntu latest
- **.NET 版本**: 8.0.x
- **觸發條件**: push 到 main 分支或 pull request

## 開發環境

- **推薦編輯器**: Visual Studio Code
- **必要擴充功能**: C# Dev Kit, .NET Core 支援
- **偵錯**: F5 啟動偵錯，支援中斷點
- **任務執行**: Ctrl+Shift+P → "Tasks: Run Task"
