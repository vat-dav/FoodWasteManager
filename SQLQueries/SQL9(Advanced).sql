SELECT ApplicationId, EarliestPickup FROM FoodWasteManager.dbo.Applications WHERE ApplicationStatus = 'Approved'
ORDER BY EarliestPickup ASC;
