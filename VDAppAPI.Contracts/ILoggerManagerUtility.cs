#region Proprietary Information
/* 
    * Created by:   Vision-Dream ICT Solutions
    * Author:       Onkgopotse Lenake
    * Email:        visiondreamict@gmail.com
    * Website:      www.visiondreamict.wordpress.com
    * 
    *               (c) 2019 Vision-Dream ICT Solutions. All rights reserved.
    * _______________________________________________________________________
    * Project:      Vision-Dream .Net Core 2.2 Web Application.
    *               Project Targeting .Net Core 2.2.
    * Version:      v1.0.0
    * File:         ILoggerManagerUtility.cs
    * Date:         2019-01-10
    * Description:  This file contains the ILoggerManagerUtility interface. 
    *               Interface execution code.
*/
#endregion

namespace VDAppAPI.Contracts
{
    public interface ILoggerManagerUtility
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}
