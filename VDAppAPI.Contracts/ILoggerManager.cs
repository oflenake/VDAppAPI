#region Proprietary Information
/* 
    * Created by:   Vision-Dream ICT Solutions
    * Author:       Onkgopotse Lenake
    * Email:        visiondreamict@gmail.com
    * Website:      www.visiondreamict.wordpress.com
    * 
    * Copyright (c) 2019 Vision-Dream ICT Solutions. All rights reserved.
    * ___________________________________________________________________
    * Project:      Vision-Dream .Net Core 2.1 Web Application.
    *               Project Targeting .Net Core 2.1.
    * Version:      v1.0.0
    * File:         ILoggerManager.cs
    * Date:         2019-01-10
    * Description:  This file contains the ILoggerManager class. 
    *               Class execution code.
*/
#endregion

using System;

namespace VDAppAPI.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
