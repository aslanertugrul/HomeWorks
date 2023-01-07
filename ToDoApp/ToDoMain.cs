
    public class ToDoMain
    {
        static void Main(string[] args)
        {
            //********** CREATE DEFAULT STARTUP ITEMS **********

            // An empty ProgramManager is created.
            ProgramManager programManager = new ProgramManager();

            // TEAM_1 (id=1) and TEAM_2 (id=2) are defined as default in the team manager constructor.
            TeamManager teamManager = new TeamManager();

            // By default, 5 instances of people are defined in the constructor method of the PersonManager.
            // The ids of the persons are 1, 2, 3, 4 and 5.
            // By default, 2 members are assigned to TEAM_1 and 3 members to TEAM_2.
            PersonManager personManager = new PersonManager(teamManager, programManager);

            // By default, 5 instances of card are defined in the constructor method of the CardManager.
            // One person is assigned to each card.
            CardManager cardManager = new CardManager(personManager, programManager);

            // By default, 1 board is created in the BoardManager constructor method.
            // 5 predefined cards are placed on the Board.
            BoardManager boardManager = new BoardManager(cardManager, programManager);
            //**************************************************
            programManager.ToDoAppMainMenu();
        }
    }