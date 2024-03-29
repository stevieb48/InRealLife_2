﻿-- populate scenarios table with test data
/*

INSERT INTO Scenario (Name, Description)
VALUES 
('Flat Tire', 'The vehicle that you are driving in starts to wobble ...'), 
('Laundry', 'Your clothes start to pile up in the corner of your room ...'), 
('Hunger', 'You are feeling hungry, so you see some cereal but you are out of milk ...'), 
('Cleanliness', 'You smell in odor and your not sure where it is coming from ...'), 
('Priorities', 'A programming assignment due tomorrow and your friend is having a get together at his house ...');

*/

change
-- populate stages table with test data
/*

INSERT INTO Stage (Name, Description, ScenarioID, AudioFilePath, ImageFilePath, Answer1ID, Ans1NextStagID, Answer2ID, Ans2NextStagID, Start)
VALUES 
('Pull Over or Keep Driving', 'You see a place to pull over on the busy highway or ...', NULL, 'C:\user\test\docs\audiofiles\audioFile1', 'C:\user\test\docs\imageFiles\imageFile1', NULL, NULL, NULL, NULL, 1),
('Safe Place or Keep Driving', 'You see a safe place to pull over away from busy highway or ...',  NULL, 'C:\user\test\docs\audiofiles\audioFile2', 'C:\user\test\docs\imageFiles\imageFile2', NULL, NULL, NULL, NULL, 0),
('Turnup radio or turndown radio', 'Turn up radio and ignore or ...',  NULL, 'C:\user\test\docs\audiofiles\audioFile4', 'C:\user\test\docs\imageFiles\imageFile4', NULL, NULL, NULL, NULL, 0),
('Inspect vehicle or call mom', 'Get out of vehicle and inspect for problems or ...',  NULL, 'C:\user\test\docs\audiofiles\audioFile3', 'C:\user\test\docs\imageFiles\imageFile3', NULL, NULL, NULL, NULL, 0),
('mom AAA or fix it yourself', 'Mom is busy and says call AAA or ...',  NULL, 'C:\user\test\docs\audiofiles\audioFile5', 'C:\user\test\docs\imageFiles\imageFile5', NULL, NULL, NULL, NULL, 0),
('Fixing a flat', 'Pull out the jack and lift vehicle or turn off vehicle and inspect the spare ...',  NULL, 'C:\user\test\docs\audiofiles\audioFile6', 'C:\user\test\docs\imageFiles\imageFile6', NULL, NULL, NULL, NULL, 0);



UPDATE Stage
SET Answer1ID = 5, Ans1NextStagID = 6, Answer2ID = 6
WHERE ID = 4;

select * from stage where ID = 4;


*/

change
-- populate answers	table
/*

INSERT INTO Answer (Name, Description)
VALUES ('Pull Over', 'Pull your vehicle over on a busy highway'),
('Keep Driving', 'Keep driving and find a safer area'),
('Turn up radio', 'Turn up radio and speed up'),
('Turn down radio', 'Turn down radio and slow down'),
('Ignore', 'Ignore and keep driving'),
('Inspect vehicle', 'Inspect vehicle tires for proper working order'),
('Call Mom', 'Call mom even though you know she is in a meeting right now');

*/