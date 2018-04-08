-- QUERIES FOR THE APPLICATION C# NEED TESTING

	-- QUERY FOR SCENARIO BUILDER MAIN MENU LISTVIEW
	-- "SELECT ID, Name FROM Scenario WHERE ID = "

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF PERFORMS SELECTED SCENARIO FROM LISTVIEW
		-- "SELECT ID, Name FROM Scenario WHERE ID = "

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF CREATES A NEW SCENARIO FROM LISTVIEW
		-- SEE "BELOW"

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF EDITS SELECTED SCENARIO FROM LISTVIEW
		-- "SELECT * FROM Scenario WHERE ID = "

		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF DELETES SELECTED SCENARIO FROM LISTVIEW
		-- "DELETE * FROM Scenario WHERE ID = "
		
		-- QUERY FOR SCENARIO BUILDER MAIN MENU IF RELATE SELECTED SCENARIO FROM LISTVIEW
		-- SEE "BELOW2"
		
		
	-- QUERY FOR STAGE BUILDER MAIN MENU LISTVIEW		
		-- QUERY FOR STAGE BUILDER MAIN MENU IF PERFORMS SELECTED STAGE FROM LISTVIEW
		-- "SELECT ID, Name FROM Stage WHERE ID = "

		-- QUERY FOR STAGE BUILDER MAIN MENU IF CREATES A NEW STAGE FROM LISTVIEW
		-- SEE "BELOW"

		-- QUERY FOR STAGE BUILDER MAIN MENU IF EDITS SELECTED STAGE FROM LISTVIEW
		-- "SELECT * FROM Stage WHERE ID = "

		-- QUERY FOR STAGE BUILDER MAIN MENU IF DELETES SELECTED STAGE FROM LISTVIEW
		-- "DELETE * FROM Stage WHERE ID = "
		
		-- QUERY FOR STAGE BUILDER MAIN MENU IF RELATE SELECTED SCENARIO FROM LISTVIEW
		-- SEE "BELOW2"
		
		
	-- QUERY FOR ANSWER BUILDER MAIN MENU LISTVIEW		
		-- QUERY FOR ANSWER BUILDER MAIN MENU IF PERFORMS SELECTED ANSWER FROM LISTVIEW
		-- "SELECT ID, Name FROM Answer WHERE ID = "

		-- QUERY FOR ANSWER BUILDER MAIN MENU IF CREATES A NEW ANSWER FROM LISTVIEW
		-- SEE "BELOW"

		-- QUERY FOR ANSWER BUILDER MAIN MENU IF EDITS SELECTED ANSWER FROM LISTVIEW
		-- "SELECT * FROM Answer WHERE ID = "

		-- QUERY FOR ANSWER BUILDER MAIN MENU IF DELETES SELECTED ANSWER FROM LISTVIEW
		-- "DELETE * FROM Answer WHERE ID = "
		
		
		
	-- ************* BELOW *************
	
		-- CREATE NEW	
			-- if user chooses update button to create new scenario form INSERT new scenario
			/*

			INSERT INTO Scenario (Name, Description)
			VALUES (value1, value2);

			*/
			

			-- if user chooses update button to create new stage form INSERT new stage
			/*

			INSERT INTO Stage (Name, Description, AudioFilePath, ImageFilePath)
			VALUES (value1, value2, value3, value4);

			*/
			
			
			-- if user chooses update button to create new answer form INSERT new answer
			/*

			INSERT INTO Answer (Name, Description)
			VALUES (value1, value2);
			
			*/		
		

		-- EDIT EXISTING
			-- if user chooses update button to edit existing scenario form UPDATE existing scenario
			/*

			UPDATE Scenario
			SET Name = value1, Description = value2
			WHERE ID = Value3; 

			/*			


			-- if user chooses update button to edit existing stage form UPDATE existing stage
			/*

			UPDATE Stage
			SET Name = value1, Description = value4, AudioFilePath = value2, ImageFilePath = value3
			WHERE ID = Value5;

			/*
			

			-- if user chooses update button create existing stage form INSERT existing stage
			/*

			UPDATE Answer
			SET Name = value1, Description = value2
			WHERE ID = Value3;

			/*
		
		
		-- PERFORM EXISTING
			-- if user chooses perform button to perform existing scenario from anywhere
			/*

			SELECT *
			FROM Scenario
			INNER JOIN Stage ON Scenario.ID = Stage.ID
			INNER JOIN Answer ON Stage.ID = Answer.ID
			WHERE Scenario.ID = value1;

			/*
			
			
	-- ************* BELOW2 *************
	
		-- tie together list boxes for relating stages to scenarios populate dropdown with all scenarios
			/*

		SELECT ID, Name
		FROM Stage	
	
			/*		


		-- tie together list boxes for relating answers to stages populate dropdown with all stages
			/*

		SELECT ID, Name
		FROM Stage

			/*		


		-- tie together list boxes for relating answers to next stage populate dropdown with all answers
			/*

		SELECT ID, Name
		FROM Answer

			/*