SELECT a.ApplicationId, a.EarliestPickup, u.UserFirstName, u.UserLastName FROM Applications a
JOIN AspNetUsers u ON a.Id = u.Id
WHERE a.FoodPostId = 10;
