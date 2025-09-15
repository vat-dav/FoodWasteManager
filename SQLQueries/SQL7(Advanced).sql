SELECT DISTINCT f.FoodName, f.FoodQuantity FROM FoodWasteManager.dbo.FoodPosts f
JOIN FoodWasteManager.dbo.Applications a ON f.FoodPostId = a.FoodPostId;