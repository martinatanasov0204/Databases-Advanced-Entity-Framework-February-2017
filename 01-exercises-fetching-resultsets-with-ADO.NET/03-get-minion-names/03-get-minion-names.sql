SELECT v.Id AS [vId], v.VillianName AS [vName], vm.MinionId, m.MinionName AS [mName], m.Age AS [mAge] FROM Villians AS v
JOIN VilliansMinions AS vm ON vm.VillianId = v.Id
JOIN Minions AS m ON m.Id = vm.MinionId