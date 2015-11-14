﻿using System.Collections.Generic;

namespace Uwarcraft.Units
{
    public class Farm : AbstractBuilding
    {
        public Farm()
        {
            BuildBuildingsCapabilities = new List<AbstractBuildBuildingCapability>();
            BuildUnitCapabilities = new List<AbstractBuildUnitCapability>();
            BuildBuildingsCapabilities.Add(new BuildBarrackCapability());
        }
    }
}