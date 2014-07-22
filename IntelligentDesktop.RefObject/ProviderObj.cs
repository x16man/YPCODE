using System;
using System.Collections.Generic;
using System.Text;
using Shmzh.Components.SystemComponent;
using Shmzh.Components.SystemComponent.IDAL;

namespace IntelligentDesktop.RefObject
{
    public class ProviderObj : System.MarshalByRefObject
    {
        public String str;
        public ProviderObj()
        {
            str = DateTime.Now.ToOADate().ToString();
            System.Diagnostics.Debug.WriteLine("创建对象：" + str);
        }

        ~ProviderObj()
        {
            System.Diagnostics.Debug.WriteLine("销毁对象：" + str);
        }

        public ICompany CreateCompanyProvider()
        {
            return new Company();
        }

        public IMenu CreateMenuProvider()
        {
            return new Menu();
        }

        public IOnlineStatus CreateOnlineStatusProvider()
        {
            return new OnlineStatus();
        }

        public IHistory CreateHistoryProvider()
        {
            return new History();
        }

        public User CreateUserProvider()
        {
            return new User();
        }

        public IDept CreateDeptProvider()
        {
            return new Dept();
        }

        public I_SD_Message CreateMessageProvider()
        {
            return new Message();
        }

        public I_SD_MessageType CreateMessageTypeProvider()
        {
            return new MessageType();
        }

        public IGroup CreateGroupProvider()
        {
            return new Group();
        }

    }
}
