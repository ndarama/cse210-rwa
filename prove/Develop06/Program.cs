using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            goalManager.LoadGoals();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Eternal Quest");
                Console.WriteLine($"Current Score: {goalManager.Score}");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record an Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Save and Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        goalManager.CreateGoal();
                        break;
                    case "2":
                        goalManager.RecordEvent();
                        break;
                    case "3":
                        goalManager.ShowGoals();
                        break;
                    case "4":
                        goalManager.SaveGoals();
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }

    class GoalManager
    {
        public List<Goal> Goals = new List<Goal>();
        public int Score = 0;

        public void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("Create a New Goal");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Select a goal type: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Goals.Add(new SimpleGoal());
                    break;
                case "2":
                    Goals.Add(new EternalGoal());
                    break;
                case "3":
                    Goals.Add(new ChecklistGoal());
                    break;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }

        public void RecordEvent()
        {
            Console.Clear();
            Console.WriteLine("Record an Event");
            for (int i = 0; i < Goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Goals[i].GetDetailsString()}");
            }

            Console.Write("Select a goal to record: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Goals.Count)
            {
                Goals[choice - 1].RecordEvent();
                Score += Goals[choice - 1].GetPoints();
                Console.WriteLine("Event recorded! Press Enter to continue.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to return.");
            }
            Console.ReadLine();
        }

        public void ShowGoals()
        {
            Console.Clear();
            Console.WriteLine("Your Goals");
            foreach (var goal in Goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
            Console.WriteLine("Press Enter to return.");
            Console.ReadLine();
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(Score);
                foreach (var goal in Goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                string[] lines = File.ReadAllLines("goals.txt");
                if (lines.Length > 0)
                {
                    Score = int.Parse(lines[0]);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(",");
                        switch (parts[0])
                        {
                            case "SimpleGoal":
                                Goals.Add(SimpleGoal.FromString(parts));
                                break;
                            case "EternalGoal":
                                Goals.Add(EternalGoal.FromString(parts));
                                break;
                            case "ChecklistGoal":
                                Goals.Add(ChecklistGoal.FromString(parts));
                                break;
                        }
                    }
                }
            }
        }
    }

    abstract class Goal
    {
        public string Name;
        public string Description;
        public int Points;

        public abstract void RecordEvent();

        public abstract string GetDetailsString();

        public abstract string GetStringRepresentation();

        public abstract int GetPoints();
    }

    class SimpleGoal : Goal
    {
        public bool IsComplete = false;

        public SimpleGoal()
        {
            Console.Write("Enter goal name: ");
            Name = Console.ReadLine();
            Console.Write("Enter description: ");
            Description = Console.ReadLine();
            Console.Write("Enter points: ");
            Points = int.Parse(Console.ReadLine());
        }

        public override void RecordEvent()
        {
            IsComplete = true;
        }

        public override string GetDetailsString()
        {
            return $"[" + (IsComplete ? "X" : " ") + $"] {Name}: {Description} ({Points} points)";
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal,{Name},{Description},{Points},{IsComplete}";
        }

        public override int GetPoints()
        {
            return IsComplete ? Points : 0;
        }

        public static SimpleGoal FromString(string[] parts)
        {
            return new SimpleGoal
            {
                Name = parts[1],
                Description = parts[2],
                Points = int.Parse(parts[3]),
                IsComplete = bool.Parse(parts[4])
            };
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal()
        {
            Console.Write("Enter goal name: ");
            Name = Console.ReadLine();
            Console.Write("Enter description: ");
            Description = Console.ReadLine();
            Console.Write("Enter points per event: ");
            Points = int.Parse(Console.ReadLine());
        }

        public override void RecordEvent()
        {
        }

        public override string GetDetailsString()
        {
            return $"[ ] {Name}: {Description} ({Points} points per event)";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal,{Name},{Description},{Points}";
        }

        public override int GetPoints()
        {
            return Points;
        }

        public static EternalGoal FromString(string[] parts)
        {
            return new EternalGoal
            {
                Name = parts[1],
                Description = parts[2],
                Points = int.Parse(parts[3])
            };
        }
    }

    class ChecklistGoal : Goal
    {
        public int TargetCount;
        public int CurrentCount;
        public int BonusPoints;

        public ChecklistGoal()
        {
            Console.Write("Enter goal name: ");
            Name = Console.ReadLine();
            Console.Write("Enter description: ");
            Description = Console.ReadLine();
            Console.Write("Enter points per event: ");
            Points = int.Parse(Console.ReadLine());
            Console.Write("Enter target count: ");
            TargetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            BonusPoints = int.Parse(Console.ReadLine());
        }

        public override void RecordEvent()
        {
            if (CurrentCount < TargetCount)
            {
                CurrentCount++;
            }
        }

        public override string GetDetailsString()
        {
            return $"[" + (CurrentCount >= TargetCount ? "X" : " ") + $"] {Name}: {Description} ({CurrentCount}/{TargetCount}, {Points} points per event, Bonus: {BonusPoints} points)";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal,{Name},{Description},{Points},{TargetCount},{CurrentCount},{BonusPoints}";
        }

        public override int GetPoints()
        {
            return (CurrentCount >= TargetCount ? Points + BonusPoints : Points);
        }

        public static ChecklistGoal FromString(string[] parts)
        {
            return new ChecklistGoal
            {
                Name = parts[1],
                Description = parts[2],
                Points = int.Parse(parts[3]),
                TargetCount = int.Parse(parts[4]),
                CurrentCount = int.Parse(parts[5]),
                BonusPoints = int.Parse(parts[6])
            };
        }
    }
}