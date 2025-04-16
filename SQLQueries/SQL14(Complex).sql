SELECT DISTINCT u.Id, u.UserFirstName, u.UserLastName FROM AspNetUsers u
WHERE u.Id IN (SELECT Id FROM Applications)
AND u.Id NOT IN (SELECT Id FROM FoodPosts);
