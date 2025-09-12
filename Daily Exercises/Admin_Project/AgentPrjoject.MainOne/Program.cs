using AgentProject.Bal;
using AgentProject.Exception;
using AgentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentPrjoject.MainOne
{
    internal class Program
    {

        static AgentBal agentBal = new AgentBal();

        public static void WriteFileMain()
        {
            Console.WriteLine(agentBal.WriteFileBal());
        }

        public static void ReadFileMain()
        {
            Console.WriteLine(agentBal.ReadFileBal());
        }
        public static void DeleteAgentMain()
        {
            int agentId;
            Console.WriteLine("Enter Employ Number   ");
            agentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(agentBal.DeleteAgentBal(agentId));
        }

        public static void UpdateAgentMain()
        {
            Agent agent = new Agent();
            Console.WriteLine("Enter AgentId to update  ");
            agent.AgentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter FIrst Name  ");
            agent.FirstName = Console.ReadLine();
            Console.WriteLine("Enter LastName   ");
            agent.LastName = Console.ReadLine();
            Console.WriteLine("Enter City  ");
            agent.City = Console.ReadLine();
            Console.WriteLine("Enter Gender  ");
            agent.Gender = Console.ReadLine();
            Console.WriteLine("Enter PremimumAmount  ");
            agent.PremimumAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(agentBal.UpdateAgentBal(agent));
        }
        public static void SearchAgentMain()
        {
            int agentId;
            Console.WriteLine("Enter Agent ID    ");
            agentId = Convert.ToInt32(Console.ReadLine());
            Agent agent = agentBal.SearchAgentBal(agentId);
            if (agent != null)
            {
                Console.WriteLine(agent);
            }
            else
            {
                Console.WriteLine("*** Agent Record Not Found ***");
            }
        }
        public static void ShowAgentMain()
        {
            List<Agent> AgentList = agentBal.ShowAgentBal();
            Console.WriteLine("Agent Record Are   ");
            foreach (Agent agent in AgentList)
            {
                Console.WriteLine(agent);
            }
        }
        public static void AddAgentMain()
        {
            Agent agent = new Agent();
            Console.WriteLine("Enter FIrst Name  ");
            agent.FirstName = Console.ReadLine();
            Console.WriteLine("Enter LastName   ");
            agent.LastName = Console.ReadLine();
            Console.WriteLine("Enter City  ");
            agent.City = Console.ReadLine();
            Console.WriteLine("Enter Gender  ");
            agent.Gender = Console.ReadLine();
            Console.WriteLine("Enter PremimumAmount  ");
            agent.PremimumAmount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(agentBal.AddAgentBal(agent));
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("O P T I O N S");
                Console.WriteLine("-------------");
                Console.WriteLine("1. Add Agent");
                Console.WriteLine("2. Show All Agents");
                Console.WriteLine("3. Search Agent");
                Console.WriteLine("4. Update Agent");
                Console.WriteLine("5. Delete Agent");
                Console.WriteLine("6. Write to File");
                Console.WriteLine("7. Read From File");
                Console.WriteLine("8. Exit");
                Console.WriteLine("Enter Your Choice  ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            AddAgentMain();
                        }
                        catch (AgentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 2:
                        ShowAgentMain();
                        break;
                    case 3:
                        SearchAgentMain();
                        break;
                    case 4:
                        try
                        {
                            UpdateAgentMain();
                        }
                        catch (AgentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        break;
                    case 5:
                        DeleteAgentMain();
                        break;
                    case 6:
                        WriteFileMain();
                        break;
                    case 7:
                        ReadFileMain();
                        break;
                    case 8:
                        return;
                }
            } while (choice != 8);

        }
    }
}
