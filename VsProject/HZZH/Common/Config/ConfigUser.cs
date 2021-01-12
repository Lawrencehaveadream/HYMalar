using System;
using System.Collections.Generic;
using System.Linq;
using CommonRs;



namespace ConfigSpace
{
    [Serializable]
    public class ConfigUser : Config
    {
        public ConfigUser()
        {
            UserList = new List<User>();
        }

        /// <summary>
        /// 属性：用户列表实体(用于实体删减+查询)
        /// </summary>
        public List<User> UserList { set; get; }

    }
}
