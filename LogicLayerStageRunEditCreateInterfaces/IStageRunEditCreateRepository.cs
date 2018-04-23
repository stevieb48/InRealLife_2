using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerStageRunEditCreateInterfaces
{
    public interface IStageCreateEditRunRepository
    {
        Stage GetFirstStage(int scenarioID);
        Stage GetNextStage(int NextStageID);
        int SaveStageData(Stage stage, bool starterFlag);
    }
}
