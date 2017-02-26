SELECT vm.VillianId AS [vId],
	   vm.MinionId AS [mId], 
	   v.VillianName AS [vName] ,
	   m.MinionName AS [mName],
	   t.TownName AS [tName]
FROM VilliansMinions as vm
JOIN Villians AS v ON v.Id = vm.VillianId
JOIN Minions AS m ON m.Id = vm.MinionId
JOIN Towns AS t ON t.Id = m.TownId