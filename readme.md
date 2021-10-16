
# Bullet Journal 子彈筆記

## 目的
為了記錄每天待辦事項和追求目標

## 主要功能
- 檢視當天待辦事項
- 新增、修改待辦事項狀態
- 待辦過久未完成警示
- 目標設定的功能
    1. 設置多個待辦以達成目標為作
    2. 提示醒目以警示自已
- 目標達成率警示

## 使用工具/框架
- 以 Dotnet core MVC 
- Entity Framework 
- PostgreSQL 

## 步驟
1. 建立資料庫表格
    1. 待辦事項
    2. 事項分類
    3. 成就目標 - 關聯待辦事項
    4. 警示條件等參數設定
2. 以表格建立模型
3. 設計畫面
    1. 每天待辦
    2. 待辦新增、維護
    3. 成就目標新增、維護，關聯的待辦事項維護
4. 決定流程、路由

## 資料庫設計
- 待辦事項 BJ_Todo  

| Column | Type | Length | PK | Null | Default |
| :- | :- | -: | :-: | :-: |-| 
|ID|integer|4 bytes|Y|N|nextval('SEQ_BJ_TODO_ID')||
|WorkTitle|varchar|20||N||
|Description|varchar|50||||
|WorkRankID|char|1||N|"3"|
|IsCompleted|char|1||N|"0"|
|CreateDate|varchar|8||N|current date|
|TargetDate|varchar|8|||current date|
|WorkTargetID|integer|4 bytes||||

- 重要性 BJ_WorkRank

| Column | Type | Length | PK | Null | Default |
| :- | :- | -: | :-: | :-: |-| 
|ID|char|1|Y|N||
|RankName|varchar|10||N||

- 成就目標 BJ_WorkTarget

| Column | Type | Length | PK | Null | Default|
| :- | :- | -: | :-: | :-: |-| 
|ID|integer|4 bytes|Y|N|nextval('SEQ_BJ_WORK_TARGET_ID')|
|TargetDescription|varchar|50||N|
|TargetDate|varchar|8||N||

- 待辦事項序列 SEQ_BJ_TODO_ID
    CREATE SEQUENCE IF NOT EXISTS SEQ_BJ_TODO_ID START 1;
- 成就目標序列 SEQ_BJ_WORK_TARGET_ID
    CREATE SEQUENCE IF NOT EXISTS SEQ_BJ_WORK_TARGET_ID START 1;

## 記錄遇到的問題
- 2021.10.16 
    - 畫面上沒必要顯示所有資料庫的欄位，這部分應該怎麼規劃處理。
    - EF 產生的 Context 應該是屬於什麼