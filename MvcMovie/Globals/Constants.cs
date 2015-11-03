using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcMovie.Globals
{
    public static class Constants
    {
        public static string ROLE_ADMIN = "admin";
        public static string ROLE_AGENT = "agent";
        public static string ROLE_SUPERVISOR = "supervisor";
        public static int PRIORITY_LOW = 0;
        public static int PRIORITY_NORMAL = 1;
        public static int PRIORITY_HIGH = 2;
        public static int PRIORITY_VERYHIGH = 3;
        public static string STATUS_NEW = "new";
        public static string STATUS_ASSIGNED = "assigned";
        public static string STATUS_CLOSED = "closed";

    }
}