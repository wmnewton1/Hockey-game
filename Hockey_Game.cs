using System;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    public void teamAssignment(int numofTeams)
    {
        int oneTeam;
        int twoTeam;
        Console.WriteLine("User one may now select their team out of the following options:");
        Thread.Sleep(1000);
        for (int i = 1; i <= numofTeams; i++)
        {
            using (StreamReader sr = new StreamReader("C://team" + i + ".txt"))
            {
                string line;
                Console.WriteLine("================= TEAM " + i + "=================");
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        oneTeam = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("User two may now select their team out of the following options:");
        Thread.Sleep(2000);
        for (int i = 1; i <= numofTeams; i++)
        {
            if (i == oneTeam)
            {
            }
            else
            {
                using (StreamReader sr = new StreamReader("C://team" + i + ".txt"))
                {
                    string line;
                    Console.WriteLine("================= TEAM " + i + "=================");
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }
        twoTeam = Convert.ToInt32(Console.ReadLine());

        string[,] oneTeamMembers = new string[6, 3]
        {
            { File.ReadLines("C://team" + oneTeam + ".txt").Skip(2).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(4).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(6).Take(1).First()},
            { File.ReadLines("C://team" + oneTeam + ".txt").Skip(8).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(10).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(12).Take(1).First()},
            { File.ReadLines("C://team" + oneTeam + ".txt").Skip(14).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(16).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(18).Take(1).First()},
            { File.ReadLines("C://team" + oneTeam + ".txt").Skip(20).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(22).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(24).Take(1).First()},
            { File.ReadLines("C://team" + oneTeam + ".txt").Skip(26).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(28).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(30).Take(1).First()},
            { File.ReadLines("C://team" + oneTeam + ".txt").Skip(32).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(34).Take(1).First(), File.ReadLines("C://team" + oneTeam + ".txt").Skip(36).Take(1).First()},
        };

        string[,] twoTeamMembers = new string[6, 3]
        {
        { File.ReadLines("C://team" + twoTeam + ".txt").Skip(2).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(4).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(6).Take(1).First()},
        { File.ReadLines("C://team" + twoTeam + ".txt").Skip(8).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(10).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(12).Take(1).First()},
        { File.ReadLines("C://team" + twoTeam + ".txt").Skip(14).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(16).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(18).Take(1).First()},
        { File.ReadLines("C://team" + twoTeam + ".txt").Skip(20).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(22).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(24).Take(1).First()},
        { File.ReadLines("C://team" + twoTeam + ".txt").Skip(26).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(28).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(30).Take(1).First()},
        { File.ReadLines("C://team" + twoTeam + ".txt").Skip(32).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(34).Take(1).First(), File.ReadLines("C://team" + twoTeam + ".txt").Skip(36).Take(1).First()},
        };

        int[] oneTeamDefence = new int[]
        {
            Convert.ToInt32(oneTeamMembers[0,2]),
            Convert.ToInt32(oneTeamMembers[1,2]),
            Convert.ToInt32(oneTeamMembers[2,2]),
            Convert.ToInt32(oneTeamMembers[3,2]),
            Convert.ToInt32(oneTeamMembers[4,2]),
            Convert.ToInt32(oneTeamMembers[5,2])
        };

        for (int j = 0; j <= 5; j++)
        {
            if (Convert.ToInt32(oneTeamMembers[j, 2]) == oneTeamDefence.Max())
            {
                Console.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + "'s Goalkeeper is " + oneTeamMembers[j, 0]);
                Console.WriteLine("");
                Thread.Sleep(500);

                int[] twoTeamDefence = new int[]
                {
                    Convert.ToInt32(twoTeamMembers[0,2]),
                    Convert.ToInt32(twoTeamMembers[1,2]),
                    Convert.ToInt32(twoTeamMembers[2,2]),
                    Convert.ToInt32(twoTeamMembers[3,2]),
                    Convert.ToInt32(twoTeamMembers[4,2]),
                    Convert.ToInt32(twoTeamMembers[5,2]),
                };

                for (int k = 0; k <= 5; k++)
                {
                    if (Convert.ToInt32(twoTeamMembers[k, 2]) == twoTeamDefence.Max())
                    {
                        Console.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + "'s Goalkeeper is " + twoTeamMembers[k, 0]);
                        Console.WriteLine("");
                        Play(j, oneTeamMembers[j, 0], k, twoTeamMembers[k, 0], oneTeamMembers, twoTeamMembers, oneTeam, twoTeam);
                    }
                    else
                    {
                    }
                }
            }
            else
            {
            }
        }
    }
    public void Play(int oneTeamGoalkeeperIndex, string oneTeamGoalkeeper, int twoTeamGoalkeeperIndex, string twoTeamGoalkeeper, string[,] oneTeamMembers, string[,] twoTeamMembers, int oneTeam, int twoTeam)
    {
        int attackerIndex;
        int difference;
        int oneTeamScore = 0;
        int twoTeamScore = 0;
        int oneK = 0;
        int twoK = 0;
        int[] oneTeamAttackersTakenPenalty = new int[5] { 6, 6, 6, 6, 6 };
        int[] twoTeamAttackersTakenPenalty = new int[5] { 6, 6, 6, 6, 6 };
        for (int i = 0; i <= 9; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("User one may now select an Attacker to take a penalty from the following options:");
                Thread.Sleep(1000);
                for (int j = 0; j <= 5; j++)
                {
                    if (j == oneTeamGoalkeeperIndex || oneTeamAttackersTakenPenalty.Contains(j))
                    {
                    }
                    else
                    {
                        Console.WriteLine((j + 1) + ") " + oneTeamMembers[j, 0]);
                        Console.WriteLine("Attack:");
                        Console.WriteLine(oneTeamMembers[j, 1]);
                        Console.WriteLine("Defence:");
                        Console.WriteLine(oneTeamMembers[j, 2]);
                        Console.WriteLine("");
                        Thread.Sleep(500);
                    }
                }
                while (true)
                {
                    attackerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (attackerIndex == oneTeamGoalkeeperIndex || 0 > attackerIndex || 5 < attackerIndex)
                    {
                        Console.WriteLine("Sorry, but that input was not valid.");
                    }
                    else
                    {
                        break;
                    }
                }
                difference = Convert.ToInt32(oneTeamMembers[attackerIndex, 1]) - Convert.ToInt32(twoTeamMembers[twoTeamGoalkeeperIndex, 2]);
                oneTeamAttackersTakenPenalty[oneK] = attackerIndex;
                oneK++;
                if (difference >= 0)
                {
                    oneTeamScore++;
                    Thread.Sleep(500);
                    Console.WriteLine("GOAL!");
                    Thread.Sleep(200);
                    Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Saved!");
                    Thread.Sleep(200);
                    Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                }
            }
            else
            {
                Console.WriteLine("User two may now select an Attacker to take a penalty from the following options:");
                Thread.Sleep(1000);
                for (int j = 0; j <= 5; j++)
                {
                    if (j == twoTeamGoalkeeperIndex || twoTeamAttackersTakenPenalty.Contains(j))
                    {
                    }
                    else
                    {
                        Console.WriteLine((j + 1) + ") " + twoTeamMembers[j, 0]);
                        Console.WriteLine("Attack:");
                        Console.WriteLine(twoTeamMembers[j, 1]);
                        Console.WriteLine("Defence:");
                        Console.WriteLine(twoTeamMembers[j, 2]);
                        Console.WriteLine("");
                        Thread.Sleep(500);
                    }
                }
                while (true)
                {
                    attackerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (attackerIndex == twoTeamGoalkeeperIndex || 0 > attackerIndex || 5 < attackerIndex)
                    {
                        Console.WriteLine("Sorry, but that input was not valid.");
                    }
                    else
                    {
                        break;
                    }
                }
                difference = Convert.ToInt32(twoTeamMembers[attackerIndex, 1]) - Convert.ToInt32(oneTeamMembers[oneTeamGoalkeeperIndex, 2]);
                twoTeamAttackersTakenPenalty[twoK] = attackerIndex;
                twoK++;
                if (difference >= 0)
                {
                    twoTeamScore++;
                    Thread.Sleep(500);
                    Console.WriteLine("GOAL!");
                    Thread.Sleep(200);
                    Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Saved!");
                    Thread.Sleep(200);
                    Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                }
            }
        }
        if (oneTeamScore > twoTeamScore)
        {
            Console.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " wins the game!");
            GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
        }
        else if (oneTeamScore < twoTeamScore)
        {
            Console.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + " wins the game!");
            GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
        }
        else
        {
            Console.WriteLine("The game has now entered Overtime.");
            for (int i = 0; i <= 4; i++)
            {
                oneTeamAttackersTakenPenalty[i] = 6;
                twoTeamAttackersTakenPenalty[i] = 6;
            }
            oneK = 0;
            twoK = 0;
            for (int i = 0; i <= 9; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("User one may now select an Attacker to take a penalty from the following options:");
                    Thread.Sleep(1000);
                    for (int j = 0; j <= 5; j++)
                    {
                        if (j == oneTeamGoalkeeperIndex || oneTeamAttackersTakenPenalty.Contains(j))
                        {
                        }
                        else
                        {
                            Console.WriteLine((j + 1) + ") " + oneTeamMembers[j, 0]);
                            Console.WriteLine("Attack:");
                            Console.WriteLine(oneTeamMembers[j, 1]);
                            Console.WriteLine("Defence:");
                            Console.WriteLine(oneTeamMembers[j, 2]);
                            Console.WriteLine("");
                            Thread.Sleep(500);
                        }
                    }
                    attackerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    difference = Convert.ToInt32(oneTeamMembers[attackerIndex, 1]) - Convert.ToInt32(twoTeamMembers[twoTeamGoalkeeperIndex, 2]);
                    oneTeamAttackersTakenPenalty[oneK] = attackerIndex;
                    oneK++;
                    if (difference >= 0)
                    {
                        oneTeamScore++;
                        Thread.Sleep(500);
                        Console.WriteLine("GOAL!");
                        Thread.Sleep(200);
                        Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Console.WriteLine("Saved!");
                        Thread.Sleep(200);
                        Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                    }
                }
                else
                {
                    Console.WriteLine("User two may now select an Attacker to take a penalty from the following options:");
                    Thread.Sleep(1000);
                    for (int j = 0; j <= 5; j++)
                    {
                        if (j == twoTeamGoalkeeperIndex || twoTeamAttackersTakenPenalty.Contains(j))
                        {
                        }
                        else
                        {
                            Console.WriteLine((j + 1) + ") " + twoTeamMembers[j, 0]);
                            Console.WriteLine("Attack:");
                            Console.WriteLine(twoTeamMembers[j, 1]);
                            Console.WriteLine("Defence:");
                            Console.WriteLine(twoTeamMembers[j, 2]);
                            Console.WriteLine("");
                            Thread.Sleep(500);
                        }
                    }
                    attackerIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                    difference = Convert.ToInt32(twoTeamMembers[attackerIndex, 1]) - Convert.ToInt32(oneTeamMembers[oneTeamGoalkeeperIndex, 2]);
                    twoTeamAttackersTakenPenalty[twoK] = attackerIndex;
                    twoK++;
                    if (difference >= 0)
                    {
                        twoTeamScore++;
                        Thread.Sleep(500);
                        Console.WriteLine("GOAL!");
                        Thread.Sleep(200);
                        Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                        Thread.Sleep(500);
                    }
                    else
                    {
                        Console.WriteLine("Saved!");
                        Thread.Sleep(200);
                        Console.WriteLine("The score is currently " + oneTeamScore + " - " + twoTeamScore + ".");
                    }
                    if (oneTeamScore > twoTeamScore)
                    {
                        Console.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " wins the game!");
                        GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
                        break;
                    }
                    else if (oneTeamScore < twoTeamScore)
                    {
                        Console.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + " wins the game!");
                        GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
                        break;
                    }
                    else
                    {
                    }
                }
            }
            if (oneTeamScore > twoTeamScore)
            {
                Console.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " wins the game!");
                GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
            }
            else if (oneTeamScore < twoTeamScore)
            {
                Console.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + " wins the game!");
                GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
            }
            else
            {
                Console.WriteLine("The game is a tie!");
                GameLog(oneTeamScore, twoTeamScore, oneTeam, twoTeam);
            }
        }
    }
    public void Create(int numofTeams)
    {
        int[] attackTotal = new int[6];
        int[] defenceTotal = new int[6];
        int total = 0;
        Console.WriteLine("Please name your new team:");
        string teamName = Console.ReadLine();
        using (StreamWriter sw = new StreamWriter(@"C:\Hockey teams\team" + (numofTeams + 1) + ".txt"))
        {
            sw.WriteLine(teamName);
            sw.WriteLine("");
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Enter the name of a player.");
                sw.WriteLine(Console.ReadLine());
                sw.WriteLine("Attack");
                while (true)
                {
                    Console.WriteLine("Enter the value of their Attack attribute (0-10 inclusive).");
                    int attackInput = Convert.ToInt32(Console.ReadLine());
                    if (attackInput < 0 || attackInput > 10)
                    {
                        Console.WriteLine("The Attack attribute must be between 0 and 10 inclusive.");
                    }
                    else
                    {
                        attackTotal[i] = attackInput;
                        sw.WriteLine(attackInput);
                        break;
                    }
                }
                sw.WriteLine("Defence");
                while (true)
                {
                    Console.WriteLine("Enter the value of their Defence attribute (0-7 inclusive).");
                    int defenceInput = Convert.ToInt32(Console.ReadLine());
                    if (defenceInput < 0 || defenceInput > 10)
                    {
                        Console.WriteLine("The Defence attribute must be between 0 and 7 inclusive.");
                    }
                    else
                    {
                        defenceTotal[i] = defenceInput;
                        sw.WriteLine(defenceInput);
                        break;
                    }
                }
                sw.WriteLine("");
            }
        }
        for (int i = 0; i <= 5; i++)
        {
            total = attackTotal[i] + total;
        }
        for (int i = 0; i <= 5; i++)
        {
            total = defenceTotal[i] + total;
        }
        if (total > 35)
        {
            Thread.Sleep(300);
            Console.WriteLine("The total value of your Attack and Defence values for the team " + teamName + " are greater than 35. Please do over.");
            File.Delete(@"C:\Hockey teams\team" + (numofTeams + 1) + ".txt");
            Create(numofTeams);
        }
        else
        {
            Console.WriteLine("The team " + teamName + " has been created!");
            numofTeams++;
            Main();
        }
    }
    public void Edit(int numofTeams)
    {
        string teamToEdit;
        string playerToEdit;
        string attributeToEdit;
        string edit;
        string furtherEdits;
        Console.WriteLine("Enter the name of the team you would like to edit (case sensitive):");
        teamToEdit = Console.ReadLine();
        for (int i = 1; i <= numofTeams; i++)
        {
            if (File.ReadLines(@"C:\Hockey teams\team" + i + ".txt").Skip(0).Take(1).First() == teamToEdit)
            {
                Console.WriteLine("Which player's attributes would you like to edit?");
                playerToEdit = Console.ReadLine();
                for (int j = 2; j <= 32; j = j+6)
                {
                    if (File.ReadLines(@"C:\Hockey teams\team" + i + ".txt").Skip(j).Take(1).First() == playerToEdit)
                    {
                        while (true)
                        {
                            Console.WriteLine("Which attribute of " + playerToEdit + " would you like to edit?");
                            Thread.Sleep(500);
                            Console.WriteLine("Your options are: Name, Attack or Defence.");
                            attributeToEdit = Console.ReadLine().ToLower();
                            if (attributeToEdit == "name")
                            {
                                Console.WriteLine("What would you like to rename " + playerToEdit + " as?");
                                edit = Console.ReadLine();
                                lineChanger(edit, @"C:\Hockey teams\team" + i + ".txt", j + 1);
                                while (true)
                                {
                                    Console.WriteLine("Would you like to edit any other attribute of " + edit + "?");
                                    furtherEdits = Console.ReadLine().ToLower();
                                    if (furtherEdits == "y" || furtherEdits == "yes")
                                    {
                                        break;
                                    }
                                    else if (furtherEdits == "n" || furtherEdits == "no")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That is not a valid response.");
                                    }
                                }
                            }
                            else if (attributeToEdit == "attack")
                            {
                                Console.WriteLine("What is " + playerToEdit + "'s new Attack attribute?");
                                edit = Console.ReadLine();
                                lineChanger(edit, @"C:\Hockey teams\team" + i + ".txt", j + 3);
                                break;
                            }
                            else if (attributeToEdit == "defence" || attributeToEdit == "defense")
                            {
                                Console.WriteLine("What is " + playerToEdit + "'s new Defence attribute?");
                                edit = Console.ReadLine();
                                lineChanger(edit, @"C:\Hockey teams\team" + i + ".txt", j + 5);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That is not an attribute that may be edited.");
                                Thread.Sleep(500);
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            else
            {
            }
        }
    }
    static void lineChanger(string newText, string fileName, int line_to_edit)
    {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit - 1] = newText;
        File.WriteAllLines(fileName, arrLine);
    }
    public void GameLog(int oneTeamScore, int twoTeamScore, int oneTeam, int twoTeam)
    {
        using (StreamWriter sw = new StreamWriter("C://results.txt", true))
        {
            var time = DateTime.Now;
            string formattedTime = time.ToString("hh:mm.ss dd/MM/yyyy");
            sw.WriteLine(formattedTime);
            sw.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " (" + oneTeamScore + ") - (" + twoTeamScore + ") " + File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First());
            if (oneTeamScore > twoTeamScore)
            {
                sw.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " (W)");
                sw.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + " (L)");
            }
            else if (oneTeamScore < twoTeamScore)
            {
                sw.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + " (W)");
                sw.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " (L)");
            }
            else
            {
                sw.WriteLine(File.ReadLines("C://team" + oneTeam + ".txt").Skip(0).Take(1).First() + " (D)");
                sw.WriteLine(File.ReadLines("C://team" + twoTeam + ".txt").Skip(0).Take(1).First() + " (D)");
            }
            sw.WriteLine("");
        }
    }
    public void History(int numofTeams)
    {
        int oneTeam;
        int twoTeam;
        string oneTeamName;
        string twoTeamName;
        string line;
        int numofLines = File.ReadAllLines(@"C:\results.txt").Length;
        Console.WriteLine("Name a team you would like to see the match history of, from the following options:");
        Console.WriteLine("");
        for (int i=1;i<=numofTeams;i++)
        {
            Console.WriteLine(i + ") " + File.ReadLines(@"C:\Hockey teams\team" + i + ".txt").Skip(0).Take(1).First());
        }
        Console.WriteLine("");
        oneTeam = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        oneTeamName = File.ReadLines(@"C:\Hockey teams\team" + oneTeam + ".txt").Skip(0).Take(1).First();
        Console.WriteLine("");
        Console.WriteLine("Name a team whose match history, versus the first team you selected, you would like to see, from the following options:");
        Console.WriteLine("");
        for (int i = 1; i <= numofTeams; i++)
        {
            if (i == oneTeam)
            {
            }
            else
            {
                Console.WriteLine(i + ") " + File.ReadLines(@"C:\Hockey teams\team" + i + ".txt").Skip(0).Take(1).First());
            }
        }
        Console.WriteLine("");
        twoTeam = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");
        twoTeamName = File.ReadLines(@"C:\Hockey teams\team" + twoTeam + ".txt").Skip(0).Take(1).First();
        for (int i = 0; i < numofLines; i++)
        {
            line = File.ReadLines(@"C:\results.txt").Skip(i).Take(1).First();
            if (line.Contains(oneTeamName) && line.Contains(twoTeamName))
            {
                Console.WriteLine(File.ReadLines(@"C:\results.txt").Skip(i-1).Take(1).First());
                Console.WriteLine(File.ReadLines(@"C:\results.txt").Skip(i).Take(1).First());
                Console.WriteLine(File.ReadLines(@"C:\results.txt").Skip(i+1).Take(1).First());
                Console.WriteLine(File.ReadLines(@"C:\results.txt").Skip(i+2).Take(1).First());
                Console.WriteLine("");
            }
            else
            {
            }
        }
    }
    public void Leaderboards(int numofTeams)
    {
        string leaderboardSelect;
        while (true)
        {
            string line;
            int[] wins = new int[numofTeams];
            int mostWins;
            Console.WriteLine("Select a leaderboard to view, out of the following options:");
            Console.WriteLine("");
            Console.WriteLine("a) Top three teams by games won.");
            Console.WriteLine("b) Top five teams by the fewest number of goals conceded");
            Console.WriteLine("");
            leaderboardSelect = Console.ReadLine().ToLower();
            if (leaderboardSelect == "a")
            {
                for (int i = 1; i <= numofTeams; i++)
                {
                    for (int j = 0; j <= File.ReadAllLines(@"C:\results.txt").Length; j++)
                    {
                        line = File.ReadLines(@"C:\results.txt").Skip(j).Take(1).First();
                        if (line == File.ReadLines(@"C:\Hockey teams\team" + i + ".txt").Skip(j).Take(1).First() + " (W)")
                        {
                            wins[i]++;
                        }
                        else
                        {
                        }
                    }
                }
                mostWins = wins.Max();
                Console.WriteLine(mostWins);
            }
            else if (leaderboardSelect == "b")
            {

            }
            else
            {
                Console.WriteLine("That is not a valid option.");
            }
        }
    }
    public static void Main()
    {
        int numofTeams = Directory.GetFiles(@"C:\Hockey teams").Length;
        string mainMenuInput;
        Program p = new Program();
        while (true)
        {
            Console.WriteLine("Please select an option:");
            Thread.Sleep(500);
            Console.WriteLine("a) Play the game.");
            Thread.Sleep(500);
            Console.WriteLine("b) Create a team.");
            Thread.Sleep(500);
            Console.WriteLine("c) Edit a team.");
            Thread.Sleep(500);
            Console.WriteLine("d) View game history.");
            Thread.Sleep(500);
            Console.WriteLine("c) View leaderboards.");
            mainMenuInput = Console.ReadLine().ToLower();
            if (mainMenuInput == "a")
            {
                p.teamAssignment(numofTeams);
                break;
            }
            else if (mainMenuInput == "b")
            {
                p.Create(numofTeams);
                break;
            }
            else if (mainMenuInput == "c")
            {
                p.Edit(numofTeams);
                break;
            }
            else if (mainMenuInput == "d")
            {
                p.History(numofTeams);
                break;
            }
            else if (mainMenuInput == "e")
            {
                p.Leaderboards(numofTeams);
                break;
            }
            else
            {
            }
        }
    }
}
