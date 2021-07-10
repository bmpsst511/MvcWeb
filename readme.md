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
1. AboutU頁面，團隊成員可以從後台新增刪除修改，且照片，敘述等內容顯示正常。
