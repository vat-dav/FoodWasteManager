SELECT u.UserFirstName, u.UserLastName, COUNT(f.FoodPostId) AS FoodPostCount FROM AspNetUsers u
JOIN FoodPosts f ON u.Id = f.Id
GROUP BY u.UserFirstName, u.UserLastName HAVING COUNT(f.FoodPostId) > 3;
