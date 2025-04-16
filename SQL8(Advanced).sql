SELECT * FROM FoodWasteManager.dbo.FoodPosts WHERE DatePosted >= DATEADD(day, -7, GETDATE());
