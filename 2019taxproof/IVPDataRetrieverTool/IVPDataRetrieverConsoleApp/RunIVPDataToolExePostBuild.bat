@echo off
set ProjectDirectory=%1
set OutputDirectory=%2
 START %OutputDirectory%IVPDataRetrieverConsoleApp.exe "%ProjectDirectory%..\..\..\Dynamics 365 Solutions" "%ProjectDirectory%..\..\..\Cmc.Engage.Main\Automation\Cmc.Engage.IVP\TestData"START %ProjectDirectory%%OutputDirectory%IVPDataRetrieverConsoleApp.exe "%ProjectDirectory%../../../Dynamics 365 Solutions" "%ProjectDirectory%../../../Cmc.Engage.Main/Automation/Cmc.Engage.IVP/TestData"
REM START %OutputDirectory%IVPDataRetrieverConsoleApp.exe "%ProjectDirectory%..\..\..\Dynamics 365 Solutions" "%ProjectDirectory%..\..\..\Cmc.Engage.Main\Automation\Cmc.Engage.IVP\TestData"