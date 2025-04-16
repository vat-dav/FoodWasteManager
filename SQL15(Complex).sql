SELECT TOP 5 f.FoodName, COUNT(a.ApplicationId) AS ApplicationCount FROM FoodPosts f
JOIN Applications a ON f.FoodPostId = a.FoodPostId
GROUP BY f.FoodName
ORDER BY ApplicationCount DESC;
