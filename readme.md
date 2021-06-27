1.一開始先在指令列輸入"dotnet new mvc -o MvcWeb", -o 後面接的就是你的專案名稱，這裡我們用 MvcWeb當作我們的專案名稱
2. Scaffold功能
    2-1 要先創建模型 Model/Banner.cs
    2-2 安裝Nuget套件 link:https://docs.microsoft.com/zh-tw/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-5.0&tabs=visual-studio-code
    2-3 先使用 export PATH=$HOME/.dotnet/tools:$PATH 匯出scaffold 工具路徑
    2-4 輸入cmd : dotnet-aspnet-codegenerator controller -name BannerController -m MVCWebDB -dc MvcWebContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries， -name 要新建的控制器名稱, -m 你剛剛建立的model.cs檔, -dc 哪個Migrarion檔名
    2-5 輸入 dotnet ef migrations add InitialCreate 與dotnet ef database update 建立轉移紀錄檔與更新資料庫