# MVC網站練習寫給自己爽的
## 我就是一個硬要假掰使用微軟 \.Net Core MVC 架構在我是一顆爛蘋果上看看好不好開發的厭世博士生。
---
### 對，我期刊要趕出來，然後我竟然在這邊弄這個東西 🤪
---
1. 一開始先在指令列輸入"dotnet new mvc -o MvcWeb", -o 後面接的就是你的專案名稱，這裡我們用 MvcWeb當作我們的專案名稱\\
2. Scaffold功能 \
    2-1 要先創建模型 Model/Banner.cs\
    2-2 安裝Nuget套件 [link](https://docs.microsoft.com/zh-tw/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-5.0&tabs=visual-studio-code)\
    2-3 先使用 export PATH=$HOME/.dotnet/tools:$PATH 匯出scaffold 工具路徑\
    2-4 輸入cmd : 
    dotnet-aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
    -name 要新建的控制器名稱, -m 你剛剛建立的model.cs檔, -dc 哪個Migration檔名\
    2-5 輸入 dotnet ef migrations add InitialCreate 與dotnet ef database update 建立轉移紀錄檔與更新資料庫

---
3/22 2021 更新了後台可新增、刪除、修改Banner功能。

---

3/25 2021 更新後台可新增、刪除、修改頁籤功能。

---
07/01 2021
學習 Linq跟vue.js 方法應用於裡面...

---
07/03 2021
新增功能:後台的商品能夠上架與編輯
在 Edit.cshtml：
原本："form asp-action="Edit""
修正："form asp-action="Edit" method="post" enctype="multipart/form-data"> 才能重新編輯圖片"
預計作業：後台的商品能在前台顯示。 /Shop/Index.cshtml

---
07/06 2021
1. 商品已可於前台顯示
2. footer排版修正
3. 新增關於我們頁面(尚未建立對應的db model), 預計執行

---
07/07 2021
1. 建立關於我頁面中，成員的model(Employ.cs)
2. 目前成員後台功能只完成 Index部分，預計將 Create, Edit, Delete功能頁面完成。
3. 昨天搞的商城頁面很爛，預計使用 "https://startbootstrap.com/template/shop-homepage" & "https://github.com/StartBootstrap/startbootstrap-shop-item" 來更改排版。
---
07/10 2021
1. 目前只建完 create部分，愛睏啊。 (2:00 am)
2. 在 sysemployee/edit.cshtml 增加日曆選取功能。
3. sysemployee/edit.cshtml 顯示舊有的生日日期與圖片名稱。
4. sysemployee/create.cshtml 新增日曆選取功能。 

---
07/11 2021
1. AboutUs頁面，團隊成員可以從後台新增刪除修改，且照片，敘述等內容顯示正常。

---

08/02
預計導入會員註冊登入功能

---

08/02 2021
已初步導入會員註冊登入功能

參考此網址：https://docs.microsoft.com/zh-tw/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-5.0&tabs=netcore-cli

1. 因本專案使用sqlite，因此在導入 "dotnet add package Microsoft.EntityFrameworkCore.SqlServer" 需改成 "dotnet add package Microsoft.EntityFrameworkCore.Sqlite"

2. 執行 "dotnet aspnet-codegenerator identity --useDefaultUI" 會生成 Areas/Identity

3. 修改"IdentityHostingStartup.cs"檔裡面的 "options.UseSqlserver" 至 "options.UseSqlite"

4. 執行 "dotnet ef migrations add CreateIdentitySchema --context MvcWebIdentityDbContext" 與 "dotnet ef database update --context MvcWebIdentityDbContext"

5. 再依照參考網址裡修改"Startup.cs" 部分參數即可擁有 .net core 的註冊登入驗證功能頁面。

---

0807 2021\
承接上次，導入登入註冊頁面後，還需執行 "dotnet aspnet-codegenerator identity -dc ProjectName.Data.ApplicationDbContext --files "Account.Register;Account.Login" 就會生成 Login.cshtml & Register.cshtml 頁面可以客製化。

參考這個 Link: https://stackoverflow.com/questions/59818745/how-to-customize-the-login-page-of-asp-net-core-web-application-with-angular-ind

測試帳號: test@test.com
password: Test1234! (包含驚嘆號)

---

0808 2021

登入畫面，切版與css調整完成，也可順利登入。
註冊畫面，切版與css調整完成，也可順利註冊。

預計加入取消與返回按鈕至登入與註冊畫面。

---

0814 2021\
登入與註冊畫面已加上取消按鈕。

網站內容預計改成：新創資源整合平台的方向

---

0815 2021\
在新電腦 clone 完之後，如果遇到通常會遇到 .net core 版本過低 或者 coreclr 不支援。 可透過安裝新的 "brew install --cask dotnet-sdk" 跟 vscode 裡安裝 C# 套件 (coreclr不支援的解決方法)

---

0816 2021\
新增 News.html and News.css 正在切新創資源網頁的版面，目前導覽列RWD完成。

---

0817 2021\
News.html nav bar 部分切版完，但需增加 css 與 js 功能。

---

0819 2021\
將疫情資訊導入到頁面內(參考自關鍵評論網的網站)，預計將第一主體區的文章區塊做出來。

---

0820 2021\
將第一區塊的文章主體與右側小文章版面切版完成，預計執行第一區塊下方的小文章版面切版。

---

0821 2021\
第一區塊文章下方與熱門文章區塊切版完成，預計執行關鍵懶人包區塊切版。

---