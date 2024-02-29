#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.UI;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.Core;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.WebUI;
using FTOptix.EventLogger;
using FTOptix.Store;
using FTOptix.Alarm;
using FTOptix.SQLiteStore;
using FTOptix.MicroController;
using FTOptix.CommunicationDriver;
#endregion

public class WindowResizeObserver : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        screenSizeVariable = LogicObject.GetVariable("ScreenSize");
        windowWidth = LogicObject.Owner.GetVariable("Width");
        windowHeight = LogicObject.Owner.GetVariable("Height");

        SetDisplaySize(windowWidth.Value);

        windowWidth.VariableChange += WindowWidth_VariableChange;
        windowHeight.VariableChange += WindowHeight_VariableChange;
    }

    private void WindowWidth_VariableChange(object sender, VariableChangeEventArgs e)
    {
        SetDisplaySize(e.NewValue);
    }

    private void WindowHeight_VariableChange(object sender, VariableChangeEventArgs e)
    {
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    private void SetDisplaySize(UAValue value)
    {
        if (value > 1000)
        {
            screenSizeVariable.Value = 0;
        }
        else if (value > 600)
        {
            screenSizeVariable.Value = 1;
        }
        else
        {
            screenSizeVariable.Value = 2;
        }
    }

    IUAVariable screenSizeVariable;
    IUAVariable windowWidth;
    IUAVariable windowHeight;
}
