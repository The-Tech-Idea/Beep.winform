import clr
import sys
assembly_path = r"BeepPath"
sys.path.append(assembly_path)
assembly_path = r"BeepLib"
sys.path.append(assembly_path)
assembly_path = r"{BeepClasses"
sys.path.append(assembly_path)
assembly_path = r"BeepDrivers"
sys.path.append(assembly_path)
assembly_path = r"BeepOtherDLL"
sys.path.append(assembly_path)

clr.AddReference("DataManagementModelsStandard")
clr.AddReference("DataManagmentEngineStandard")
clr.AddReference("Assembly_helpersStandard")
clr.AddReference("DMLoggerStandard")
clr.AddReference("JsonFileLoaderStandard")




from TheTechIdea.Util import ConfigEditor
from TheTechIdea.Util import ErrorsInfo
from TheTechIdea.Tools import AssemblyHandler
from TheTechIdea.Beep.Editor import ETL
from TheTechIdea.Beep.Workflow import WorkFlowEditor
from TheTechIdea.Beep.Workflow import WorkFlowStepEditor
from TheTechIdea.Beep.Workflow import RuleParser
from TheTechIdea.Beep.Workflow import RulesEditor
from TheTechIdea.Beep.Editor import DataTypesHelper
from TheTechIdea.Beep.Tools import ClassCreator
from TheTechIdea.Beep import Util
from TheTechIdea.Logger import DMLogger
from TheTechIdea.Util import JsonLoader
from TheTechIdea.Beep import DMEEditor

logger=DMLogger()
err=ErrorsInfo()
jsonloader=JsonLoader()
config=ConfigEditor(logger, err, jsonloader,"")
util=Util( logger,  err,  config)
assemblyloader=AssemblyHandler(config,  err,  logger,  util)

dm=DMEEditor(logger, util, err,  config)
