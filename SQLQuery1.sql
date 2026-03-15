SELECT u.Id, u.Name, u.Surname, u.Age,p.Title
FrOm Users u
JOIN Posts p ON u.Id = p.UserId;

SELECT (u.Name+' '+u.Surname) as FullName, COUNT(p.Id) as PostCount 
FROM Users u
LEFT JOIN Posts p ON u.Id = p.UserId
GROUP BY u.Name, u.Surname;