SELECT v.VillianName, COUNT(vm.MinionId) AS NumOfMinions FROM Villians as v
JOIN VilliansMinions as vm ON vm.VillianId = v.Id
GROUP BY v.VillianName
HAVING COUNT(vm.MinionId) >= 1
ORDER BY COUNT(vm.MinionId) desc

