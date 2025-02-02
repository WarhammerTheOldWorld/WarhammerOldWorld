﻿using System.Collections.Generic;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using WarhammerOldWorld.Extensions;
using WarhammerOldWorld.Modules.TroopAttributes.CustomAgentComponents;
using WarhammerOldWorld.Modules.TroopAttributes.CustomAgentComponents.MoraleAgentComponents;

namespace WarhammerOldWorld.Modules.TroopAttributes.CustomMissionLogic
{
    class TroopAttributeMissionLogic : MissionLogic
    {
        public TroopAttributeMissionLogic()
        {
        }

        public override void OnAgentCreated(Agent agent)
        {
            base.OnAgentCreated(agent);

            List<string> attributeList = agent.GetAttributes();

            foreach (string attribute in attributeList)
            {
                ApplyAgentComponentsForAttribute(attribute, agent);
            }
        }

        private void ApplyAgentComponentsForAttribute(string attribute, Agent agent)
        {
            switch (attribute)
            {
                case "Expendable":
                    //Expendable units are handled in the mission's morale interaction logic
                    break;
                case "HealingAura":
                    agent.AddComponent(new HealingAuraAgentComponent(agent));
                    break;
                case "Undead":
                    agent.AddComponent(new UndeadMoraleAgentComponent(agent));
                    break;
            }
        }
    }
}
