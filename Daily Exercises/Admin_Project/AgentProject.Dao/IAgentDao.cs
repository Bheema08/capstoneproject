using AgentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AgentProject.Dao
{
    internal interface IAgentDao
    {
        string AddAgentDao(Agent agent);
        List<Agent> ShowAgentsDao();
        Agent SearchAgentDao(int agentId);
        string UpdateAgentDao(Agent AgentUpdated);
        string DeleteAgentDao(int agentId);
        string WriteToFileDao();
        string ReadFromFileDao();

    }
}
