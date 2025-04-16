SELECT DISTINCT f.FoodName, f.FoodQuantity FROM FoodPosts f
JOIN Applications a ON f.FoodPostId = a.FoodPostId;