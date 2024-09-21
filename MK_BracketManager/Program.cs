using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MK_BracketManager
{
    class MK_BracketProgram
    {
        static void Main(string[] args)
        {
            int numbContestants = 0;
            bool isDoubleDash = true;
            String input;
            String[] courseListMax8Semifinals = { "Luigis Piste", "Peach Beach", "Staubtrockene Wüste", "Marios Piste", "Daisy Dampfer" };
            String[] courseListMax8Finals = { "Yoshis Piste", "DK Bergland", "Dinodino-Dschungel", "Bowsers Festung", "Regenbogen-Boulevard" };
            String[] courseListMax16Quarterfinals = { "Luigis Piste", "Peach Beach" };
            String[] courseListMax16Semifinals = { "Staubtrockene Wüste", "Marios Piste", "Daisy Dampfer", "Waluigi Arena", "Sorbet-Land" };
            String[] courseListMax16Finals = { "Yoshis Piste", "DK Bergland", "Dinodino-Dschungel", "Bowsers Festung", "Regenbogen-Boulevard" };
            String[] courseListMax32Octalfinals = { "Luigis Piste" };
            String[] courseListMax32Quarterfinals = { "Peach Beach", "Staubtrockene Wüste" };
            String[] courseListMax32Semifinals = { "Daisy Dampfer", "Waluigi Arena", "Sorbet-Land" };
            String[] courseListMax32Finals = { "Yoshis Piste", "DK Bergland", "Dinodino-Dschungel", "Bowsers Festung", "Regenbogen-Boulevard" };
            Tournament tournament;


            //Collecting the number of contestants while making sure they are a number between 4 and 32
            Console.WriteLine("How many contestants are there?");
            input = Console.ReadLine();
            while(!int.TryParse(input, out int n) || int.Parse(input) < 4 || int.Parse(input) > 32)
            {
                Console.WriteLine("Wrong input. Please enter a number between 4 and 32");
                input = Console.ReadLine() ;
            }
            numbContestants = int.Parse(input);


            //Collecting the names of every contestant
            String[] contestants = new String[numbContestants];
            input = "r";
            while (input.Equals("r"))
            {
                for (int i = 0; i < contestants.Length; i++)
                {
                    Console.WriteLine("Type in the name for contestant {0}:", i);
                    contestants[i] = Console.ReadLine();
                }
                Console.WriteLine("The {0} contestants are: {1}", numbContestants, String.Join(", ", contestants));
                Console.WriteLine("Press Enter to continue or 'r' to reenter the contestants");
                input = Console.ReadLine();
            }


            //Setting up the default course lists depending on whether it is a MK8 or MKDD tournament
            Console.WriteLine("---------------------------------------------------------\n");
            Console.WriteLine("Is this Mario Kart Double Dash or Mario Kart 8?");
            Console.WriteLine("-d Mario Kart Double Dash");
            Console.WriteLine("-e Mario Kart 8");
            input = Console.ReadLine();
            while(!input.Equals("d") && !input.Equals("e"))
            {
                Console.WriteLine("Wrong input. Please Enter 'd' or 'e'");
                input = Console.ReadLine();
            }
            if (input.Equals("e"))
            {
                isDoubleDash = false;
                courseListMax8Semifinals[0] = "Marios Piste"; courseListMax8Semifinals[1] = "Cheep-Cheep-Strand"; courseListMax8Semifinals[2] = "Shy Guys Wasserfälle"; courseListMax8Semifinals[3] = "Warios Goldmine"; courseListMax8Semifinals[4] = "Wario-Abfahrt";
                courseListMax8Finals[0] = "Yoshis Piste"; courseListMax8Finals[1] = "Instrumentalpiste"; courseListMax8Finals[2] = "Bowsers Festung"; courseListMax8Finals[3] = "Regenbogen-Boulevard"; courseListMax8Finals[4] = "Big Blue";
                courseListMax16Quarterfinals[0] = "Marios Piste"; courseListMax16Quarterfinals[1] = "Wasserpark";
                courseListMax16Semifinals[0] = "Cheep-Cheep-Strand"; courseListMax16Semifinals[1] = "Shy Guys Wasserfälle"; courseListMax16Semifinals[2] = "Warios Goldminen"; courseListMax16Semifinals[3] = "Wolkenstraße"; courseListMax16Semifinals[4] = "Wario-Abfahrt";
                courseListMax16Finals[0] = "Yoshis Piste"; courseListMax16Finals[1] = "Instrumentalpiste"; courseListMax16Finals[2] = "Bowsers Festung"; courseListMax16Finals[3] = "Regenbogen-Boulevard"; courseListMax16Finals[4] = "Big Blue";
                courseListMax32Octalfinals[0] = "Marios Piste";
                courseListMax32Quarterfinals[0] = "Wasserpark"; courseListMax32Quarterfinals[1] = "Shy Guys Wasserfälle";
                courseListMax32Semifinals[0] = "DK-Dschungel"; courseListMax32Semifinals[1] = "Warios Goldminen"; courseListMax32Semifinals[2] = "Wario-Abfahrt";
                courseListMax32Finals[0] = "Yoshis Piste"; courseListMax32Finals[1] = "Instrumentalpiste"; courseListMax32Finals[2] = "Bowsers Festung"; courseListMax32Finals[3] = "Regenbogen-Boulevard"; courseListMax32Finals[4] = "Big Blue";
            }


            //Collecting courses for the custom courselist depending on wether a custom course list is desired
            Console.WriteLine("---------------------------------------------------------\n");
            Console.WriteLine("Do You want to enter a custom course selection or run the tournament with the default selection?\nThe default selection is:");
            //Printing the corresponding default course Lists for 8- 16- or 32 participant tournaments
            switch (numbContestants)
            {
                case int n when n <= 8:
                    Console.WriteLine("Semifinals -> {0}", String.Join(", ", courseListMax8Semifinals));
                    Console.WriteLine("Finals     -> {0}", String.Join(", ", courseListMax8Finals)); break;
                case int n when n > 8 && n <= 16:
                    Console.WriteLine("Quarterfinals -> {0}", String.Join(", ", courseListMax16Quarterfinals));
                    Console.WriteLine("Semifinals    -> {0}", String.Join(", ", courseListMax16Semifinals));
                    Console.WriteLine("Finals        -> {0}", String.Join(", ", courseListMax16Finals)); break;
                case int n when n > 16 && n <= 32:
                    Console.WriteLine("Octalfinals   -> {0}", String.Join(", ", courseListMax32Octalfinals));
                    Console.WriteLine("Quarterfinals -> {0}", String.Join(", ", courseListMax32Quarterfinals));
                    Console.WriteLine("Semifinals    -> {0}", String.Join(", ", courseListMax32Semifinals));
                    Console.WriteLine("Finals        -> {0}", String.Join(", ", courseListMax32Finals)); break;
            }
            Console.WriteLine("-c enter custom courses");
            Console.WriteLine("-d use default courses");
            //Checking for a correct input 'c' or 'd'
            input = Console.ReadLine();
            while(!input.Equals("c") && !input.Equals("d"))
            {
                Console.WriteLine("Wrong input. Please enter 'c' or 'd'");
                input = Console.ReadLine();
            }
            //Mapping the course Lists to the corresponding user inputs
            if (input.Equals("c"))
            {
                //Differentiating between 8-, 16-, and 32 Participant tournaments, because they have different corresponding Arrays
                if(numbContestants > 16)
                {
                    for(int i = 0; i < courseListMax32Octalfinals.Length; i++)
                    {
                        Console.WriteLine("Octalfinals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax32Octalfinals[i]);
                        input = Console.ReadLine();
                        if(input.Equals("c"))
                        {
                            input = "r";
                            while(input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax32Octalfinals[i] = Console.ReadLine();
                                Console.WriteLine("new Octalfinals course {0}: {1}", (i + 1).ToString(), courseListMax32Octalfinals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                    for (int i = 0; i < courseListMax32Quarterfinals.Length; i++)
                    {
                        Console.WriteLine("Quarterfinals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax32Quarterfinals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax32Quarterfinals[i] = Console.ReadLine();
                                Console.WriteLine("new Quarter course {0}: {1}", (i + 1).ToString(), courseListMax32Quarterfinals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                    for (int i = 0; i < courseListMax32Semifinals.Length; i++)
                    {
                        Console.WriteLine("Semifinals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax32Semifinals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax32Octalfinals[i] = Console.ReadLine();
                                Console.WriteLine("new Semifinals course {0}: {1}", (i + 1).ToString(), courseListMax32Semifinals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                    for (int i = 0; i < courseListMax32Finals.Length; i++)
                    {
                        Console.WriteLine("Finals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax32Finals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax32Finals[i] = Console.ReadLine();
                                Console.WriteLine("new Finals course {0}: {1}", (i + 1).ToString(), courseListMax32Finals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                }
                else if (numbContestants > 8 && numbContestants <= 16)
                {
                    for (int i = 0; i < courseListMax16Quarterfinals.Length; i++)
                    {
                        Console.WriteLine("Quarterfinals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax16Quarterfinals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax16Quarterfinals[i] = Console.ReadLine();
                                Console.WriteLine("new Quarterfinals course {0}: {1}", (i + 1).ToString(), courseListMax16Quarterfinals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                    for (int i = 0; i < courseListMax16Semifinals.Length; i++)
                    {
                        Console.WriteLine("Semifinals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax16Semifinals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax16Semifinals[i] = Console.ReadLine();
                                Console.WriteLine("new Semifinals course {0}: {1}", (i + 1).ToString(), courseListMax16Semifinals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                    for (int i = 0; i < courseListMax16Finals.Length; i++)
                    {
                        Console.WriteLine("Finals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax16Finals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax16Finals[i] = Console.ReadLine();
                                Console.WriteLine("new Finals course {0}: {1}", (i + 1).ToString(), courseListMax16Finals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                }
                else if (numbContestants <= 8)
                {
                    for (int i = 0; i < courseListMax8Semifinals.Length; i++)
                    {
                        Console.WriteLine("Semifinals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax8Semifinals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax8Semifinals[i] = Console.ReadLine();
                                Console.WriteLine("new Semifinals course {0}: {1}", (i + 1).ToString(), courseListMax8Semifinals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                    for (int i = 0; i < courseListMax8Finals.Length; i++)
                    {
                        Console.WriteLine("Finals course {0}: {1}\n-press Enter to skip to next course or 'c' to change this course", (i + 1).ToString(), courseListMax8Finals[i]);
                        input = Console.ReadLine();
                        if (input.Equals("c"))
                        {
                            input = "r";
                            while (input.Equals("r"))
                            {
                                Console.WriteLine("type in the new course:");
                                courseListMax8Finals[i] = Console.ReadLine();
                                Console.WriteLine("new Finals course {0}: {1}", (i + 1).ToString(), courseListMax8Finals[i]);
                                Console.WriteLine("Press Enter to continue or 'r' to reenter the course");
                                input = Console.ReadLine();
                            }
                        }
                    }
                }
            }


            //Setting up Arrays with identical length for all types of tournaments (just makes iterating or pointing at indexes easier and saver)
            String[] octalFinalPlaceHolder = { null };
            String[] quarterFinalPlaceHolder = { null, null };
            String[] semiFinalPlaceHolder = { null, null, null, null, null };
            for(int i = 0; i < courseListMax32Semifinals.Length; i++) { semiFinalPlaceHolder[i] = courseListMax32Semifinals[i]; }


            //Creating the tournament as an 8-, 16-, or 32 Participant tournament depending on the number of contestants
            if      (numbContestants <= 8)                          { tournament = new Tournament(isDoubleDash, contestants, octalFinalPlaceHolder, quarterFinalPlaceHolder, courseListMax8Semifinals, courseListMax8Finals); }
            else if (numbContestants > 8 && numbContestants <= 16)  { tournament = new Tournament(isDoubleDash, contestants, octalFinalPlaceHolder, courseListMax16Quarterfinals, courseListMax8Finals, courseListMax16Finals); }
            else                                                    { tournament = new Tournament(isDoubleDash, contestants, courseListMax32Octalfinals, courseListMax32Quarterfinals, semiFinalPlaceHolder, courseListMax32Finals); }


            //Printing a visualization of the configuration
            Console.WriteLine("---------------------------------------------------------\n");
            Console.WriteLine("The tournament is configured as follows:\n");
            Console.WriteLine("Contestants: {0}\n", String.Join(", ", contestants));
            if (isDoubleDash)   { Console.WriteLine("Game: Mario Kart DoubleDash\n"); }
            else                { Console.WriteLine("Game: Mario Kart 8\n"         ); }
            Console.WriteLine("Courses:");
            if (numbContestants > 16) { Console.WriteLine("Octalfinals   -> {0}",   String.Join(", ", tournament.GetCoursesOctalFinal())); }
            if (numbContestants > 8 ) { Console.WriteLine("Quarterfinals -> {0}",   String.Join(", ", tournament.GetCoursesQuarterFinal())); }
                                        Console.WriteLine("Semifinals    -> {0}",   String.Join(", ", tournament.GetCoursesSemiFinal()));
                                        Console.WriteLine("Finals        -> {0}\n", String.Join(", ", tournament.GetCoursesFinal()));
            Console.WriteLine("Matches:\n\n{0}", tournament.Visualize());


            //Main menu with the options 'showing all games', 'showing the games that can be played next' and 'updating the score of a played game'
            while(true)
            {
                Console.WriteLine("-n Show the games that are up next \n-b Show the whole bracket \n-u Update the score on a game");
                input = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------\n");
                //Listing up the games, that can be played next, because the participants are decided already
                if (input.Equals("n"))
                {
                    Console.WriteLine("Next up are:\n");
                    foreach (MKGame game in tournament.GetUpcomingGames())
                    {
                        Console.WriteLine("{0} \n", game.IntoString());
                    }
                }
                //Listing up every game in the tournament
                else if (input.Equals("b"))
                {
                    Console.WriteLine(tournament.Visualize());
                }
                //Letting the user register the results of a game that has been played already
                else if (input.Equals("u"))
                {
                    int id = 0;
                    bool correctGame = false;
                    Console.WriteLine("Which game do you want to update?");
                    //Listing up every upcoming game with the corresponding input (ID number) that the user has to enter to select the game
                    foreach (MKGame game in tournament.GetUpcomingGames())
                    {
                        Console.WriteLine("-{0}\n{1} \n", game.GetGameID(), game.IntoString());
                    }
                    while (!correctGame)
                    {
                        input = Console.ReadLine();
                        //Checking whether the input is a number at all
                        while(!int.TryParse(input, out int n))
                        {
                            Console.WriteLine("Wrong input. Please enter one of the IDs listed above, or enter 0 to cancel");
                            input = Console.ReadLine();
                        }
                        id = Convert.ToInt32(input);
                        //Checking whether it is the number 0. In that case no game will be updated and the user is directed back to the main menu
                        if (id == 0) { break; }
                        //Checking whether the input is one of the IDs of the possible games
                        foreach (MKGame game in tournament.GetUpcomingGames())
                        {
                            if (game.GetGameID() == id)
                            {
                                correctGame = true;
                            }
                        }
                        if(!correctGame)
                        {
                            Console.WriteLine("This game ID wasn't listed above. Enter a valid game ID, or enter 0 to cancel");
                        }
                    }
                    //ID now is either a legit game ID or 0
                    //0 means no changes an any other ID updates the corresponding game and the follow-up games that get influenced by it
                    if(id != 0)
                    {
                        tournament.GetGame(id).UpdateScore();
                        tournament.SetFollowupGames(id);
                        Console.WriteLine("The game is now configured as follows:");
                        Console.WriteLine(tournament.GetGame(id).IntoString());
                        Console.WriteLine("\npress Enter to go back to selection");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input. Please enter 'n', 'b' or 'u'");
                }
            }
        }


    }

    public class Tournament
    {
        private bool isDoubleDash;
        private String[] tournamentConts;
        private String[] coursesOctalfinal;
        private String[] coursesQuarterfinal;
        private String[] coursesSemifinal;
        private String[] coursesFinal;
        private MKGame[] games;

        public Tournament(bool isDD, String[] c, String[] oF, String[] qF, String[] sF, String[] f)
        {
            isDoubleDash = isDD;
            tournamentConts = c;
            coursesOctalfinal = oF;
            coursesQuarterfinal = qF;
            coursesSemifinal = sF;
            coursesFinal = f;
            games = this.GenerateGames();
        }

        public string[] GetCoursesOctalFinal()
        {
            return coursesOctalfinal;
        }

        public string[] GetCoursesQuarterFinal()
        {
            return coursesQuarterfinal;
        }

        public string[] GetCoursesSemiFinal()
        {
            return coursesSemifinal;
        }

        public string[] GetCoursesFinal()
        {
            return coursesFinal;
        }

        public MKGame[] GetGames()
        {
            return games;
        }

        public MKGame GetGame(int id)
        {
            foreach( MKGame game in games)
            {
                if (game.GetGameID() == id)
                {
                    return game;
                }
            }
            //Sollte mit bisherigen Aufrufen nicht erreicht werden
            return new MKGame(0, false, false, games[0].GetResults(), games[0].GetGameConts(), coursesFinal);
        }

        public void SetGame(int id, MKGame newGame)
        {
            for(int i = 0; i < games.Length; i++)
            {
                if (games[i].GetGameID() == id)
                {
                    games[i] = newGame;
                }
            }
        }

        public List<MKGame> GetUpcomingGames()
        {
            List<MKGame> upcomingGames = new List<MKGame>();
            foreach(MKGame game in games)
            {
                if(!game.GetIsSettled() && game.GetPlayersKnown())
                {
                    upcomingGames.Add(game);
                }
            }
            return upcomingGames;
        }

        

        
        //Generating the games with all their corresponding attributes
        public MKGame[] GenerateGames()
        {
            MKGame[] games;
            MKGame octal1;
            MKGame octal2;
            MKGame octal3;
            MKGame octal4;
            MKGame octal5;
            MKGame octal6;
            MKGame octal7;
            MKGame octal8;
            MKGame quarter1;
            MKGame quarter2;
            MKGame quarter3;
            MKGame quarter4;
            MKGame semi1;
            MKGame semi2;
            MKGame finale;

            //Player number per game is dependent on the number of contestants and the game that is played
            int contsIn1  = HowManyPlayers(tournamentConts.Length,  1);
            int contsIn2  = HowManyPlayers(tournamentConts.Length,  2);
            int contsIn3  = HowManyPlayers(tournamentConts.Length,  3);
            int contsIn4  = HowManyPlayers(tournamentConts.Length,  4);
            int contsIn5  = HowManyPlayers(tournamentConts.Length,  5);
            int contsIn6  = HowManyPlayers(tournamentConts.Length,  6);
            int contsIn7  = HowManyPlayers(tournamentConts.Length,  7);
            int contsIn8  = HowManyPlayers(tournamentConts.Length,  8);
            int contsIn9  = HowManyPlayers(tournamentConts.Length,  9);
            int contsIn10 = HowManyPlayers(tournamentConts.Length, 10);
            int contsIn11 = HowManyPlayers(tournamentConts.Length, 11);
            int contsIn12 = HowManyPlayers(tournamentConts.Length, 12);
            int contsIn13 = HowManyPlayers(tournamentConts.Length, 13);
            int contsIn14 = HowManyPlayers(tournamentConts.Length, 14);
            int contsIn15 = HowManyPlayers(tournamentConts.Length, 15);

            //Arrays of results per game being as big as the number of players in that game
            int[] octal1Results   = new int[contsIn1 ];
            int[] octal2Results   = new int[contsIn2 ];
            int[] octal3Results   = new int[contsIn3 ];
            int[] octal4Results   = new int[contsIn4 ];
            int[] octal5Results   = new int[contsIn5 ];
            int[] octal6Results   = new int[contsIn6 ];
            int[] octal7Results   = new int[contsIn7 ];
            int[] octal8Results   = new int[contsIn8 ];
            int[] quarter1Results = new int[contsIn9 ];
            int[] quarter2Results = new int[contsIn10];
            int[] quarter3Results = new int[contsIn11];
            int[] quarter4Results = new int[contsIn12];
            int[] semi1Results    = new int[contsIn13];
            int[] semi2Results    = new int[contsIn14];
            int[] finalResults    = new int[contsIn15];

            //Initializing Lists containing the player names for every Round played in octal-finals.
            //Relevant only for 32- player tournaments, because with fewer participants no octal finals are initialized
            List<string> contsListIn1 = new List<string>();
            for (int i = 0; i < contsIn1; i++) { contsListIn1.Add(tournamentConts[i]); }
            List<string> contsListIn2 = new List<string>();
            for (int i = contsIn1; i < contsIn2 + contsIn1; i++) { contsListIn2.Add(tournamentConts[i]); }
            List<string> contsListIn3 = new List<string>();
            for (int i = contsIn1 + contsIn2; i < contsIn3 + contsIn1 + contsIn2; i++) { contsListIn3.Add(tournamentConts[i]); }
            List<string> contsListIn4 = new List<string>();
            for (int i = contsIn1 + contsIn2 + contsIn3; i < contsIn4 + contsIn1 + contsIn2 + contsIn3; i++) { contsListIn4.Add(tournamentConts[i]); }
            List<string> contsListIn5 = new List<string>();
            for (int i = contsIn1 + contsIn2 + contsIn3 + contsIn4; i < contsIn5 + contsIn1 + contsIn2 + contsIn3 + contsIn4; i++) { contsListIn5.Add(tournamentConts[i]); }
            List<string> contsListIn6 = new List<string>();
            for (int i = contsIn1 + contsIn2 + contsIn3 + contsIn4 + contsIn5; i < contsIn6 + contsIn1 + contsIn2 + contsIn3 + contsIn4 + contsIn5; i++) { contsListIn6.Add(tournamentConts[i]); }
            List<string> contsListIn7 = new List<string>();
            for (int i = contsIn1 + contsIn2 + contsIn3 + contsIn4 + contsIn5 + contsIn6; i < contsIn7 + contsIn1 + contsIn2 + contsIn3 + contsIn4 + contsIn5 + contsIn6; i++) { contsListIn7.Add(tournamentConts[i]); }
            List<string> contsListIn8 = new List<string>();
            for (int i = contsIn1 + contsIn2 + contsIn3 + contsIn4 + contsIn5 + contsIn6 + contsIn7; i < contsIn8 + contsIn1 + contsIn2 + contsIn3 + contsIn4 + contsIn5 + contsIn6 + contsIn7; i++) { contsListIn8.Add(tournamentConts[i]); }

            //Initializing Lists containing the player names for every Round played in Quarterfinals.
            //Relevant only for 16- player tournaments, because only there the names for these games are decided while initialization
            List<string> contsListIn9 = new List<string>();
            for (int i = 0; i < contsIn9; i++) { contsListIn9.Add(tournamentConts[i]); }
            List<string> contsListIn10 = new List<string>();
            for (int i = contsIn9; i < contsIn10 + contsIn9; i++) { contsListIn10.Add(tournamentConts[i]); }
            List<string> contsListIn11 = new List<string>();
            for (int i = contsIn9 + contsIn10; i < contsIn11 + contsIn9 + contsIn10; i++) { contsListIn11.Add(tournamentConts[i]); }
            List<string> contsListIn12 = new List<string>();
            for (int i = contsIn9 + contsIn10 + contsIn11; i < contsIn12 + contsIn9 + contsIn10 + contsIn11; i++) { contsListIn12.Add(tournamentConts[i]); }

            //Initializing Lists containing the names for every Round played in Semifinals.
            //Relevant only for 8- player tournaments, because only there the names for these games are decided while initialization
            List<string> contsListIn13 = new List<string>();
            for (int i = 0; i < contsIn13; i++) { contsListIn13.Add(tournamentConts[i]); }
            List<string> contsListIn14 = new List<string>();
            for (int i = contsIn13; i < contsIn14 + contsIn13; i++) { contsListIn14.Add(tournamentConts[i]); }

            //Versions of the player names where the contesting players are not yet decided
            //Here every player gets named after the game that has to be won to participate in the current one
            //(eg: "game 9:2nd" -> second place of the first semifinals game (gameID 9) will participate here)
            List<string> contsListIn9Undef  = new List<string>();
            contsListIn9Undef.Add("game 1:1st");
            contsListIn9Undef.Add("game 3:1st");
            if (contsIn2 > 2) { contsListIn9Undef.Add("game 2:2nd"); }
            if (contsIn4 > 2) { contsListIn9Undef.Add("game 4:2nd"); }

            List<string> contsListIn10Undef = new List<string>();
            contsListIn10Undef.Add("game 2:1st");
            contsListIn10Undef.Add("game 4:1st");
            if (contsIn1 > 2) { contsListIn10Undef.Add("game 1:2nd"); }
            if (contsIn3 > 2) { contsListIn10Undef.Add("game 3:2nd"); }

            List<string> contsListIn11Undef = new List<string>();
            contsListIn11Undef.Add("game 5:1st");
            contsListIn11Undef.Add("game 7:1st");
            if (contsIn6 > 2) { contsListIn11Undef.Add("game 6:2nd"); }
            if (contsIn2 > 2) { contsListIn11Undef.Add("game 2:2nd"); }

            List<string> contsListIn12Undef = new List<string>();
            contsListIn12Undef.Add("game 6:1st");
            contsListIn12Undef.Add("game 8:1st");
            if (contsIn5 > 2) { contsListIn12Undef.Add("game 5:2nd"); }
            if (contsIn7 > 2) { contsListIn12Undef.Add("game 7:2nd"); }

            List<string> contsListIn13Undef = new List<string>();
            contsListIn13Undef.Add("game 9:1st");
            contsListIn13Undef.Add("game 11:1st");
            if (contsIn10 > 2) { contsListIn13Undef.Add("game 10:2nd"); }
            if (contsIn12 > 2) { contsListIn13Undef.Add("game 12:2nd"); }

            List<string> contsListIn14Undef = new List<string>();
            contsListIn14Undef.Add("game 10:1st");
            contsListIn14Undef.Add("game 12:1st");
            if (contsIn9  > 2) { contsListIn14Undef.Add("game 9:2nd"); }
            if (contsIn11 > 2) { contsListIn14Undef.Add("game 11:2nd"); }

            List<string> contsListIn15Undef = new List<string>();
            contsListIn15Undef.Add("game 13:1st");
            contsListIn15Undef.Add("game 14:1st");
            if (contsIn13 > 2) { contsListIn15Undef.Add("game 13:2nd"); }
            if (contsIn14 > 2) { contsListIn15Undef.Add("game 14:2nd"); }

            //Initializing the corresponding games with all the above configured attributes
            switch (tournamentConts.Length)
            {
                case int n when n <= 8:
                    semi1  = new MKGame(13, true, false, semi1Results, contsListIn13, coursesSemifinal);
                    semi2  = new MKGame(14, true, false, semi2Results, contsListIn14, coursesSemifinal);
                    finale = new MKGame(15, false, false, finalResults, contsListIn15Undef, coursesFinal);

                    games = new MKGame[] { semi1, semi2, finale };
                break;

                case int n when n > 8 && n <= 16:
                    quarter1 = new MKGame(9 , true , false, quarter1Results, contsListIn9      , coursesQuarterfinal);
                    quarter2 = new MKGame(10, true , false, quarter2Results, contsListIn10     , coursesQuarterfinal);
                    quarter3 = new MKGame(11, true , false, quarter3Results, contsListIn11     , coursesQuarterfinal);
                    quarter4 = new MKGame(12, true , false, quarter4Results, contsListIn12     , coursesQuarterfinal);
                    semi1    = new MKGame(13, false, false, semi1Results   , contsListIn13Undef, coursesSemifinal   );
                    semi2    = new MKGame(14, false, false, semi2Results   , contsListIn14Undef, coursesSemifinal   );
                    finale   = new MKGame(15, false, false, finalResults   , contsListIn15Undef, coursesFinal       );

                    games = new MKGame[] { quarter1, quarter2, quarter3, quarter4, semi1, semi2, finale };
                break;

                case int n when n > 16:
                    octal1   = new MKGame(1 , true , false, octal1Results  , contsListIn1      , coursesOctalfinal  );
                    octal2   = new MKGame(2 , true , false, octal2Results  , contsListIn2      , coursesOctalfinal  );
                    octal3   = new MKGame(3 , true , false, octal3Results  , contsListIn3      , coursesOctalfinal  );
                    octal4   = new MKGame(4 , true , false, octal4Results  , contsListIn4      , coursesOctalfinal  );
                    octal5   = new MKGame(5 , true , false, octal5Results  , contsListIn5      , coursesOctalfinal  );
                    octal6   = new MKGame(6 , true , false, octal6Results  , contsListIn6      , coursesOctalfinal  );
                    octal7   = new MKGame(7 , true , false, octal7Results  , contsListIn7      , coursesOctalfinal  );
                    octal8   = new MKGame(8 , true , false, octal8Results  , contsListIn8      , coursesOctalfinal  );
                    quarter1 = new MKGame(9 , false, false, quarter1Results, contsListIn9Undef , coursesQuarterfinal);
                    quarter2 = new MKGame(10, false, false, quarter2Results, contsListIn10Undef, coursesQuarterfinal);
                    quarter3 = new MKGame(11, false, false, quarter3Results, contsListIn11Undef, coursesQuarterfinal);
                    quarter4 = new MKGame(12, false, false, quarter4Results, contsListIn12Undef, coursesQuarterfinal);
                    semi1    = new MKGame(13, false, false, semi1Results   , contsListIn13Undef, coursesSemifinal   );
                    semi2    = new MKGame(14, false, false, semi2Results   , contsListIn14Undef, coursesSemifinal   );
                    finale   = new MKGame(15, false, false, finalResults   , contsListIn15Undef, coursesFinal       );

                    games = new MKGame[] { octal1, octal2, octal3, octal4, octal5, octal6, octal7, octal8, quarter1, quarter2, quarter3, quarter4, semi1, semi2, finale };
                break;

                default: games = new MKGame[] { null }; break;//Should not be reachable
            }
            return games;
        }

        //computes how many players will compete in one game (Which is only dependent of the number of contestants and which one of the 15 games is played)
        public int HowManyPlayers(int numberContestants, int gameID) 
        {
            //"impossible rounds" (rounds that don't get created bc the number of players is too low) return 0
            if (  (numberContestants <= 16 && gameID <= 8 )      
                ||(numberContestants <=  8 && gameID <= 12) )
            {
                return 0;
            }

            int mod;
            int n = 2;

            //Three termination conditions for the recursive function calls
            //Termination conditions are calls, that execute the function for a game that is in the first round
            //(32 player tournaments -> octal-final games, 16 player tournaments -> quarterfinal games, 8 player tournaments -> semifinal games)
            if(gameID <= 8 && numberContestants > 16)
            {
                mod = numberContestants % 8;

                if (1 + mod > gameID) { n = numberContestants / 8 + 1; }
                else { n = numberContestants / 8; }

                return n;
            }
            if( gameID > 8 && gameID <= 12 && numberContestants > 8 && numberContestants <= 16)
            {
                mod = numberContestants % 4;

                if (9 + mod > gameID) { n = numberContestants / 4 + 1; }
                else                  { n = numberContestants / 4;     }

                return n;
            }
            if(gameID > 12 && gameID <= 14 && numberContestants <= 8)
            {
                mod = numberContestants % 2;

                if (13 + mod > gameID) { n = numberContestants / 2 + 1; }
                else { n = numberContestants / 2; }

                return n;
            }

            //Otherwise a recursive function call is executed
            //with n being initialized at 2 and bumping up 0, 1 or 2 times depending on the number of players in the previous rounds, n will be always 2, 3 or 4.
            //The two bumps only occur, if rounds whose second places would participate in the current game have more than 2 participants.
            //That's because otherwise only the first place continues on and the spot for the current game stays free
            switch(gameID)
            {
                case 15:
                    if( HowManyPlayers(numberContestants, 13) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 14) > 2) { n++; } break;
                case 14:
                    if( HowManyPlayers(numberContestants, 9 ) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 11) > 2) { n++; } break;
                case 13:
                    if( HowManyPlayers(numberContestants, 10) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 12) > 2) { n++; } break;
                case 12:
                    if( HowManyPlayers(numberContestants, 5 ) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 7 ) > 2) { n++; } break;
                case 11:
                    if( HowManyPlayers(numberContestants, 6 ) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 8 ) > 2) { n++; } break;
                case 10:
                    if( HowManyPlayers(numberContestants, 1 ) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 3 ) > 2) { n++; } break;
                case 9 :
                    if( HowManyPlayers(numberContestants, 2 ) > 2) { n++; }
                    if( HowManyPlayers(numberContestants, 4 ) > 2) { n++; } break;
                default: n = 0; break;
            }
            return n;
        }

        //Updates the follow-up games that are influenced by the updated score of the current game
        public void SetFollowupGames(int id)
        {
            string idString = id.ToString();
            string firstPlace  = "no Player found";
            string secondPlace = "no Player found";
            bool allContsAreDecided = true;

            //Find the corresponding player names for the first and second place of the current game, because these names might appear in follow-up games
            for(int i = 0; i < GetGame(id).GetResults().Length; i++)
            {
                if (GetGame(id).GetResults()[i] == 1)
                {
                    firstPlace = GetGame(id).GetGameConts()[i];
                }
                else if (GetGame(id).GetResults()[i] == 2)
                {
                    secondPlace = GetGame(id).GetGameConts()[i];
                }
            }

            //Replacing the corresponding undefined namespaces with the names of the first and second placed players,
            //while simultaneously checking, if the updated name made all namespaces of this game defined,
            //because this would make that game playable and therefore appear in the selection of next up games
            for(int i = 0; i < GetGames().Length; i++)
            {
                for(int j = 0; j < GetGames()[i].GetGameConts().Count; j++)
                {
                    if (GetGames()[i].GetGameConts()[j].Equals("game " + idString + ":1st"))
                    {
                        GetGames()[i].GetGameConts()[j] = firstPlace;
                    }
                    else if (GetGames()[i].GetGameConts()[j].Equals("game " + idString + ":2nd"))
                    {
                        GetGames()[i].GetGameConts()[j] = secondPlace;
                    }

                    if(GetGames()[i].GetGameConts()[j].Contains("game "))
                    {
                        allContsAreDecided = false;
                    }
                }
                if(allContsAreDecided)
                {
                    GetGames()[i].SetPlayersKnown(true);
                }
                allContsAreDecided = true;
            }
        }

        //Showing a printed version of alle games this tournament consists of
        public String Visualize()
        {
            String bracket = "";
            foreach (MKGame game in games)
            {
                bracket += game.IntoString() + "\n";
            }
            return bracket;
        }
    }

    public class MKGame
    {
        private int gameID;
        private bool playersKnown;
        private bool isSettled;
        private int[] results;
        private List<String> gameConts;
        private String[] gameCourses;

        public MKGame(int ID, bool pK, bool isS, int[] r, List<String> gConts, String[] gCourse)
        {
            this.gameID = ID;
            this.playersKnown = pK;
            this.results= r;
            this.isSettled = isS;
            this.gameConts = gConts;
            this.gameCourses = gCourse;
        }

        public bool GetPlayersKnown()
        {
            return this.playersKnown;
        }

        public void SetPlayersKnown(bool known)
        {
            this.playersKnown = known;
        }

        public bool GetIsSettled()
        {
            return this.isSettled;
        }

        public int[] GetResults()
        {
            return this.results;
        }

        public List<String> GetGameConts()
        {
            return this.gameConts;
        }

        public int GetGameID()
        {
            return this.gameID;
        }
        
        //visualizing a game with its most important attributes
        public String IntoString()
        {
            string playersText = String.Join(", ", gameConts);
            string resultsText = String.Join(", ", results);
            string roundText = "";
            if(gameID <= 8 )                     { roundText = "Octalfinals"; }
            else if(gameID > 8 && gameID <= 12)  { roundText = "Quarterfinals"; }
            else if(gameID > 12 && gameID <= 14) { roundText = "Semifinals"; }
            else if(gameID == 15)                { roundText = "Finals"; }


            return "Game ID: " + gameID.ToString() + " (" + roundText + ")" + "\n"
                 + "Courses: " + String.Join(", ", gameCourses) + "\n"
                 + "Players: " + playersText + "\n"
                 + "Results: " + resultsText + "\n";

        }

        //Letting the user type in the placement for a game that has been decided
        public void UpdateScore()
        {
            string input = "r";
            bool isValid;
            int bumper1;
            int bumper2;
            int bumper3;
            int bumper4;

            Console.WriteLine("---------------------------------------------------------\n");
            while (input == "r")
            {
                //Reading the inputs while checking if they are a number within the accepted range
                Console.WriteLine("Updating score of the following game:");
                Console.WriteLine(this.IntoString());
                for(int i = 0; i < gameConts.Count; i++)
                {
                    Console.WriteLine("Placement (number '1 - {0}') for {1}", gameConts.Count, gameConts[i]);
                    input = Console.ReadLine();
                    while(!int.TryParse(input, out int n) || int.Parse(input) < 1 || int.Parse(input) > gameConts.Count)
                    {
                        Console.WriteLine("Wrong input. Please enter a number '1 - {0}'", gameConts.Count);
                        input = Console.ReadLine();
                    }
                    results[i] = int.Parse(input);
                }

                //checking if each player has a different placement
                isValid = true;
                bumper1 = 0;
                bumper2 = 0;
                bumper3 = 0;
                bumper4 = 0;
                foreach(int result in results)
                {
                    if     (result == 1){ bumper1++; }
                    else if(result == 2){ bumper2++; }
                    else if(result == 3){ bumper3++; }
                    else if(result == 4){ bumper4++; }
                }
                if(bumper1 > 1 || bumper2 > 1 || bumper3 > 1 || bumper4 > 1) { isValid = false; }

                //Visualizing the configured placements, if they are legit
                if(isValid)
                {
                    Console.WriteLine("---------------------------------------------------------\n");
                    Console.WriteLine("The placement is as follows:");
                    for (int i = 0; i < gameConts.Count; i++)
                    {
                        Console.WriteLine("{0}: {1}", gameConts[i], results[i]);
                    }
                    Console.WriteLine("Press Enter to continue or 'r' to reenter the placements");
                    input = Console.ReadLine();
                    Console.WriteLine("---------------------------------------------------------\n");
                }
                //otherwise setting input to r, thus starting the configuration from the beginning
                else
                {
                    Console.WriteLine("---------------------------------------------------------\n");
                    Console.WriteLine("This configuration is not valid. Please enter individual placements '1 to {0}' for every player", gameConts.Count);
                    input = "r";
                }
                    
            }
            this.isSettled = true;
        }
    }
}
