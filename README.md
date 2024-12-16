Blazor WebAssembly サンプルの新規作成
=====================================

プロジェクトを作成する手順
--------------------------

*   `Visual Studio 2022 (Comunity Edition)` で `新規プロジェクトの作成` を選択
*   "新しいプロジェクトの作成"
    *   `Blazor Webassemply アプリ` を選択。`次へ`
*   "新しいプロジェクトを構成します"
    *   `プロジェクト名` と `場所` を入力して `次へ`  
        *   同じページの下部に、`プロジェクトは C:\..(中略)..\blazor_note` が表示されるため、内容を確認して次へ
        *   入力値は以下
            *   プロジェクト名 ... 任意のディレクトリ
            *   場所 ............ このプロジェクトでは、 `blazor_note`
*   "追加情報"
    `作成` を押下  
    *   フレームワーク ... .NET8.0(長期的なサポート)  
    *   チェックはデフォルトでチェックされたまま

配布用のビルド
--------------------------

```
dotnet publish -c Release
```

*   ビルド結果一式は `.\bin\Release\net8.0\publish\wwwroot\` 以下に作成される。  
    [.\bin\Release\net8.0\publish\wwwroot\index.html](./bin/Release/net8.0/publish/wwwroot/index.html) が
    ルート用 HTML。
    *   `.\bin\Release\net8.0\publish\wwwroot\` 以下一式を WEBサーバーに配置すれば、
        WebAssembly サンプル として動作する

*   詳細は [release.bat](./release.bat) を参照のこと

