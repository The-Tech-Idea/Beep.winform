import clr
import sys
assembly_path = r"{BeepPath}"
sys.path.append(assembly_path)

clr.AddReference("DataManagmentEngineStandard")
from TheTechIdea.Beep import DMEEditor
